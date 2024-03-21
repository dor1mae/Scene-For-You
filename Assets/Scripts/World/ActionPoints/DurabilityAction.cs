using System.Collections;
using UnityEngine;


public class DurabilityAction : AbstractActionPoint
{
    public override IEnumerator OnAction(Player pl)
    {
        if (CanItAction(pl, CostOfAction) && IsAvailable())
        {
            pl.Durability.Upgrade(_sizeOfUpgrade);
            pl.Endurance.Spend(_sizeOfUpgrade);
            ActionDone.Invoke();

            Debug.Log($"{this.GetType()}: Action is done");

            yield return null;
        }
        else
        {
            Debug.Log($"{this.GetType()}: Action is not done");

            yield return null;
        }
    }

    public override void OnNpcAction()
    {
        throw new System.NotImplementedException();
    }
}
