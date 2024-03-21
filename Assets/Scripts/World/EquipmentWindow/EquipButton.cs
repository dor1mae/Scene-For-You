using UnityEngine;


/// <summary>
/// Контролирует кнопку надевания экипировки
/// </summary>
public class EquipButton : InitClass, IEquip<RealItem>
{
    [SerializeField] SpriteChanger _equipSpriteController;

    private RealItem _item;

    public void SetItem(RealItem item)
    {
        _item = item;
    }

    public override void Init()
    {
        _equipSpriteController.Init();

    }

    public void Equip(RealItem item)
    {
        item.Equip();
        _equipSpriteController.Equip(item.Item as ItemToEquip);
    }

    public void TakeOff(RealItem item)
    {
        item.TakeOff();
        _equipSpriteController.TakeOff(item.Item as ItemToEquip);
    }

    public void OnClick()
    {
        if (_item.Item.Icon == _equipSpriteController.GetEquipmentSprite(_item.Item as ItemToEquip))
        {
            TakeOff(_item);
        }
        else
        {
            Equip(_item);
        }
    }
}
