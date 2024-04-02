using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuStartButton : MonoBehaviour, IButton, IWorkWithScene
{
    private int _selfId = 0;
    private int _nextSceneId = 2;

    public void OnClick()
    {
        SceneTransferManager.SetSceneInitiator(this);
        SceneTransferManager.SceneInitiatorTransfer(_nextSceneId);
    }

    public void LoadScene(Action<bool> callback = null, int sceneID = default)
    {
        SceneManager.LoadScene(3);

        callback?.Invoke(true);
    }

    public void UnloadScene(Action<bool> callback = null)
    {
        SceneManager.UnloadSceneAsync(_selfId);

        callback?.Invoke(true);
    }
}
