using UnityEngine;

public abstract class TurnBasedEnemyAI : InitClass
{
    protected Enemy _self;
    protected Player _player;

    //����������� ��������� ��� ������
    protected float _selfHP;
    protected float _selfMP;
    protected float _selfST;

    //��������� ��������� ��� ������
    protected float _playerHP;

    protected abstract void RateSelfMP();

    protected abstract void RateSelfHP();

    protected abstract void RateSelfST();

    protected abstract void RatePlayerHP();

    public override void Init()
    {
        _self = GetComponentInParent<Enemy>();
        _player = GameManagerSingltone.Instance.Player;
    }

    public abstract void MakeDecision();
}
