using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToValueScene : MonoBehaviour, IWorkWithScene, IButton
{
	[SerializeField] protected int _valueScene;
	[SerializeField] protected int _selfSceneValue;

	public virtual void LoadScene(Action<bool> callback = null, int sceneID = 0)
	{
		SceneManager.LoadScene(3, LoadSceneMode.Additive);

		callback?.Invoke(true);
	}

	public virtual void UnloadScene(Action<bool> callback = null)
	{
		SceneManager.UnloadSceneAsync(_selfSceneValue);

		callback?.Invoke(true);
	}

	public virtual void OnClick()
	{
		SceneTransferManager.SetSceneInitiator(this);
		SceneTransferManager.SceneInitiatorTransfer(_valueScene);
	}
}
