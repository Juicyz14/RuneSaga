using UnityEngine;
using System.Collections.Generic;

public enum SkillType {
   Fishing,
   Cooking,
   Mining,
   Blacksmithing,
   Enchanting,
   Tradepacking
}

public class SkillManager : MonoBehaviour {
   private const int MaxLevel = 50;
   private const int BaseXp = 58;

   private class SkillStat {
      public int level;
      public int xp;
      public int xpNeededToLevel;

      public SkillStat() {
         level = 1;
         xp = 0;
         xpNeededToLevel = BaseXp;
      }

      public SkillStat(int level, int xp, int xpNeededToLevel) {
         this.level = level;
         this.xp = xp;
         this.xpNeededToLevel = xpNeededToLevel;
      }
   }

   private Dictionary<SkillType, SkillStat> skillMap;

   #region Unity Methods
   private void Awake() {
      skillMap = new Dictionary<SkillType, SkillStat>() {
         {SkillType.Fishing, new SkillStat()},
         {SkillType.Cooking, new SkillStat()},
         {SkillType.Mining, new SkillStat()},
         {SkillType.Blacksmithing, new SkillStat()},
         {SkillType.Enchanting, new SkillStat()},
         {SkillType.Tradepacking, new SkillStat()},
      };

      ISkill.AddXp += AddSkillXp;
   }
   private void OnEnable() {
      GameInputManager.ObserveMouseButton(0);

      GameInputManager.Register(OnInputEvent);
   }

   private void OnDisable() {
      GameInputManager.Unregister(OnInputEvent);
   }
   #endregion

   /**
    * Xp = Ceiling((Level - 1) * 1.10409 + (Level 2))
    */
   public void AddSkillXp(SkillType type, int xp) {
      Debug.Log(xp);
      const float xpMultiplier = 1.10409f;
      SkillStat skill;

      if (skillMap.TryGetValue(type, out skill)) {
         skill.xp += xp;

         if (skill.xp >= skill.xpNeededToLevel) {
            while (skill.xp >= skill.xpNeededToLevel) {
               skill.level++;
               skill.xp -= skill.xpNeededToLevel;
               
               skill.xpNeededToLevel = Mathf.CeilToInt(skill.xpNeededToLevel * xpMultiplier + BaseXp);
            }
         }

         Debug.Log(skill.xp);
         Debug.Log(skillMap[type].xp);
         EventManager.TriggerEvent(EventTags.UpdateSkillUiEvent);
      }
   }

   public int GetSkillXp(SkillType type) {
      SkillStat skill;
      int xp = 0;

      if (skillMap.TryGetValue(type, out skill)) {
         xp = skill.xp;
      }

      return xp;
   }

   public int GetSkillXpNeeded(SkillType type) {
      SkillStat skill;
      int xp = BaseXp;

      if (skillMap.TryGetValue(type, out skill)) {
         xp = skill.xpNeededToLevel;
      }

      return xp;
   }

   public int GetSkillLevel(SkillType type) {
      SkillStat skill;
      int level = 1;

      if (skillMap.TryGetValue(type, out skill)) {
         level = skill.level;
      }

      return level;
   }

   private void OnInputEvent(GameInputManager.EventData data) {
      if (data.used) {
         return;
      }

      // If user left clicked, check to see what he clicked.
      if (data.mouse == 0) {
         RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

         if (hit.collider != null) {
            if (hit.collider.tag == "Skill") {
               ISkill action = hit.collider.gameObject.GetComponent<ISkill>();
               if (action.Requirements()) {
                  action.Init(transform);
                  StartCoroutine(action.Execute(action, gameObject));
               }
            }
         }
      }
   }
}
