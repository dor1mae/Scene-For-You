using UnityEngine;

public class BattleSystemPlayerState : IState
{
    private readonly BattleSystem _battleSystem;

    public BattleSystemPlayerState(BattleSystem battleSystem)
    {
        _battleSystem = battleSystem;
    }

    public void Enter()
    {
        Debug.Log($"{GetType()} вход");

        EventBus.TurnEnded += TurnEnded;
    }

    private void TurnEnded()
    {
        _battleSystem.EnterIn<BattleSystemActionState>();
        _battleSystem.EnterIn<BattleSystemEnemyState>();
    }

    public void Exit()
    {
        Debug.Log($"{GetType()} выход");

        EventBus.TurnEnded -= TurnEnded;
    }
}

