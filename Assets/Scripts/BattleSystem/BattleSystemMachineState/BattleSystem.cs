using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : InitClass
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Player _player;
    [SerializeField] private TurnManager _turnManager;

    public static Func<Enemy> OnGetEnemy;
    public static Func<Player> OnGetPlayer;

    private Dictionary<Type, IState> _dictStates;
    private IState _currentState;

    public override void Init()
    {
        GameManagerSingltone.Instance.ChangeIsBattle(true);

        OnGetEnemy += GetEnemy;
        OnGetPlayer += GetPlayer;

        _dictStates = new Dictionary<Type, IState>()
        {
            [typeof(BattleSystemPlayerState)] = new BattleSystemPlayerState(this),
            [typeof(BattleSystemEnemyState)] = new BattleSystemEnemyState(this),
            [typeof(BattleSystemLoseState)] = new BattleSystemLoseState(this),
            [typeof(BattleSystemWinState)] = new BattleSystemWinState(this),
            [typeof(BattleSystemActionState)] = new BattleSystemActionState(this, _turnManager)
        };
    }

    public void EnterIn<LevelState>() where LevelState : IState
    {
        if(_dictStates.TryGetValue(typeof(LevelState), out IState state))
        {
            _currentState?.Exit();
            _currentState = state;
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