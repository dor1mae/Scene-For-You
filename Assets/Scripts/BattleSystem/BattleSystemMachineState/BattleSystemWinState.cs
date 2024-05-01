using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSystemWinState : IState<BattleSystemStates>
{
    private GameObject _rewardWindow;
    private Transform _rewardTransform;
    private readonly BattleSystem _battleSystem;
    private Enemy _enemy;

	public BattleSystemStates GetEnum
	{
		get
		{
			return BattleSystemStates.Win;
		}
	}

	public BattleSystemWinState(BattleSystem battleSystem, Enemy enemy, GameObject rewardWindow, Transform transform)
    {
        _battleSystem = battleSystem;
        _enemy = enemy;
        _rewardWindow = rewardWindow;
        _rewardTransform = transform;
    }

	public void Enter()
    {
        Debug.Log("Победа");

        var reward = Canvas.Instantiate(_rewardWindow);
        reward.transform.SetParent(_rewardTransform, false);
        reward.GetComponent<RewardWindow>().Init(BattleSystem.OnGetPlayer.Invoke(), _enemy);
    }

    public void Exit()
    {
        //
    }
}
