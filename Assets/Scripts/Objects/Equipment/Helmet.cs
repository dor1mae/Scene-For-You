using UnityEngine;


[CreateAssetMenu(fileName = "Helmet", menuName = "Items/Equipment/Helmet")]
public class Helmet : ItemToEquip
{
    public override EquipmentType _equipmentType => EquipmentType.Helmet;
    public override void Equip()
    {
        Equipment.EquipHelmet(this);
        Equipment.OnPlayerChecksEquipments?.Invoke();
        Debug.Log($"{GetType()}: is equiped");
    }

    public override void TakeOff()
    {
        Equipment.EquipHelmet(null);
        Equipment.OnPlayerChecksEquipments?.Invoke();
        Debug.Log($"{GetType()}: is taked off");
    }
}
