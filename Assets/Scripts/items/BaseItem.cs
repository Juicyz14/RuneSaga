//Item Database
using UnityEngine;
using System.Collections;

[System.Serializable]
//Base Item class.
public class BaseItem {
   //Item Types
   public enum ItemTypes {
      WEAPON,
      EQUIPMENT,
      RUNE,
      POTION,
      QUEST,
      MATERIAL
   }

   public string ItemName { get; set; }
   public string ItemDescription { get; set; }
   public int ItemID { get; set; }
   public ItemTypes ItemType { get; set; }

   public int Health { get; set; }
   public int Mana { get; set; }
   public int Strength { get; set; }
   public int Intelligence { get; set; }
   public int Dexterity { get; set; }
   public int Defense { get; set; }
   public int Spirit { get; set; }
   public int Proficiency { get; set; }
}