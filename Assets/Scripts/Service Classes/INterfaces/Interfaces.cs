using System;
using System.Collections;



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


