using UnityEngine;

public class BattleSystemEnemyState : IState<BattleSystemStates>
{
    private readonly BattleSystem _battleSystem;
    private TurnManager _turnManager;

	public BattleSystemStates GetEnum
	{
		get
		{
			return BattleSystemStates.Enemy;
		}
	}

	public BattleSystemEnemyState(BattleSystem battleSystem, TurnManager turnManager)
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
        var enemy = BattleSystem.OnGetEnemy.Invoke().GetComponentInChildren<SimpleEnemyAI>();

        enemy.MakeDecision();
		enemy.MakeDecision();

		_battleSystem.EnterIn<BattleSystemActionState>();
		_turnManager.OnSequenceEnd += Change;
	}

    public void Exit()
    {
        Debug.Log($"{GetType()} выход");

        //Оно тут для отсчета перезарядки скиллов и предметов
        EventBus.TurnEnded?.Invoke();
    }

	private void Change()
	{
		_turnManager.OnSequenceEnd -= Change;
		_battleSystem.EnterIn<BattleSystemPlayerState>();
	}
}