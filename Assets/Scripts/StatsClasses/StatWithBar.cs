using System;

/// <summary>
/// Класс для таких характеристик, которые образуют бары вроде маны, выносливости и здоровья
/// </summary>
public abstract class StatWithBar : Stat, IRestore<float>, ISpend<float>, ISync<float, float>
{
    protected float _maxBar;
    protected float _bar;

    protected float _mult;

    public float MaxBar => _maxBar;
    public float Bar => _bar;

    public StatWithBar(int value, float mult) : base(value)
    {
        _mult = mult;
        _maxBar = _value * _mult;
        _bar = _maxBar;
    }

    private Action<float, float> _isChanged;
    public Action<float, float> isChanged { get { return _isChanged; } set { _isChanged = value; } }

    public void Restore(float value)
    {
        if (_bar + value > _maxBar)
        {
            _bar = _maxBar;
        }
        else
        {
            _bar += value;
        }

        isChanged?.Invoke(_bar, _maxBar);
    }

    public virtual void Spend(float value)
    {
        if (_bar - value < 0)
        {
            _bar = 0;
        }
        else
        {
            _bar -= value;
        }

        isChanged?.Invoke(_bar, _maxBar);
    }

    public void Sync()
    {
        _maxBar = _value * _mult;
        _bar = _maxBar;

        isChanged?.Invoke(_bar, _maxBar);
    }

    public new void Upgrade(int value)
    {
        _value += value;

        Sync();
    }

    public new void Downgrade(int value)
    {
        _value -= value;

        Sync();
    }
}