using UnityEngine;

[CreateAssetMenu(fileName = "Shoes", menuName = "Items/Equipment/Shoes")]
public class Shoes : ItemToEquip
{
    public override EquipmentType _equipmentType => EquipmentType.Shoes;
    public override void Equip()
    {
        Equipment.EquipShoes(this);
        Equipment.OnPlayerChecksEquipments?.Invoke();
        Debug.Log($"{GetType()}: is equiped");
    }

    public override void TakeOff()
    {
        Equipment.EquipShoes(null);
        Equipment.OnPlayerChecksEquipments?.Invoke();
        Debug.Log($"{GetType()}: is taked off");
    }
}
