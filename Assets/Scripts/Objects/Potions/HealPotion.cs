using System;
using UnityEngine;

[CreateAssetMenu(fileName = "HealPotion", menuName = "Items/Potions/HealPotion")]
[Serializable]
public class HealPotion : Potion
{
    protected static int _timeOfResetHeal = 0;
    public override bool IsHarmful => false;

    public override void Use(Unit go)
    {
        go.Durability.Restore(_powerOfEffect);
    }

    protected override void OnTurnEnded()
    {
        if (_timeOfResetHeal > 0)
        {
            _timeOfResetHeal--;
        }
    }

    public override ActionData GetActionData()
    {
        return new ActionData(Use);
    }
}
