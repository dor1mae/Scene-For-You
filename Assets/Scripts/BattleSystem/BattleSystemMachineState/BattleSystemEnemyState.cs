using UnityEngine;

public class BattleSystemEnemyState : IState
{
    private readonly BattleSystem _battleSystem;

    public BattleSystemEnemyState(BattleSystem battleSystem)
    {
        _battleSystem = battleSystem;
    }

    public void Enter()
    {
        Debug.Log($"{GetType()} вход");

        Turn();
    }

    private void Turn()
    {
        var enemy = BattleSystem.OnGetEnemy.Invoke();
        //enemy.MakeTurn()

        _battleSystem.EnterIn<BattleSystemActionState>();
        _battleSystem.EnterIn<BattleSystemPlayerState>();
    }

    public void Exit()
    {
        Debug.Log($"{GetType()} выход");

        EventBus.TurnEnded?.Invoke();
    }
}