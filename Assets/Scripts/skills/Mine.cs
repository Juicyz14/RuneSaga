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

   private void OnEnable() {
      // TODO Fix this as when disabled then enabled, ore would be up that's not right.
      isMineable = true;
   }

   public override bool Requirements(Transform t) {
      const float PositionDifference = 1.1f;
      bool flag = true;

      if ((Mathf.Abs(t.position.x - transform.position.x) >= PositionDifference) ||
          (Mathf.Abs(t.position.y - transform.position.y) >= PositionDifference)) {
         flag = false;
      }

      return flag & isMineable;
   }

   public override void Init(SkillManager manager, Transform t) {
      this.manager = manager;
      manager.InterruptSkill += InterruptSkill;
      previousPosition = t.position;
   }

   public override IEnumerator Execute(SkillAction action, GameObject go) {
      const float PositionDifference = 0.2f;
      int hp = ore.hp;

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
               AddXpToSkill(SkillType.Mining, ore.xp);

               Color temp = action.gameObject.GetComponent<SpriteRenderer>().color;
               temp.a = 0.5f;

               action.gameObject.GetComponent<SpriteRenderer>().color = temp;
               action.StartCoroutine(ReturnAlpha(action.gameObject));
            }
            break;
         }

         hp -= 33;
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
