using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Items/Equipment/Weapon")]
public class Weapon : ItemToEquip, IAttack<float>
{
    [SerializeField] float _damage;
    public override EquipmentType _equipmentType => EquipmentType.Weapon;
    public override void Equip()
    {
        Equipment.EquipWeapon(this);
        Equipment.OnPlayerChecksEquipments?.Invoke();
        Debug.Log($"{GetType()}: is equiped");
    }

    public override void TakeOff()
    {
        Equipment.EquipWeapon(null);
        Equipment.OnPlayerChecksEquipments?.Invoke();
        Debug.Log($"{GetType()}: is taked off");
    }

    public float Attack()
    {
        return _damage;
    }
}
