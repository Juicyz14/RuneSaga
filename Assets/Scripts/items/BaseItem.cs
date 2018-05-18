//Item Database
using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
//Base Item class.
public class BaseItem : ICloneable {
   //Item Types
   public enum SlotTypes {
      NONE,
      WEAPON,
      EQUIPMENT,
      RUNE,
      POTION,
      QUEST,
      MATERIAL
   }

   public enum ItemTypes {
      NONE,
      PICKAXE
   }

   public string ItemName { get; set; }
   public string ItemDescription { get; set; }
   public int ItemID { get; set; }
   public SlotTypes SlotType { get; set; }
   public ItemTypes ItemType { get; set; }

   public int Health { get; set; }
   public int Mana { get; set; }
   public int Strength { get; set; }
   public int Intelligence { get; set; }
   public int Dexterity { get; set; }
   public int Defense { get; set; }
   public int Spirit { get; set; }
   public int Proficiency { get; set; }

   // The max number that can be stacked.  See Count for how many there are.
   public int Stacksize { get; set; }
   // The number of items in the stack for this item.
   public int Count { get; set; }

   public BaseItem() {
      ItemName = "";
      ItemDescription = "";
      ItemID = -1;
      SlotType = SlotTypes.NONE;
      ItemType = ItemTypes.NONE;
      Health = 0;
      Mana = 0;
      Strength = 0;
      Intelligence = 0;
      Dexterity = 0;
      Defense = 0;
      Spirit = 0;
      Proficiency = 0;
      Stacksize = 1;
      Count = 1;
   }

   public object Clone() {
      BaseItem newItem = new BaseItem();

      newItem.ItemName = ItemName;
      newItem.ItemDescription = ItemDescription;
      newItem.ItemID = ItemID;
      newItem.SlotType = SlotType;
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

   public bool IsStackable() {
      return (Stacksize > 1);
   }
}