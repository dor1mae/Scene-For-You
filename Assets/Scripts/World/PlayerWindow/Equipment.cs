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

    private static Helmet _helmet;
    private static Armor _armor;
    private static Pants _pants;
    private static Shoes _shoes;
    private static Gloves _gloves;
    private static Weapon _weapon;



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

    /// <summary>
    /// Возвращает оружие для сверки характеристик
    /// </summary>
    /// <returns></returns>
    public static Weapon WeaponStatCheck()
    {
        return _weapon;
    }

    /// <summary>
    /// _power, _durability, _endurance, _dexterity, _intelligence
    /// </summary>
    /// <returns></returns>
    public static Tuple<int, int, int, int, int> CheckEquipmentStats()
    {
        ItemToEquip[] _temp = new ItemToEquip[] { _helmet, _armor, _shoes, _pants, _gloves, _weapon };

        int _power = 0;
        int _durability = 0;
        int _endurance = 0;
        int _dexterity = 0;
        int _intelligence = 0;

        foreach (var t in _temp)
        {
            Tuple<int, int, int, int, int> tempTuple = t.GetStats();

            _power += tempTuple.Item1;
            _durability += tempTuple.Item2;
            _endurance += tempTuple.Item3;
            _dexterity += tempTuple.Item4;
            _intelligence += tempTuple.Item5;
        }

        return new Tuple<int, int, int, int, int>(_power, _durability, _endurance, _dexterity, _intelligence);
    }
}