public class ManaBarController : BarController
{
    public override void Initialize()
    {
        _maxFill = _unit.Intelligence.MaxBar;
        _fill = _unit.Intelligence.Bar;

        _unit.Intelligence.isChanged += OnChanged;

        DrawFill();
    }
}
