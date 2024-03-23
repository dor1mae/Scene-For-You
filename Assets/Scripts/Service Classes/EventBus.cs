using System;

public static class EventBus
{
    /// <summary>
    /// Вызов системы диалога
    /// </summary>
    public static Action<DialoguesObject> DialogStarted;

    /// <summary>
    /// Выбор во время диалога
    /// </summary>
    public static Action Choiced;

    /// <summary>
    /// Окончание боя
    /// </summary>
    public static Action<Unit> Died;

    /// <summary>
    /// Окончание хода. Служит для таких систем, как перезарядка способностей
    /// </summary>
    public static Action TurnEnded;

    /// <summary>
    /// Вызывается, чтобы сообщить DateManager о готовности точки взаимодействия
    /// </summary>
    public static Action<AbstractActionPoint> onActionReady;

    /// <summary>
    /// Запрос противника во время боя
    /// </summary>
    public static Func<Enemy> onGetEnemy;

    /// <summary>
    /// Запрос игрока во время боя или иной деятельности
    /// </summary>
    public static Func<Player> onGetPlayer;

    /// <summary>
    /// Вызывается при подгрузке сохранения, чтобы спрайты надетых предметов соответствовали их представлению в классе Equipment
    /// </summary>
    public static Action<ItemToEquip> onSpriteEquip;

    /// <summary>
    /// Событие для проверки урона
    /// </summary>
    public static Func<Tuple<float, float>> onCheckDamage;

    /// <summary>
    /// Для межсценарной передачи экрану загрузки данных о том, какую сцену нужно загружать
    /// </summary>
    public static Func<Tuple<int, int>> onTransferSceneKey;

}
