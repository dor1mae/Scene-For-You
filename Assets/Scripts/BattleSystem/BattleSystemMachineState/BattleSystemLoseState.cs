using UnityEngine;

public class BattleSystemLoseState: IState
{
    private readonly BattleSystem _battleSystem;

    public BattleSystemLoseState(BattleSystem battleSystem)
    {
        _battleSystem = battleSystem;
    }

    public void Enter()
    {
        Debug.Log("Поражение");
    }

    public void Exit()
    {
        //
    }
}
