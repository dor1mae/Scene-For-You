using static UnityEngine.GraphicsBuffer;

public class PlayerCommandClient : CommandClient
{
	public override void Init()
	{
        _actionPointChecker = new(BattleSystem.OnGetPlayer.Invoke());
	}

    protected override bool CheckOpportunity()
    {
		if (_turnManager.GetActionCount <= _actionPointChecker.ActionPoints && _battleSystem._currentEnumState == BattleSystemStates.Player)
		{
			return true;
		}
        return false;
	}

    protected override void CreateFabric()
    {
        _commandFabric = new CommandFabric(BattleSystem.OnGetEnemy.Invoke(), BattleSystem.OnGetPlayer.Invoke());
    }
}
