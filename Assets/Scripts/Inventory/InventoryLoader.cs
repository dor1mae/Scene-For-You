using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Отвечает за загрузку инвентаря при загрузке сохранения
/// </summary>
public class InventoryLoader : ICanLoadSave<List<RealItem>>
{
    private List<RealItem> items;

    public InventoryLoader(List<RealItem> items)
    {
        this.items = items;
    }

    public void LoadSave(List<RealItem> data, Action<bool> callback = null)
    {
        //Сброс состояния инвентаря
        Equipment.onTakeOff?.Invoke();
        var inventory = GameManagerSingltone.Instance.Inventory.GetItems();
        inventory = inventory.FindAll(x => x.IsEquiped == false);
        foreach(var item in inventory)
        {
            item.TakeOff();
        }
        items.Clear();

        //Загрузка инвентаря из сохранения
        foreach(RealItem item in data)
        {
            item.SetItem(GameManagerSingltone.Instance.ScriptableDatabase.GetItemForKey(item.ItemID));
            Debug.Log($"{GetType()} : {item.ItemID}");

            if(item.Item is ItemToEquip)
            {
                if(item.IsEquiped)
                {
                    (item.Item as ItemToEquip).Equip();
                    Equipment.onSetSprite?.Invoke(item.Item as ItemToEquip);
                }
            }

            items.Add(item);
        }

        EquipmentWindow.OnSearch?.Invoke();
        callback?.Invoke(true);
    }
}
