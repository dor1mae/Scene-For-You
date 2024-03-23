using System;

public interface IWorkWithScene
{
    void LoadScene(Action<bool> callback = null, int sceneID = default);
    void UnloadScene(Action<bool> callback = null);
}
