using UnityEngine;

public class BattleSystemWinState : IState
{
    private readonly BattleSystem _battleSystem;

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
