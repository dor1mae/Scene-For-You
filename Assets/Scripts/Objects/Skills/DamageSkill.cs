using UnityEngine;

[CreateAssetMenu(fileName = "DamageSkill", menuName = "Skills/SimpleSkill")]

public class DamageSkill : ScriptableSkill
{
    public override void Use(Unit target)
    {
        AttributeDictionary dict = new(target);

        Unit owner;

        if(target is Player)
        {
            owner = BattleSystem.OnGetEnemy?.Invoke();
        }
        else
        { 
            owner = BattleSystem.OnGetPlayer?.Invoke();
        }

        target.Durability.Spend(dict._dict[AttributeType].Value * PowerSkill);
        owner.Intelligence.Spend(CostSkill);
    }
}
