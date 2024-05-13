using UnityEngine;
using UnityEngine.UI;

public abstract class BarController : InitClass
{
    [SerializeField] protected Unit _unit;
    [SerializeField] protected Image _bar;

    protected float _maxFill;
    protected float _fill;

    public void OnChanged(float var1, float var2)
    {
        _fill = var1;
        _maxFill = var2;

        DrawFill();
    }

    public void DrawFill()
    {
        _bar.fillAmount = _fill / _maxFill;
    }
}
