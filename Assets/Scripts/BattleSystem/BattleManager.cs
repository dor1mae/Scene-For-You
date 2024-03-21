using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private TurnBasedEnemyAI _enemyAI;
    private Enemy _enemy;
    [SerializeField] private Text _enemyName;
    [SerializeField] private Text _enemyPower;

    [SerializeField] private Player _player;
    [SerializeField] private Text _playerName;
    [SerializeField] private Text _playerPower;

    private enum BattleState
    {
        START,
        PLAYER,
        ENEMY,
        WIN,
        LOST
    }

    private BattleState state;

    public void Initialize()
    {
        state = BattleState.START;
        Debug.Log(state);

        _enemy = _enemyAI.GetComponent<Enemy>();

        _playerName.text = _player.Name;
        _playerPower.text = "Power: " + $"{_player.CheckBattlePower()}";

        _enemyName.text = _enemy.Name;
        _enemyPower.text = "Power: " + $"{_enemy.CheckBattlePower()}";

        DiedEnabled();
        TurnedEnabled();

        StartCoroutine(PlayerTurn());
        EventBus.TurnEnded?.Invoke();
    }

    private IEnumerator PlayerTurn()
    {
        _player.NewTurn();

        yield return new WaitForSeconds(.2f);

        state = BattleState.PLAYER;
        Debug.Log(state);

        EventBus.TurnEnded?.Invoke();
    }

    private IEnumerator EnemyTurn()
    {
        Debug.Log("Enemy is thinking");
        yield return new WaitForSeconds(.2f);

        _enemyAI.MakeDecision();

        state = BattleState.ENEMY;
        Debug.Log(state);

        EventBus.TurnEnded?.Invoke();
    }

    private IEnumerator Win()
    {
        state = BattleState.WIN;

        yield return null;
        Debug.Log(state);

        EventBus.TurnEnded?.Invoke();
    }

    private IEnumerator Lost()
    {
        state = BattleState.LOST;

        yield return null;
        Debug.Log(state);

        EventBus.TurnEnded?.Invoke();
    }

    private void OnDied(Unit unit)
    {
        if (unit is Enemy)
        {
            Debug.Log(gameObject.tag + " " + _enemy.Durability.Value);
            StartCoroutine(Win());
        }
        else if (unit is Player)
        {
            Debug.Log(gameObject.tag + " " + _player.Durability.Value);
            StartCoroutine(Lost());
        }
    }

    private void DiedEnabled()
    {
        EventBus.Died += OnDied;
    }

    private void OnTurnedEnemy()
    {
        StartCoroutine(PlayerTurn());
    }

    private void OnTurnedPlayer()
    {
        StartCoroutine(EnemyTurn());
    }

    private void TurnedEnabled()
    {
        _player.Turned += OnTurnedPlayer;
        _enemy.Turned += OnTurnedEnemy;
    }
}
