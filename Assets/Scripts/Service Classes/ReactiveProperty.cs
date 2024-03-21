using System;

public class ReactiveProperty<T>
{
    public Action<T> OnChange;

    public T _value;

    public T Value
    {
        get { return _value; }
        set
        {
            _value = value;
            OnChange?.Invoke(_value);
        }
    }
}
