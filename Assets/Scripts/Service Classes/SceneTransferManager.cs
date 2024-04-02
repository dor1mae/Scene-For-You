using System.Diagnostics;
using UnityEngine;
using System;

public static class SceneTransferManager
{
    private static int _nextSceneID;
    private static IWorkWithScene _sceneInitiator;

    public static Action<IWorkWithScene> onRequestScene;

    public static void SetSceneInitiator(IWorkWithScene scene)
    {
        _sceneInitiator = scene;
    }

    public static void SceneInitiatorTransfer(int nextScene)
    {
        onRequestScene += SceneContinuatorTransfer;

        _sceneInitiator.LoadScene((anwer) =>
        {
            if(anwer)
            {
                UnityEngine.Debug.Log($"{nextScene} получен");
                _sceneInitiator.UnloadScene();
                _nextSceneID = nextScene;
            }
        });
    }

    public static void SceneContinuatorTransfer(IWorkWithScene sceneContinuator)
    {
        sceneContinuator.LoadScene((anwer) => { }, _nextSceneID);
    }
}
