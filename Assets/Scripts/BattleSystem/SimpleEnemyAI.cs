using UnityEngine;

// ИИ, который учитывает такие показатели, как собственные очки выносливости, здоровья и маны, чтобы принимать
// решения. На данный момент представляет больше затычковый характер, очень плох в бою.
public class SimpleEnemyAI : TurnBasedEnemyAI
{
    [SerializeField] private EnemyCommandClient _enemyClient;
    public override void MakeDecision()
    {
        RatePlayerHP();
        RateSelfHP();
        RateSelfMP();
        RateSelfST();

        Debug.Log("Makes desicion");
        switch ((_selfHP, _selfMP, _selfST, _playerHP))
        {
            case ( > 0, > 0, > 0, 1f):
                Choice(1);
                break;

            case (0.5f, 0.5f, 0.5f, > 0):
                Choice(UnityEngine.Random.Range(1, 3));
                break;

            case (0.5f, > 0, > 0, > 0):
                if (UnityEngine.Random.Range(0, 100) > 50)
                {
                    Choice(2);
                }
                else
                {
                    Choice(UnityEngine.Random.Range(1, 2));
                }
                break;

            case ( > 0, > 0, 0.5f, > 0):
                if (UnityEngine.Random.Range(0, 100) > 50)
                {
                    Choice(3);
                }
                else
                {
                    Choice(UnityEngine.Random.Range(1, 3));
                }
                break;

            default:
                Choice(1);
                break;
        }
    }

    protected override void RatePlayerHP()
    {
        var t = _player.Durability.Bar;

        switch (t)
        {
            case > 0 when t < _self.Power.Value * 5:
                _playerHP = 1f;
                break;

            case > 0 when t * 2 < _player.Durability.MaxBar:
                _playerHP = 0.5f;
                break;

            default:
                _playerHP = 0.1f;
                break;
        }

    }

    protected override void RateSelfHP()
    {
        var t = _self.Durability.Bar;

        switch (t)
        {
            case > 0 when t * 2 < _self.Durability.MaxBar:
                _selfHP = 0.5f;
                break;

            default:
                _selfHP = 0.1f;
                break;
        }
    }

    protected override void RateSelfMP()
    {
        var t = _self.Intelligence.Bar;

        switch (t)
        {
            case > 0 when t * 2 < _self.Intelligence.MaxBar:
                _selfMP = 0.5f;
                break;

            default:
                _selfMP = 0.1f;
                break;
        }
    }

    protected override void RateSelfST()
    {
        var t = _self.Endurance.Bar;

        switch (t)
        {
            case > 0 when t * 2 < _self.Endurance.MaxBar:
                _selfST = 0.5f;
                break;

            default:
                _selfST = 0.1f;
                break;
        }
    }

    protected void Choice(int c)
    {
        Debug.Log("Choice is " + c);
        switch (c)
        {
            case 1:
                _enemyClient.AddSimpleAttackCommand();
                return;

            case 2:
                _enemyClient.AddSkipCommand();
                return;

            case 3:
                _enemyClient.AddSimpleAttackCommand();
                return;
        }
    }
}
