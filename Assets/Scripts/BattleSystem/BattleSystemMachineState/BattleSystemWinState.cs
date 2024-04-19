using UnityEngine;

public class BattleSystemWinState : IState<BattleSystemStates>
{
    private readonly BattleSystem _battleSystem;

	public BattleSystemStates GetEnum
	{
		get
		{
			return BattleSystemStates.Win;
		}
	}

	public BattleSystemWinState(BattleSystem battleSystem)
    {
        _battleSystem = battleSystem;
    }

	public void Enter()
    {
        Debug.Log("Победа");
    }

    public void Exit()
    {
        //
    }
}
