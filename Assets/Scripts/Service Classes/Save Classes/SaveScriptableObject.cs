using System;
using UnityEngine;

/// <summary>
/// Класс-ссылка на реальное сохранение игрока
/// </summary>
public class SaveScriptableObject : ScriptableObject
{
    private string _saveName;
    private string _saveDate;
    private string _playerName;
    public string SaveName => _saveName;
    public string SaveDate => _saveDate;
    public string PlayerName => _playerName;

    public void SetSave(string saveName)
    {
        _saveName = saveName;
        _saveDate = $"{DateTime.Now.Year}:{DateTime.Now.Day}:{DateTime.Now.Hour}";

        _playerName = GameManagerSingltone.Instance.Player.Name;

        JsonFileToStorageSaveManager json = new JsonFileToStorageSaveManager();
        json.Save<Save>(_saveName, new Save(), (a) =>
        {
            if (a)
            {
                Debug.Log("Сохранение удалось");
            }
        });
    }

    public void Load(Action<bool> callback = null)
    {
        JsonFileToStorageSaveManager json = new JsonFileToStorageSaveManager();
        var save = json.Load<Save>(_saveName, (a) =>
        {
            if (a)
            {
                Debug.Log("Загрузка удалась");
            }
        });

        save.Load();
        callback?.Invoke(true);
    }
}

