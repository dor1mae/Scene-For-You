using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;

public class JsonFileToStorageSaveManager : ISaveSystem
{
    public T Load<T>(string key, Action<bool> callback)
    {
        var pathString = BuildPath(key);

        using (var fileStream = new StreamReader(pathString))
        {
            var json = fileStream.ReadToEnd();

            var data = JsonConvert.DeserializeObject<T>(json);

            callback?.Invoke(true);
            return data;
        }
    }

    public void Save<T>(string key, T save, Action<bool> callback = null)
    {
        var pathString = BuildPath(key);
        var json = JsonConvert.SerializeObject(save);

        using (var fileStream = new StreamWriter(pathString))
        {
            fileStream.Write(json);

            callback?.Invoke(true);
        }
    }

    private string BuildPath(string key)
    {
        return Path.Combine(Application.persistentDataPath, key);
    }
}

