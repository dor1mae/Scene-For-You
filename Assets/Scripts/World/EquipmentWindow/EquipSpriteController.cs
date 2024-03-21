﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Контролирует спрайты предметов, надетых героем
/// </summary>
public class EquipSpriteController : InitClass, IEquip
{
    [SerializeField] private Image _helmet;
    [SerializeField] private Image _armor;
    [SerializeField] private Image _pants;
    [SerializeField] private Image _shoes;
    [SerializeField] private Image _gloves;
    [SerializeField] private Image _weapon;

    private Dictionary<EquipmentType, Image> dict;

    public override void Init()
    {
        dict = new Dictionary<EquipmentType, Image>
        {
            {EquipmentType.Helmet, _helmet },
            {EquipmentType.Armor, _armor },
            {EquipmentType.Pants, _pants },
            {EquipmentType.Shoes, _shoes },
            {EquipmentType.Weapon, _weapon },
            {EquipmentType.Gloves, _gloves },
        };

        Equipment.onSetSprite += Equip;
    }

    public void TakeOff(ItemToEquip item)
    {
        dict[item._equipmentType].sprite = null;
    }

    public void Equip(ItemToEquip item)
    {
        dict[item._equipmentType].sprite = item.Icon;
    }

    /// <summary>
    /// Возвращает спрайт-предмет, надетый в экипировке
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public Sprite GetEquipmentSprite(ItemToEquip item)
    {
        return dict[item._equipmentType].sprite;
    }
}