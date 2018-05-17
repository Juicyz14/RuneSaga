using UnityEngine;
using System;
using System.Collections;

public abstract class ISkill : SkillAction {
   // Skills will call this when they have completed their action.
   public static event Action<SkillType, int> AddXp;

   public abstract bool Requirements(Transform t);
   public abstract void Init(SkillManager manager, Transform t);
   public abstract void Execute(SkillAction action, GameObject go);

   protected void AddXpToSkill(SkillType type, int xp) {
      if (AddXp != null) {
         AddXp(type, xp);
      }
   }

   protected bool interrupt = false;
   protected void InterruptSkill() {
      interrupt = true;
   }
}
