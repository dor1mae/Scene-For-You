using System;
using System.Collections.Generic;
using UnityEngine;


//Класс, представляющий данные в инвентаре и способы взаимодействия с ними
public class Inventory : MonoBehaviour
{
    [SerializeField] private List<ItemEmpty> _startItems;

    private List<RealItem> items = new List<RealItem>();
    //[SerializeField] private int NumberOfItems = 1;

    private InventoryLoader _inventoryLoader;

    /// <summary>
    /// Компонент, ответственный за загрузку данных инвентаря в класс Inventory
    /// </summary>
    public InventoryLoader InventoryLoader => _inventoryLoader; 

    public void Init()
    {
        foreach (var item in _startItems)
        {
            AddItem(new RealItem(item, 1));
        }

        GameManagerSingltone.Instance.SetInventory(this);
        _inventoryLoader = new InventoryLoader(items);
    }

    public List<RealItem> GetItems()
    {
        return items;
    }

    public void DeleteItem(RealItem item)
    {
        items.Remove(item);
    }

    public void AddItem(RealItem it)
    {
        items.Add(it);
    }
}
