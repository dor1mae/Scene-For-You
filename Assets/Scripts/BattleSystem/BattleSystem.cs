using System;
using System.Collections;
using UnityEngine;

public class BattleSystem : InitClass
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Player _player;

    public static Func<Enemy> OnGetEnemy;
    public static Func<Player> OnGetPlayer;

    public override void Init()
    {
        OnGetEnemy += GetEnemy;
        OnGetPlayer += GetPlayer;
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