using UnityEngine;
using UnityEngine.UI;

public class BattleSystemPlayerState : IState<BattleSystemStates>
{
    private readonly BattleSystem _battleSystem;
    private readonly Button _start;
    private TurnManager _turnManager;

    public BattleSystemStates GetEnum
    {
        get
        {
            return BattleSystemStates.Player;
        }
    }

	public BattleSystemPlayerState(BattleSystem battleSystem, Button start, TurnManager turnManager)
    {
        _battleSystem = battleSystem;
        _start = start;
        _turnManager = turnManager;

        _start.onClick.RemoveAllListeners();
        _start.onClick.AddListener(()=>
        {
            EventBus.TurnEnded.Invoke();
        });
    }

    public void Enter()
    {
        Debug.Log($"{GetType()} вход");

        EventBus.TurnEnded += TurnEnded;
    }

    private void TurnEnded()
    {
		_battleSystem.EnterIn<BattleSystemActionState>();
        _turnManager.OnSequenceEnd += Change;
    }

    public void Exit()
    {
        Debug.Log($"{GetType()} выход");

        EventBus.TurnEnded -= TurnEnded;
    }

	private void Change()
    { 
		_turnManager.OnSequenceEnd -= Change;
		_battleSystem.EnterIn<BattleSystemEnemyState>();
	}
}

