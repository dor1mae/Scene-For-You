using UnityEngine;

public class ItemUseButton : MonoBehaviour
{
    [SerializeField] private PlayerCommandClient command;
    private RealItem _item;

    public void SetItem(RealItem item)
    {
        _item = item;
    }

    public void UseItem()
    {
        command.AddItemCommand(_item);
    }
}