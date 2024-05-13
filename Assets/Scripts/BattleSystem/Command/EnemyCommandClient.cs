public class EnemyCommandClient : CommandClient
{
	public override void Init()
	{
		_actionPointChecker = new(BattleSystem.OnGetEnemy.Invoke());
	}

	protected override void CreateFabric()
	{
		_commandFabric = new CommandFabric(BattleSystem.OnGetPlayer.Invoke(), BattleSystem.OnGetEnemy.Invoke());
	}

	protected override bool CheckOpportunity()
	{
		if (_turnManager.GetActionCount <= _actionPointChecker.ActionPoints && _battleSystem._currentEnumState == BattleSystemStates.Enemy)
		{
			return true;
		}
		return false;
	}
}

