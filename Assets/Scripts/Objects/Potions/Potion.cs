using UnityEngine;

public abstract class Potion : ItemToUse
{
    public override EquipmentType _equipmentType => EquipmentType.Potion;
    public override void Init()
    {
        EventBus.TurnEnded += OnTurnEnded;
    }
    protected abstract void OnTurnEnded();

    [SerializeField] protected float _powerOfEffect;
}
