using System.Collections;
using UnityEngine;


public class DexterityAction : AbstractActionPoint
{
    public override IEnumerator OnAction(Player pl)
    {
        if (CanItAction(pl, CostOfAction) && IsAvailable())
        {
            pl.Dexterity.Upgrade(_sizeOfUpgrade);
            pl.Endurance.Spend(CostOfAction);
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
