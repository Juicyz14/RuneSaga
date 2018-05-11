using UnityEngine;
using System;
using System.Collections;

public abstract class ISkill : SkillAction {
   // Skills will call this when they have completed their action.
   public static event Action<SkillType, int> AddXp;

   public abstract bool Requirements();
   public abstract void Init(Transform transform);
   public abstract IEnumerator Execute(SkillAction action, GameObject go);

   protected void AddXpToSkill(SkillType type, int xp) {
      AddXp(type, xp);
   }
}
