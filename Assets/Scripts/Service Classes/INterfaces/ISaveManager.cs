using System;

public interface ISaveSystem
{
    public void Save<T>(string key, T save, Action<bool> callback = null);
    public T Load<T>(string key, Action<bool> callback);
}

