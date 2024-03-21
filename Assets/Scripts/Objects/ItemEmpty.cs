using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/SimpleItem")]
public class Item : ItemEmpty
{
    //Дает возможность отличать используемые предметы от других для инвентаря во время боя
    public override bool isUsable => false;

    public override EquipmentType _equipmentType => EquipmentType.Item;
}
