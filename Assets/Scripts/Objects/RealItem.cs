using Newtonsoft.Json;
using System;
/// <summary>
/// Представляет копию придмета в инвентаре, созданную на основе ScriptableObject
/// </summary>
[Serializable]
public class RealItem : IEquip<ItemToEquip>
{
    [NonSerialized]
    private ItemEmpty _item;
    private int _numberOfItem;
    private bool _isEquiped;

    [JsonIgnore]
    public ItemEmpty Item => _item;
    [JsonIgnore]
    private string _itemID;
    public string ItemID => _itemID;
    public int NumberOfItems => _numberOfItem;
    public bool IsEquiped => _isEquiped;

    public RealItem(ItemEmpty item, int numberOfItem)
    {
        _item = item;
        _itemID = item.ID;

        if (numberOfItem <= _item.MaxNumberOfItems)
        {
            _numberOfItem = numberOfItem;
        }
        else
        {
            _numberOfItem = _item.MaxNumberOfItems;
        }

        _isEquiped = false;
    }

    [JsonConstructor]
    public RealItem(string ItemID, int NumberOfItems, bool IsEquiped)
    {
        _itemID = ItemID;
        _numberOfItem = NumberOfItems;
        _isEquiped = IsEquiped;
    }

    /// <summary>
    /// Надеть предмет класса ItemToEquip
    /// </summary>
    public void Equip(ItemToEquip item = null)
    {
        if (_item is ItemToEquip && _isEquiped == false)
        {
            (_item as ItemToEquip).Equip();
            _isEquiped = true;
        }
    }

    /// <summary>
    /// Снять предмет класса ItemToEquip
    /// </summary>
    public void TakeOff(ItemToEquip item = null)
    {
        if (_item is ItemToEquip && _isEquiped == true)
        {
            (_item as ItemToEquip).TakeOff();
            _isEquiped = false;
        }
    }

    /// <summary>
    /// Применение предмета класса ItemToUse
    /// </summary>
    public void Use()
    {
        if (_item is ItemToUse)
        {
            if ((_item as ItemToUse).IsHarmful)
            {
                (_item as ItemToUse).Use(EventBus.onGetEnemy?.Invoke());
            }
            else
            {
                (_item as ItemToUse).Use(EventBus.onGetPlayer?.Invoke());
            }
        }
    }

    public void SetItem(ItemEmpty item)
    {
        _item = item;
    }
}


