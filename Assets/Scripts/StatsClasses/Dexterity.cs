using System;

/// <summary>
/// Отвечает за стат ловкости. Тут криты и прочее
/// </summary>
public class Dexterity : Stat
{
    protected float _multDamage;
    public float MultDamage => _multDamage;

    public Dexterity(int value, float multDamage = 1.5f) : base(value)
    {
        _multDamage = multDamage;
    }

    public float Attack(int damage)
    {
        if (UnityEngine.Random.Range(0, 100) <= Value)
        {
            return damage * MultDamage;
        }
        else
        { return damage; }
    }
}

