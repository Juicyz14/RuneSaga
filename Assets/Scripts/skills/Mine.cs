using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Mine : ISkill {
   // Create a different brush for each ore or change it once it's been placed.
   // Associate what type of ore by ore id or ore enum?  We need to know ore hp and respawn rates.
   public Ore ore;

   private bool isMineable;
   private Vector2 previousPosition;
   private SkillManager manager;

   private void Awake() {
      // TODO Fix this as when disabled then enabled, ore would be up that's not right.
      isMineable = true;
   }

   public override bool Requirements(SkillManager manager, Transform t) {
      const float PositionDifference = 1.1f;
      bool flag = true;
      this.manager = manager;

      BaseItem pickaxe = Inventory.instance.GetItem(BaseItem.ItemTypes.PICKAXE);

      if ((pickaxe == null) ||
          (manager.GetSkillLevel(SkillType.Mining) < ore.level) ||
          (Mathf.Abs(t.position.x - transform.position.x) >= PositionDifference) ||
          (Mathf.Abs(t.position.y - transform.position.y) >= PositionDifference)) {
         flag = false;
      }

      return flag & isMineable;
   }

   public override void Init(Transform t) {
      previousPosition = t.position;
      manager.InterruptSkill += InterruptSkill;
   }

   public override void Execute(SkillAction action, GameObject go) {
      StartCoroutine(Run(action, go));
   }

   private IEnumerator Run(SkillAction action, GameObject go) {
      const float PositionDifference = 0.2f;
      int hp = ore.hp;
      int dmg = 0;

      BaseItem pickaxe = Inventory.instance.GetItem(BaseItem.ItemTypes.PICKAXE);
      if (pickaxe != null) {
         dmg = pickaxe.Strength;
      }

      while (true) {
         Vector2 pos = go.transform.position;
         if (interrupt || 
             (Mathf.Abs(pos.x - previousPosition.x) >= PositionDifference) ||
             (Mathf.Abs(pos.y - previousPosition.y) >= PositionDifference)) {
            interrupt = false;
            break;
         }

         if (hp <= 0) {
            if (isMineable) {
               isMineable = false;
               Inventory.instance.Add(ore.itemId);
               AddXpToSkill(SkillType.Mining, ore.xp);

               Color temp = action.gameObject.GetComponent<SpriteRenderer>().color;
               temp.a = 0.5f;

               action.gameObject.GetComponent<SpriteRenderer>().color = temp;
               action.StartCoroutine(ReturnAlpha(action.gameObject));
            }
            break;
         }

         hp -= dmg;
         yield return new WaitForSeconds(0.5f);
      }

      manager.InterruptSkill -= InterruptSkill;
   }

   private IEnumerator ReturnAlpha(GameObject go) {
      yield return new WaitForSeconds(ore.respawnRate);

      Color temp = go.GetComponent<SpriteRenderer>().color;
      temp.a = 1f;

      go.GetComponent<SpriteRenderer>().color = temp;
      isMineable = true;
   }
}
