using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   private InventoryUI inventoryUI;
   public List<BaseItem> items = new List<BaseItem>();

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
    }

    public void Add(BaseItem item)
    {
        items.Add(item);
        //inventoryUI.Add(item);
    }
    public void Remove(BaseItem item)
    {
        items.Remove(item);
        //inventoryUI.Remove(item);
    }
}