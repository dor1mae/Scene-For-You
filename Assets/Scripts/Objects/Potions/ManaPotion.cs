using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "ManaPotion", menuName = "Items/Potions/ManaPotion")]
public class ManaPotion : Potion
{
    protected static int _timeOfResetMana = 0;
    public override bool IsHarmful => false;

    public override void Use(Unit go)
    {
        go.Intelligence.Restore(_powerOfEffect);
    }

    protected override void OnTurnEnded()
    {
        if (_timeOfResetMana > 0)
        {
            _timeOfResetMana--;
        }
    }

    public override ActionData GetActionData()
    {
        return new ActionData(Use);
    }
}
