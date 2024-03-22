/// <summary>
/// Здоровье, она же Крепость
/// </summary>
public class Durability : StatWithBar
{
    private Unit _owner;
    public Durability(int value, Unit owner, float mult = 25) : base(value, mult)
    {
        _owner = owner;
    }

    public override void Spend(float value)
    {
        if (_bar - value < 0)
        {
            _bar = 0;
        }
        else
        {
            _bar -= value;
        }

        EventBus.Died?.Invoke(_owner);
        isChanged?.Invoke(_bar, _maxBar);
    }
}

