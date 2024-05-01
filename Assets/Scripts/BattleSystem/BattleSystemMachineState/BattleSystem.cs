using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : InitClass
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Player _player;
    [SerializeField] private TurnManager _turnManager;
    [SerializeField] private Button _start;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private SkillBook _skillBook;
    [SerializeField] private GameObject _rewardWindow;
    [SerializeField] private Transform _canvas;

    public static Func<Enemy> OnGetEnemy;
    public static Func<Player> OnGetPlayer;

    private Dictionary<Type, IState<BattleSystemStates>> _dictStates;
    private IState<BattleSystemStates> _currentState;

    public BattleSystemStates _currentEnumState;

    private bool _isEnd = false;

    public override void Init()
    {
        GameManagerSingltone.Instance.ChangeIsBattle(true);

        OnGetEnemy += GetEnemy;
        OnGetPlayer += GetPlayer;
        EventBus.Died += OnDied;

        BattleSystemTransfer.Get(out Player player, out Enemy enemy, out List<RealItem> inventory, out List<Skill> skillBook);
        _player.Replace(player);
        _enemy.Replace(enemy);
        _inventory.ReplaceItems(inventory);
        _skillBook.ReplaceItems(skillBook);

        EventBus.onCheck?.Invoke();

        _dictStates = new Dictionary<Type, IState<BattleSystemStates>>()
        {
            [typeof(BattleSystemPlayerState)] = new BattleSystemPlayerState(this, _start, _turnManager),
            [typeof(BattleSystemEnemyState)] = new BattleSystemEnemyState(this, _turnManager),
            [typeof(BattleSystemLoseState)] = new BattleSystemLoseState(this),
            [typeof(BattleSystemWinState)] = new BattleSystemWinState(this, enemy, _rewardWindow, transform),
            [typeof(BattleSystemActionState)] = new BattleSystemActionState(this, _turnManager)
        };

        EnterIn<BattleSystemPlayerState>();
    }

    public void EnterIn<LevelState>() where LevelState : IState<BattleSystemStates>
    {
        if(_dictStates.TryGetValue(typeof(LevelState), out IState<BattleSystemStates> state) && !_isEnd)
        {
            Debug.Log($"{state.GetEnum}");

            _currentState?.Exit();
            _currentState = state;
            _currentEnumState = _currentState.GetEnum;
            _currentState.Enter();
        }
    }

    private void OnDied(Unit unit)
    {
        if(unit is Player)
        {
            EnterIn<BattleSystemLoseState>();
			_isEnd = true;
		}
        else
        {
            EnterIn<BattleSystemWinState>();
            _isEnd = true;
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