using System;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Определяет тип урона, считает его и возвращает
/// </summary>
public class AttackController : IAttack<float>
{
    private Intelligence _intelligence;
    private Power _power;
    private Dexterity _dexterity;

    private AttackType _attackType = AttackType.Phys;
    public AttackType AttackType => _attackType;

    public AttackController(Intelligence intelligence, Dexterity dexterity, Power power)
    {
        _intelligence = intelligence;
        _power = power;
        _dexterity = dexterity;

        EventBus.onCheckDamage += Sync;
    }

    public float Attack()
    {
        switch (AttackType)
        {
            case AttackType.Phys:
                return AttackPhys();

            case AttackType.Magic:
                return AttackMagic();
            
            default: return 0f;
        }
    }

    private float AttackPhys()
    {
        return _dexterity.CheckCrit() * _power.CheckDamage();
    }

    private float AttackMagic() 
    {
        return _dexterity.CheckCrit() * _intelligence.CheckDamage();
    }

    public void ChangeAttackType(AttackType attackType)
    {
        _attackType = attackType;
    }

    public Tuple<float, float> Sync()
    {
        UnityEngine.Debug.Log($"Пытаюсь отправить данные");
        float phys = GameManagerSingltone.Instance.Player.Power.CheckDamage();
        float magic = GameManagerSingltone.Instance.Player.Intelligence.CheckDamage();

        return new Tuple<float, float>(phys, magic);
    }
}