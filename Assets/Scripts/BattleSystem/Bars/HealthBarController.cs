public class HealthBarController : BarController
{
    public override void Init()
    {
        _maxFill = _unit.Durability.MaxBar;
        _fill = _unit.Durability.Bar;

        _unit.Durability.isChanged += OnChanged;

        DrawFill();
    }
}
