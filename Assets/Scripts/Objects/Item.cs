using System;
using UnityEngine;


[Serializable]
public abstract class ItemEmpty : ScriptableObject
{
    public abstract EquipmentType _equipmentType { get; }

    [SerializeField] protected string _name;
    [SerializeField] protected string _id;
    [SerializeField] protected string _description;
    [SerializeField] protected Sprite _icon;
    [SerializeField] protected int _cost;
    [SerializeField] protected int _maxNumberOfItems;

    public string Name => _name;
    public string Description => _description;
    public int MaxNumberOfItems => _maxNumberOfItems;
    public Sprite Icon => _icon;
    public int Cost => _cost;
    public string ID => _id;

    public abstract bool isUsable { get; }

}

