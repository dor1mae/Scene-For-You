using System;
using UnityEngine;

public class ItemButton : MonoBehaviour
{
    public Action<ItemToUse> Clicked;
    private ItemToUse _item;

    public void SetItemButton(ItemToUse item)
    {
        _item = item;
    }

    public void OnClick()
    {
        if (_item.isUsable == true)
        {
            Debug.Log("ItemButton: " + _item.Name + " ������� ������������ ��� " + _item.isUsable);
            _item.Init();
            Clicked?.Invoke(_item);
        }
        else
        {
            Debug.Log("ItemButton: " + _item.Name + " ������� ��������������� ��� �� ������������");
            return;
        }
    }
}
