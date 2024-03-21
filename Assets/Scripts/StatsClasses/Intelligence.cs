/// <summary>
/// Мана
/// </summary>
public class Intelligence : StatWithBar, ICheckDamage<float>
{
    private float multDamage = 5;
    public Intelligence(int value, float mult = 25f) : base(value, mult)
    {
    }

    public float CheckDamage()
    {
        UnityEngine.Debug.Log($"Пытаюсь отправить магический урон");
        return _value * multDamage;
    }
}
