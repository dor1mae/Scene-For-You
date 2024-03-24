using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Save
{
    private PlayerContainer _playerContainer;

    [JsonIgnore]
    private List<IContainer> _containerList;

    public Save()
    {
        _playerContainer = new PlayerContainer(GameManagerSingltone.Instance.Player, GameManagerSingltone.Instance.Inventory);
    }

    [JsonConstructor]
    public Save(PlayerContainer playerContainer)
    {
        _playerContainer = playerContainer;

        _containerList = new List<IContainer>();
        FillList();
    }

    private void FillList()
    {
        _containerList.Add(_playerContainer as IContainer);
    }

    public void Load()
    {
        foreach(var item in _containerList)
        {
            item.Load();
        }
    }
}
