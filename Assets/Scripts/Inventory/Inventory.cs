using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

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

    private InventoryUI inventoryUI;

    private void Start()
    {
        inventoryUI = GetComponent<InventoryUI>();
    }

    public List<BaseItem> items = new List<BaseItem>();

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
