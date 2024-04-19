using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : InitClass
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Player _player;
    [SerializeField] private TurnManager _turnManager;
    [SerializeField] private Button _start;

    public static Func<Enemy> OnGetEnemy;
    public static Func<Player> OnGetPlayer;

    private Dictionary<Type, IState<BattleSystemStates>> _dictStates;
    private IState<BattleSystemStates> _currentState;

    public BattleSystemStates _currentEnumState;

    public override void Init()
    {
        GameManagerSingltone.Instance.ChangeIsBattle(true);

        OnGetEnemy += GetEnemy;
        OnGetPlayer += GetPlayer;

        _dictStates = new Dictionary<Type, IState<BattleSystemStates>>()
        {
            [typeof(BattleSystemPlayerState)] = new BattleSystemPlayerState(this, _start, _turnManager),
            [typeof(BattleSystemEnemyState)] = new BattleSystemEnemyState(this, _turnManager),
            [typeof(BattleSystemLoseState)] = new BattleSystemLoseState(this),
            [typeof(BattleSystemWinState)] = new BattleSystemWinState(this),
            [typeof(BattleSystemActionState)] = new BattleSystemActionState(this, _turnManager)
        };

        EnterIn<BattleSystemPlayerState>();
    }

    public void EnterIn<LevelState>() where LevelState : IState<BattleSystemStates>
    {
        if(_dictStates.TryGetValue(typeof(LevelState), out IState<BattleSystemStates> state))
        {
            Debug.Log($"{state.GetEnum}");

            _currentState?.Exit();
            _currentState = state;
            _currentEnumState = _currentState.GetEnum;
            _currentState.Enter();
        }
    }

    private Enemy GetEnemy()
    {
        return _enemy;
    }

    private Player GetPlayer()
    {
        return _player;
    }
}