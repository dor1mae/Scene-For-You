using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Save
{
    [JsonIgnore]
    private string _saveName;
    [JsonIgnore]
    private string _saveDate;
    [JsonIgnore]
    private string _playerName;
    public string SaveName => _saveName;
    public string SaveDate => _saveDate;
    public string PlayerName => _playerName;
    [JsonProperty("playerContainer")]
    public PlayerContainer _playerContainer;

    [JsonIgnore]
    private List<IContainer> _containerList;

    public Save(string saveName)
    {
        _saveName = saveName;
        _saveDate = $"{DateTime.Now.Year}:{DateTime.Now.Day}:{DateTime.Now.Hour}";
        _playerName = GameManagerSingltone.Instance.Player.Name;

        _playerContainer = new PlayerContainer(GameManagerSingltone.Instance.Player, GameManagerSingltone.Instance.Inventory);
    }

    [JsonConstructor]
    public Save(string SaveName, string SaveDate, string PlayerName, PlayerContainer playerContainer)
    {
        _saveName = SaveName;
        _saveDate = SaveDate;
        _playerName = PlayerName;
        _playerContainer = playerContainer;

        _containerList = new List<IContainer>();
        FillList();
    }

    private void FillList()
    {
        _containerList.Add(_playerContainer as IContainer);

        Debug.Log($"{_playerContainer.Name} передан успешно");
    }

    public void Load(Action<bool> callback = null)
    {
        foreach(var item in _containerList)
        {
            item.Load();
        }

        callback?.Invoke(true);
    }
}
