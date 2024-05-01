using System;

public static class EventBus
{
    public static Action<DialoguesObject> DialogStarted;

    public static Action Choiced;

    public static Action<Unit> Died;

    public static Action TurnEnded;

    public static Action<AbstractActionPoint> onActionReady;

    public static Func<Enemy> onGetEnemy;

    public static Func<Player> onGetPlayer;

    public static Action<ItemToEquip> onSpriteEquip;

    public static Func<Tuple<float, float>> onCheckDamage;

    public static Func<Tuple<int, int>> onTransferSceneKey;

    public static Action onCheck;

    public static Func<Inventory> onGetInventory;

    public static Func<SkillBook> onGetSkillBook;
}
