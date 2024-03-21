using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "StaminaPotion", menuName = "Items/Potions/StaminaPotion")]
public class StaminaPotion : Potion
{
    protected static int _timeOfResetStamina = 0;
    public override bool IsHarmful => false;

    public override void Use(Unit go)
    {
        go.Endurance.Restore(_powerOfEffect);
    }

    protected override void OnTurnEnded()
    {
        if (_timeOfResetStamina > 0)
        {
            _timeOfResetStamina--;
        }
    }

    public override ActionData GetActionData()
    {
        return new ActionData(Use);
    }
}
