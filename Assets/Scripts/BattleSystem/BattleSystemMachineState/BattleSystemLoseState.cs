using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSystemLoseState: IState<BattleSystemStates>
{
    private readonly BattleSystem _battleSystem;

    public BattleSystemLoseState(BattleSystem battleSystem)
    {
        _battleSystem = battleSystem;
    }

	public BattleSystemStates GetEnum
	{
		get
		{
			return BattleSystemStates.Lose;
		}
	}

	public void Enter()
    {
        Debug.Log("Поражение");

		SceneManager.UnloadSceneAsync(1);
	}

    public void Exit()
    {
        //
    }
}
