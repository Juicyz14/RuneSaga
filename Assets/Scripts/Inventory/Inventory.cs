using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
   // Default size of inventory is 10.  It is expandable by using bags.
   private const int MaxSize = 10;
   private const int NoItem = -1;

   private InventoryUI inventoryUI;
   private Dictionary<int, BaseItem> items = new Dictionary<int, BaseItem>(MaxSize);
   public event Action<int, BaseItem> NewItemAdded;

   #region Singleton
   public static Inventory instance;

   private void Awake() {
      if (instance == null) {
         instance = this; ;
      }
   }
   #endregion

   private void Start() {
      inventoryUI = GetComponent<InventoryUI>();

      for (int i = 0; i < MaxSize; i++) {
         items.Add(i, null);
      }

      Add(1000);
   }

   public Dictionary<int, BaseItem> GetInventory() {
      return items;
   }

   public void Add(BaseItem item) {
      int loc = CheckInventory(item.ItemID);
      int slot = FindEmptySlot();

      if ((loc != NoItem) || (slot != NoItem)) {
         int temp = NoItem;
         if (!item.IsStackable() || (loc == NoItem)) {
            // Add item to inventory
            items[slot] = (BaseItem)item.Clone();
            temp = slot;
         }
         else {
            // Add to existing items stack size.
            items[loc].Count++;
            temp = loc;
         }

         if (NewItemAdded != null) {
            NewItemAdded(temp, item);
         }
      }
   }

   public void Add(int id) {
      BaseItem itemToAdd = ItemDatabase.instance.GetItemById(id);
      Add(itemToAdd);
   }

   public void Remove(BaseItem item) {
      //items.Remove(item);
      //inventoryUI.Remove(item);
   }

   public BaseItem GetItem(BaseItem.ItemTypes type) {
      BaseItem item = null;
      for (int i = 0; i < items.Count; i++) {
         if (items[i] != null) {
            if (items[i].ItemType == type) {
               item = items[i];
               break;
            }
         }
      }

      return item;
   }

   private int CheckInventory(int id) {
      // TODO Need to add more than id check.  Need to check stats or maybe an address.
      int pos = NoItem;
      for (int i = 0; i < items.Count; i++) {
         if ((items[i] != null) && (items[i].ItemID == id) && (items[i].Count < items[i].Stacksize)) {
            pos =  i;
            break;
         }
      }
      return pos;
   }

   private int FindEmptySlot() {
      int pos = NoItem;
      for (int i = 0; i < items.Count; i++) {
         if ((items[i] == null)) {
            pos = i;
            break;
         }
      }

      return pos;
   }
}