public class StaminaBarController : BarController
{
    public override void Init()
    {
        _maxFill = _unit.Endurance.MaxBar;
        _fill = _unit.Endurance.Bar;

        _unit.Endurance.isChanged += OnChanged;

        DrawFill();
    }
}

