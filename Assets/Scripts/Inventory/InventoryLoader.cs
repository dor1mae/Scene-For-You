using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryLoader : ICanLoadSave<List<RealItem>>
{
    private List<RealItem> items;

    public InventoryLoader(List<RealItem> items)
    {
        this.items = items;
    }

    public void LoadSave(List<RealItem> data, Action<bool> callback = null)
    {
        items.Clear();

        foreach(RealItem item in data)
        {
            item.SetItem(GameManagerSingltone.Instance.ScriptableDatabase.GetItemForKey(item.ItemID));

            if(item.Item is ItemToEquip)
            {
                if(item.IsEquiped)
                {
                    (item.Item as ItemToEquip).Equip();
                    Equipment.onSetSprite?.Invoke(item.Item as ItemToEquip);
                }
            }
        }

        callback?.Invoke(true);
    }
}
