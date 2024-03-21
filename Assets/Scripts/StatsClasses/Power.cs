

using System;
/// <summary>
/// Считает урон за счет характеристики. Может быть расширен
/// </summary>
public class Power : Stat
{
    public Power(int value) : base(value)
    {
    }

    public int CheckDamage()
    {
        return Value * 5;
    }
}
