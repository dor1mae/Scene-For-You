using UnityEngine;

[CreateAssetMenu(fileName = "Armor", menuName = "Items/Equipment/Armor")]
public class Armor : ItemToEquip
{
    public override EquipmentType _equipmentType => EquipmentType.Armor;

    public override void Equip()
    {
        Equipment.EquipArmor(this);
        Equipment.OnPlayerChecksEquipments?.Invoke();
        Debug.Log($"{GetType()}: is equiped");
    }

    public override void TakeOff()
    {
        Equipment.EquipArmor(null);
        Equipment.OnPlayerChecksEquipments?.Invoke();
        Debug.Log($"{GetType()}: is taked off");
    }
}