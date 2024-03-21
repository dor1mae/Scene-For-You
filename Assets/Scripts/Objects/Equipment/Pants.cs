using UnityEngine;

[CreateAssetMenu(fileName = "Pants", menuName = "Items/Equipment/Pants")]
public class Pants : ItemToEquip
{
    public override EquipmentType _equipmentType => EquipmentType.Pants;
    public override void Equip()
    {
        Equipment.EquipPants(this);
        Equipment.OnPlayerChecksEquipments?.Invoke();
        Debug.Log($"{GetType()}: is equiped");
    }

    public override void TakeOff()
    {
        Equipment.EquipPants(null);
        Equipment.OnPlayerChecksEquipments?.Invoke();
        Debug.Log($"{GetType()}: is taked off");
    }
}
