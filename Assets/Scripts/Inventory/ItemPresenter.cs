using UnityEngine;
using UnityEngine.UI;

public class ItemPresenter : MonoBehaviour
{
    private ItemEmpty _item;
    private GameObject _itemContainer;

    [SerializeField] private Text _name;
    [SerializeField] private Image _spriteOfObject;
    [SerializeField] private Text _numberOfItems;

    public void SetItemPresenter(ItemEmpty item)
    {
        _item = item;
        _name.text = item.Name;
        _spriteOfObject.sprite = item.Icon;
        _itemContainer = this.gameObject;
        //numberOfItems.text = $"{_item.NumberOfItems}/{_item.MaxNumberOfItems}";
    }

    //Метод, который связывает Объект в памяти с его представлением в инвентаре для проверки его числа
    public void AttachItem()
    {
        Debug.Log("ItemPresenter: " + $"{_item.Name}");
        //_item._numberOfItems.OnChange += _item.CheckNumber;
        //_item._numberOfItems.OnChange += ChangeNumberOfItem;
        //_item.Ended += DeleteSelf;
    }

    //Вызывается, когда предмет кончается
    public void DeleteSelf()
    {
        Destroy(_itemContainer);
    }

    public void ChangeNumberOfItem(int newNumber)
    {
        _numberOfItems.text = $"{newNumber}/{_item.MaxNumberOfItems}";
    }
}
