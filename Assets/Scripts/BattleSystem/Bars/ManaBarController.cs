public class ManaBarController : BarController
{
    public override void Init()
    {
        _maxFill = _unit.Intelligence.MaxBar;
        _fill = _unit.Intelligence.Bar;

        _unit.Intelligence.isChanged += OnChanged;

        DrawFill();
    }

	private void OnDestroy()
	{
		_unit.Intelligence.isChanged -= OnChanged;
	}
}
