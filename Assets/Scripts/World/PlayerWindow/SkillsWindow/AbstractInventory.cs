using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInventory<T1, T2> : InitClass
{
    [SerializeField] private T1[] _startItems;
    private List<T2> _items = new();

    public override void Init()
    {
        if(_items.Capacity == 0)
        {
            foreach (var item in _startItems)
            {
                AddItem(item);
            }
        }
    }

    public abstract void AddItem(T1 item);

    public void Delete(T2 item)
    {
        _items.Remove(item);
    }

    public List<T2> GetItems()
    {
        return _items;
    }
}
