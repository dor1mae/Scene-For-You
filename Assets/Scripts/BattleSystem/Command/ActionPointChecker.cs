public class ActionPointChecker
{
	private Unit _owner;

	public int ActionPoints
	{
		get
		{
			return _owner.Dexterity.Value / 10;
		}
	}

	public ActionPointChecker(Unit owner)
	{
		_owner = owner;
	}
}