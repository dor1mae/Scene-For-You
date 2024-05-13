using UnityEngine;


public class BattleSystemActionState : IState<BattleSystemStates>
{
    private readonly BattleSystem _battleSystem;
    private readonly TurnManager _turnManager;

	public BattleSystemStates GetEnum
	{
		get
		{
			return BattleSystemStates.Action;
		}
	}

	public BattleSystemActionState(BattleSystem battleSystem, TurnManager turnManager)
    {
        _battleSystem = battleSystem;
        _turnManager = turnManager;
    }

    public void Enter()
    {
        Debug.Log($"{GetType()} вход");
        Turn();
    }

    private void Turn()
    {
        _turnManager.Play();
    }

    public void Exit()
    {
        Debug.Log($"{GetType()} выход");

    }
}
