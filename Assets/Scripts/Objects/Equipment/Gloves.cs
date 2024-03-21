using UnityEngine;

[CreateAssetMenu(fileName = "Gloves", menuName = "Items/Equipment/Gloves")]
public class Gloves : ItemToEquip
{
    public override EquipmentType _equipmentType => EquipmentType.Gloves;
    public override void Equip()
    {
        Equipment.EquipGloves(this);
        Equipment.OnPlayerChecksEquipments?.Invoke();
        Debug.Log($"{GetType()}: is equiped");
    }

    public override void TakeOff()
    {
        Equipment.EquipGloves(null);
        Equipment.OnPlayerChecksEquipments?.Invoke();
        Debug.Log($"{GetType()}: is taked off");
    }
}
