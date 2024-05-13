using System;


/// <summary>
/// Уникальный межсценарный класс для сохранения данных об инвентаре
/// </summary>
public static class Equipment
{
    public static Action OnPlayerChecksEquipments;
    //Событие для сравнения надетого и выбранного снаряжения
    public static Func<Tuple<int, int, int, int, int>> OnEquipmentChecksPlayer;

    /// <summary>
    /// Событие для EquipSpriteController
    /// </summary>
    public static Action<ItemToEquip> onSetSprite;

    public static Action onTakeOff;

    private static Helmet _helmet;
    public static Helmet Helmet => _helmet;

    private static Armor _armor;
    public static Armor Armor => _armor;

    private static Pants _pants;
    public static Pants Pants => _pants;

    private static Shoes _shoes;
    public static Shoes Shoes => _shoes;

    private static Gloves _gloves;
    public static Gloves Gloves => _gloves;

    private static Weapon _weapon;
    public static Weapon Weapon => _weapon;


    public static void EquipHelmet(Helmet h)
    {
        _helmet = h;
    }

    public static void EquipArmor(Armor h)
    {
        _armor = h;
    }

    public static void EquipPants(Pants h)
    {
        _pants = h;
    }

    public static void EquipShoes(Shoes h)
    {
        _shoes = h;
    }

    public static void EquipGloves(Gloves h)
    {
        _gloves = h;
    }

    public static void EquipWeapon(Weapon h)
    {
        _weapon = h;
    }

    public static Weapon WeaponStatCheck()
    {
        return _weapon;
    }
}