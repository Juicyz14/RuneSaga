using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
   // Default size of inventory is 10.  It is expandable by using bags.
   private const int MaxSize = 10;
   private const int NoItem = -1;

   private InventoryUI inventoryUI;
   private Dictionary<int, BaseItem> items = new Dictionary<int, BaseItem>(MaxSize);
   public event Action<int, BaseItem> NewItemAdded;

   #region Singleton
   public static Inventory instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; ;
        }
    }
    #endregion

   private void Start()
   {
      inventoryUI = GetComponent<InventoryUI>();

      for (int i = 0; i < MaxSize; i++) {
         items.Add(i, null);
      }
   }

   public Dictionary<int, BaseItem> GetInventory() {
      return items;
   }

   public void Add(BaseItem item)
   {
      int loc = CheckInventory(item.ItemID);

      if (loc == NoItem) {
         // Add item to inventory
         int slot = FindEmptySlot();
         items[slot] = item;
         Debug.Log("Item added");

         if (NewItemAdded != null) {
            NewItemAdded(slot, item);
         }
      }
      else {
         // Add to existing items stack size.
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

   private int CheckInventory(int id) {
      // TODO Need to add more than id check.  Need to check stats or maybe an address.
      int pos = NoItem;
      for (int i = 0; i < items.Count; i++) {
         if ((items[i] != null) && (items[i].ItemID == id)) {
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