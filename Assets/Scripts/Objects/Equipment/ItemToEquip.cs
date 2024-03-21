using System;
using UnityEngine;

public abstract class ItemToEquip : ItemEmpty, IItemToEquip
{
    public override bool isUsable => true;

    [SerializeField] protected int _power;
    [SerializeField] protected int _durability;
    [SerializeField] protected int _endurance;
    [SerializeField] protected int _dexterity;
    [SerializeField] protected int _intelligence;

    public abstract void Equip();

    ///<summary>
    ///_power, _durability, _endurance, _dexterity, _intelligence
    ///</summary>
    public Tuple<int, int, int, int, int> GetStats()
    {
        return new Tuple<int, int, int, int, int>(_power, _durability, _endurance, _dexterity, _intelligence);
    }

    public abstract void TakeOff();
}