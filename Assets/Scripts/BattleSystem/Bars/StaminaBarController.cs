public class StaminaBarController : BarController
{
    public override void Initialize()
    {
        _maxFill = _unit.Endurance.MaxBar;
        _fill = _unit.Endurance.Bar;

        _unit.Endurance.isChanged += OnChanged;

        DrawFill();
    }
}

