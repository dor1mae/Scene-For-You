using System;

public interface IItem
{
    public int Sell();
    public Tuple<int, ItemEmpty> Buy();
}
