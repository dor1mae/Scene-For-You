/// <summary>
/// Считает урон за счет характеристики. Может быть расширен
/// </summary>
public class Power : Stat, ICheckDamage<float>
{
    private float multDamage = 5;
    public Power(int value) : base(value)
    {
    }

    public float CheckDamage()
    {
        UnityEngine.Debug.Log($"Пытаюсь отправить физический урон");
        return _value * multDamage;
    }
}
