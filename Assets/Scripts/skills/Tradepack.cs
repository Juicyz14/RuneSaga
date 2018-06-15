using UnityEngine;
using System.Collections;

public class Tradepack : ISkill {
   public Pack pack;

   private static bool isTradepacking;
   private static Vector2 startLocation;

   private void Awake() {
      isTradepacking = false;
   }

   public override bool Requirements(SkillManager manager, Transform t) {
      // Check resources in inventory to see if they can make one
      return true;
   }

   public override void Init(Transform t) {
      startLocation = transform.position;
   }

   public override void Execute(SkillAction action, GameObject go) {
      const float Distance = 5f;
      // Doesnt do much.  If player is trade packing then we want to turn it in.
      if (isTradepacking) {
         if ((Mathf.Abs(startLocation.x - transform.position.x) >= Distance) && (Mathf.Abs(startLocation.y - transform.position.y) >= Distance)) {
            // Check that player still has the pack
            // if (validPack) {
               // Valid location to turn in tradepack.  Turn in trade pack
               // Remove pack from player and give reward
               AddXpToSkill(SkillType.Tradepacking, pack.xp);
            // }
         }
         else {
            // If it's the same location as start, send player an ugly message that he sucks
            // They keep tradepack and they can go somewhere else.
         }
      }
      else {
         // Create tradepack and remove resources
         if (Inventory.instance.Contains(pack.materials)) {
            foreach (int id in pack.materials) {
               Inventory.instance.Contains(id);
            }
            isTradepacking = true;
         }
      }
   }
}
