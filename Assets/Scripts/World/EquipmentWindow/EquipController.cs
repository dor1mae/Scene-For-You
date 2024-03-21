using UnityEngine;


/// <summary>
/// Контролирует кнопку надевания экипировки
/// </summary>
public class EquipController : InitClass, IEquip
{
    [SerializeField] EquipSpriteController _equipSpriteController;

    private ItemToEquip _item;

    public void SetItem(ItemToEquip item)
    {
        _item = item;
    }

    public override void Init()
    {
        _equipSpriteController.Init();

    }

    public void Equip(ItemToEquip item)
    {
        item.Equip();
        _equipSpriteController.Equip(item);
    }

    public void TakeOff(ItemToEquip item)
    {
        item.TakeOff();
        _equipSpriteController.TakeOff(item);
    }

    public void OnClick()
    {
        if (_item.Icon == _equipSpriteController.GetEquipmentSprite(_item))
        {
            TakeOff(_item);
        }
        else
        {
            Equip(_item);
        }
    }
}
