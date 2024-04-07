using System;

public static class EventBus
{
    /// <summary>
    /// ����� ������� �������
    /// </summary>
    public static Action<DialoguesObject> DialogStarted;

    /// <summary>
    /// ����� �� ����� �������
    /// </summary>
    public static Action Choiced;

    /// <summary>
    /// ��������� ���
    /// </summary>
    public static Action<Unit> Died;

    /// <summary>
    /// ��������� ����. ������ ��� ����� ������, ��� ����������� ������������
    /// </summary>
    public static Action TurnEnded;

    /// <summary>
    /// ����������, ����� �������� DateManager � ���������� ����� ��������������
    /// </summary>
    public static Action<AbstractActionPoint> onActionReady;

    /// <summary>
    /// ������ ���������� �� ����� ���
    /// </summary>
    public static Func<Enemy> onGetEnemy;

    /// <summary>
    /// ������ ������ �� ����� ��� ��� ���� ������������
    /// </summary>
    public static Func<Player> onGetPlayer;

    /// <summary>
    /// ���������� ��� ��������� ����������, ����� ������� ������� ��������� ��������������� �� ������������� � ������ Equipment
    /// </summary>
    public static Action<ItemToEquip> onSpriteEquip;

    /// <summary>
    /// ������� ��� �������� �����
    /// </summary>
    public static Func<Tuple<float, float>> onCheckDamage;

    /// <summary>
    /// ��� ������������ �������� ������ �������� ������ � ���, ����� ����� ����� ���������
    /// </summary>
    public static Func<Tuple<int, int>> onTransferSceneKey;

}
