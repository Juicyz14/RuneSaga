using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Mine : ISkill {
   // Create a different brush for each ore or change it once it's been placed.
   // Associate what type of ore by ore id or ore enum?  We need to know ore hp and respawn rates.
   public Ore ore;

   private bool isMineable;
   private Vector2 previousPosition;

   private void OnEnable() {
      // TODO Fix this as when disabled then enabled, ore would be up that's not right.
      isMineable = true;
   }

   public override bool Requirements() {
      return isMineable;
   }

   public override void Init(Transform transform) {
      previousPosition = transform.position;
   }

   public override IEnumerator Execute(SkillAction action, GameObject go) {
      int hp = ore.hp;

      while (true) {
         Vector2 pos = go.transform.position;
         if (((int)pos.x != (int)previousPosition.x) || ((int)pos.y != (int)previousPosition.y)) {
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

         hp -= 4;
         yield return new WaitForSeconds(1);
      }
   }

   private IEnumerator ReturnAlpha(GameObject go) {
      yield return new WaitForSeconds(ore.respawnRate);

      Color temp = go.GetComponent<SpriteRenderer>().color;
      temp.a = 1f;

      go.GetComponent<SpriteRenderer>().color = temp;
      isMineable = true;
   }
}
