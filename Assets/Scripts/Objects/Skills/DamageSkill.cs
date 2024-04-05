using UnityEngine;

[CreateAssetMenu(fileName = "DamageSkill", menuName = "Skills/SimpleSkill")]

public class DamageSkill : ScriptableSkill
{
    public override void Use(Unit owner)
    {
        AttributeDictionary dict = new(owner);

        Unit target;

        if(owner is Player)
        {
            target = EventBus.onGetEnemy?.Invoke();
        }
        else
        { 
            target = EventBus.onGetPlayer?.Invoke();
        }

        target.Durability.Spend(dict._dict[AttributeType].Value * PowerSkill);
        owner.Intelligence.Spend(CostSkill);
    }
}
