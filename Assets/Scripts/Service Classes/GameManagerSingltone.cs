using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSingltone : MonoBehaviour
{
    [SerializeField] private ScriptableDatabase dataBase;
    public ScriptableDatabase ScriptableDatabase => dataBase;

    private Player _player;

    private Inventory _inventory;

    [SerializeField] private GameObject _worldScene;
    public Inventory Inventory => _inventory;

    private bool _isBattle = false;
    public bool IsBattle => _isBattle;

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

    public Player Player
    {
        get
        {
            SetPlayer();
            return _player;
        }
    }

    public void SetInventory(Inventory inventory)
    {
        _inventory = inventory;
    }

    public void ChangeIsBattle(bool state)
    {
        _isBattle = state;
    }

    public void ChangeStatusWorld(bool state)
    {
        _worldScene.SetActive(state);
    }
}
