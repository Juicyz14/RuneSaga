using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public List<BaseItem> itemsUI = new List<BaseItem>();

    public void Add(BaseItem item)
    {
        itemsUI.Add(item);
        UpdateUI();
    }

    public void Remove(BaseItem item)
    {
        itemsUI.Remove(item);
        UpdateUI();
    }

    private void UpdateUI()
    {

    }
}