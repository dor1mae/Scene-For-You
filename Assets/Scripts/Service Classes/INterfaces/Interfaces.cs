using System;
using System.Collections;

public interface IPoint
{
    public bool IsAvailable();
}

public interface IAction
{
    public IEnumerator OnAction(Player pl);
}

public interface IActionPoint : IAction, IPoint
{
    // Функия для действия НПС
    public void OnNpcAction();
    public bool CanItAction(Player pl, float cost);
}

public interface IItem
{
    public int Sell();
    public Tuple<int, ItemEmpty> Buy();
}

public interface IGetStats
{
    public Tuple<int, int, int, int, int> GetStats();
}

/// <summary>
/// Интерфейс всех классов, которые выполняют свои или чужие функции экипировки предметов
/// </summary>
public interface IEquip<T>
{
    public void Equip(T item);
    public void TakeOff(T item);
}


public interface IItemToEquip : IGetStats
{
}

public interface IInit
{
    public void Init();
}

public interface IUpgrade<T>
{
    public void Upgrade(T value);
}

public interface IDowngrade<T>
{
    public void Downgrade(T value);
}

public interface IRestore<T>
{
    public void Restore(T value);
}

public interface ISpend<T>
{
    public void Spend(T value);
}

public interface ISync<T1, T2>
{
    public Action<T1, T2> isChanged { get; }
    public void Sync();
}

public interface IAttack<T>
{
    public T Attack();
}


