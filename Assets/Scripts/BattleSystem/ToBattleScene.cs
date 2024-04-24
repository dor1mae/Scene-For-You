using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToBattleScene : ToValueScene
{
	[SerializeField] private GameObject _worldScene;

	public override void OnClick()
	{
		_valueScene = 1;
		_selfSceneValue = 2;

		base.OnClick();
	}

	public override void UnloadScene(Action<bool> callback = null)
	{
		GameManagerSingltone.Instance.ChangeStatusWorld(false);

		callback?.Invoke(true);
	}
}
