using UnityEngine;

public abstract class TurnBasedEnemyAI : MonoBehaviour
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

    public void Initialize()
    {
        _self = GetComponent<Enemy>();
        _player = EventBus.onGetPlayer.Invoke();
    }

    public abstract void MakeDecision();
}
