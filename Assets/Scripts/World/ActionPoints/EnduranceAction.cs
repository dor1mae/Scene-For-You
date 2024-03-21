using System.Collections;
using UnityEngine;


public class EnduranceAction : AbstractActionPoint
{
    public override IEnumerator OnAction(Player pl)
    {
        if (CanItAction(pl, CostOfAction) && IsAvailable())
        {
            pl.Endurance.Upgrade(SizeOfUpgrade);
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
