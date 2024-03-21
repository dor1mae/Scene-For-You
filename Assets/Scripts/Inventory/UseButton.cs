using UnityEngine;

public class UseButton : MonoBehaviour
{
    private ItemToUse _item;
    private Unit _target;

    public void OnClick()
    {
        _item.Use(_target);
    }

    public void SetAction(ItemToUse item, Unit target)
    {
        Debug.Log($"UseButton: {target.Name}");
        _item = item;
        _target = target;
    }
}
