using UnityEngine;

public class BootstrapBattleSystem : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Player _player;
    [SerializeField] private ManaBarController _enemyManaBar;
    [SerializeField] private ManaBarController _playerManaBar;
    [SerializeField] private StaminaBarController _enemyStaminaBar;
    [SerializeField] private StaminaBarController _playerStaminaBar;
    [SerializeField] private HealthBarController _enemyHealthBar;
    [SerializeField] private HealthBarController _playerHealthBar;
    [SerializeField] private BattleManager _battleManager;
    [SerializeField] private SimpleEnemyAI _simpleEnemyAI;
    [SerializeField] private InventoryWindow _inventory;

    void Start()
    {
        _enemy.Init();
        _player.Init();

        _enemyManaBar.Initialize();
        _playerManaBar.Initialize();
        _enemyStaminaBar.Initialize();
        _playerStaminaBar.Initialize();
        _enemyHealthBar.Initialize();
        _playerHealthBar.Initialize();

        _inventory.Init();

        _battleManager.Initialize();
        _simpleEnemyAI.Initialize();
    }
}
