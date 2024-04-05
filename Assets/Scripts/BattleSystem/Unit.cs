using System;
using UnityEngine;

[Serializable]
public abstract class Unit : InitClass
{
    protected Power _power;
    protected Dexterity _dexterity;
    protected Intelligence _intelligence;
    protected Endurance _endurance;
    protected Durability _durability;

    public Power Power => _power;
    public Dexterity Dexterity => _dexterity;
    public Intelligence Intelligence => _intelligence;
    public Endurance Endurance => _endurance;
    public Durability Durability => _durability;


    [SerializeField] protected int StatDurability;
    [SerializeField] protected int StatEndurace;
    [SerializeField] protected int StatIntelligence;
    [SerializeField] protected int StatPower;
    [SerializeField] protected int StatDexterity;
    [SerializeField] protected string _name;

    public string Name => _name;

    public Action Turned;

    public bool _isBuffed = false;

    public override void Init()
    {
        _power = new Power(StatPower);
        _dexterity = new Dexterity(StatDexterity, 1.5f);
        _intelligence = new Intelligence(StatIntelligence, 25);
        _endurance = new Endurance(StatEndurace, 25);
        _durability = new Durability(StatDurability, this, 25);


        Debug.Log($"{GetType()}: is initialized");
    }

    public int CheckBattlePower()
    {
        return _durability.Value + _endurance.Value + _intelligence.Value + _power.Value * 5 + _dexterity.Value * 5;
    }
}
