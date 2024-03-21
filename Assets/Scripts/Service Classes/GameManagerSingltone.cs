using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSingltone : MonoBehaviour
{
    [SerializeField] private ScriptableDatabase dataBase;
    public ScriptableDatabase ScriptableDatabase => dataBase;

    private Player _player;
    public Player Player
    { 
        get
        {
            SetPlayer();
            return _player;
        }
    }

    private Inventory _inventory;
    public Inventory Inventory => _inventory;

    public static GameManagerSingltone Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);

            Debug.Log($"{GetType()}: is initialized");

            return;
        }
        Destroy(this.gameObject);
    }

    public void SetPlayer()
    {
        _player = EventBus.onGetPlayer();
    }

    public void SetInventory(Inventory inventory)
    {
        _inventory = inventory;
    }

}
