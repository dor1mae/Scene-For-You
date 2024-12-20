﻿using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Содержит все данные, подготовленные для сохранения, классов Player и Inventory
/// </summary>
[Serializable]
public class PlayerContainer : IContainer
{
    public string Name;

    public int StatDurability;
    public int StatEndurace;
    public int StatIntelligence;
    public int StatPower;
    public int StatDexterity;

    [JsonIgnore]
    private Inventory Inventory;

    public List<RealItem> _inventory;

    public PlayerContainer(Player player, Inventory inv)
    {
        Name = player.Name;
        StatDurability = player.Durability.Value;
        StatEndurace = player.Endurance.Value;
        StatIntelligence = player.Intelligence.Value;
        StatPower = player.Power.Value;
        StatDexterity = player.Dexterity.Value;
        Inventory = inv;
        _inventory = Inventory.GetItems();
    }

    [JsonConstructor]
    public PlayerContainer(string Name, int Durability, int Endurance, int Intelligence, int Power, int Dexterity, List<RealItem> inv)
    {
        this.Name = Name;
        StatDurability = Durability;
        StatEndurace = Endurance;
        StatIntelligence = Intelligence;
        StatPower = Power;
        StatDexterity = Dexterity;
        _inventory = inv;

        Inventory = GameManagerSingltone.Instance.Inventory;
    }

    public void Load()
    {
        foreach(var item in _inventory)
        {
            UnityEngine.Debug.Log($"{item.ItemID} : {item.IsEquiped} : {item.NumberOfItems}");
        }

        UnityEngine.Debug.Log($"LoadPlayer()");
        LoadPlayer();

        UnityEngine.Debug.Log($"LoadInventory()");
        LoadInventory();
    }

    private void LoadPlayer()
    {
        Dictionary<string, int> dict = new Dictionary<string, int>()
        {
            {"Power", StatPower },
            {"Dexterity", StatDexterity },
            { "Endurance", StatEndurace},
            {"Intelligence", StatIntelligence },
            {"Durability", StatDurability }
        };

        GameManagerSingltone.Instance.Player.LoadSave(new Tuple<Dictionary<string, int>, string>(dict, Name), (flag) =>
        {
            if(flag)
            {
                UnityEngine.Debug.Log($"{GetType()} : Player is loaded");
            }
        });
    }

    private void LoadInventory()
    {
        GameManagerSingltone.Instance.Inventory.InventoryLoader.LoadSave(_inventory, (flag) =>
        {
            if (flag)
            {
                UnityEngine.Debug.Log($"{GetType()} : Inventory is loaded");
            }
        });
    }
}
