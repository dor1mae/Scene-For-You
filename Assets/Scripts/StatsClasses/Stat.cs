
using System;
/// <summary>
/// Класс основа для характеристик
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Stat : IUpgrade<int>, IDowngrade<int>, ICanLoadSave<int>
{
    protected int _value;
    public int Value => _value;

    public Stat(int value)
    {
        _value = value;
    }

    public void Upgrade(int value)
    {
        _value += value;
    }

    public void Downgrade(int value)
    {
        _value -= value;
    }

    public void LoadSave(int data, Action<bool> callback = null)
    {
        _value = data;
    }
}

