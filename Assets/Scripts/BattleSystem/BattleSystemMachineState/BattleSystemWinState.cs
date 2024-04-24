using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSystemWinState : IState<BattleSystemStates>
{
    private readonly BattleSystem _battleSystem;
    private Enemy _enemy;

	public BattleSystemStates GetEnum
	{
		get
		{
			return BattleSystemStates.Win;
		}
	}

	public BattleSystemWinState(BattleSystem battleSystem, Enemy enemy)
    {
        _battleSystem = battleSystem;
        _enemy = enemy;
    }

	public void Enter()
    {
        Debug.Log("Победа");

        //ExpManager.GivePoints(Player);

        GameManagerSingltone.Instance.ChangeStatusWorld(true);
        _enemy.SelfDestroy();
        SceneManager.UnloadSceneAsync(1);
    }

    public void Exit()
    {
        //
    }
}
