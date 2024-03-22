
using System;
/// <summary>
/// Класс основа для характеристик
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Stat : IUpgrade<int>, IDowngrade<int>, ICanLoadSave<int>
{
    protected int _value;
    public int Value => _value;

    public Action<int> onValueChange;

    public Stat(int value)
    {
        _value = value;

        onValueChange?.Invoke(value);
    }

    public void Upgrade(int value)
    {
        _value  = _value + value;
        onValueChange?.Invoke(_value);
    }

    public void Downgrade(int value)
    {
        _value = _value - value;
        onValueChange?.Invoke(_value);
    }

    public void LoadSave(int data, Action<bool> callback = null)
    {
        _value = data;
    }
}

