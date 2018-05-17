//Item Database
using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
//Base Item class.
public class BaseItem : ICloneable {
   //Item Types
   public enum ItemTypes {
      NONE,
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

   public BaseItem() {
      ItemName = "";
      ItemDescription = "";
      ItemID = -1;
      ItemType = ItemTypes.NONE;
      Health = 0;
      Mana = 0;
      Strength = 0;
      Intelligence = 0;
      Dexterity = 0;
      Defense = 0;
      Spirit = 0;
      Proficiency = 0;
   }

   public object Clone() {
      BaseItem newItem = new BaseItem();

      newItem.ItemName = ItemName;
      newItem.ItemDescription = ItemDescription;
      newItem.ItemID = ItemID;
      newItem.ItemType = ItemType;
      newItem.Health = Health;
      newItem.Mana = Mana;
      newItem.Strength = Strength;
      newItem.Intelligence = Intelligence;
      newItem.Dexterity = Dexterity;
      newItem.Defense = Defense;
      newItem.Spirit = Spirit;
      newItem.Proficiency = Proficiency;

      return newItem;
   }
}