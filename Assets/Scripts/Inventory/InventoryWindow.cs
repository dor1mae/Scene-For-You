using UnityEngine;

public class InventoryWindow : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private GameObject _containerUI;
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private UseButton _useButton;
    [SerializeField] private Unit _player;
    [SerializeField] private Unit _enemy;
    private Animator _animator;

    public void Init()
    {
        _inventory.Init();
        _animator = GetComponent<Animator>();

        PresentItems();
    }

    //Использование предмета через Инвентарь и событие
    private void SetListener(ItemToUse item)
    {
        if (item.IsHarmful)
        {
            _useButton.SetAction(item, _enemy);
        }
        else
        {
            _useButton.SetAction(item, _player);
        }
    }

    private void PresentItems()
    {
        var items = _inventory.GetItems();
        Debug.Log($"Число предметов: {items.Count}");

        foreach (var item in items)
        {
            Debug.Log(item.Item.Name);

            //Создаем новый предмет в инвентаре в виде кнопки
            var itemPrefab = Instantiate(_itemPrefab);
            itemPrefab.transform.SetParent(_containerUI.transform, false);

            //Переносим данные о предмете на созданный компонент в инвентаре
            //itemPrefab

            //Создаем связь между UI и данными о предмете в инвентаре. Роль ItemPresenter - отвечать за автоматическое удаление предмета.
            var itemPres = itemPrefab.GetComponent<ItemPresenter>();
            itemPres.SetItemPresenter(item.Item);
            itemPres.AttachItem();

            //Связываем SetListener с Clicked, чтобы при выборе предмета кнопка Использовать относилась к выбранному предмету
            var itemBut = itemPrefab.GetComponent<ItemButton>();
            itemBut.SetItemButton(item.Item as ItemToUse);
            itemBut.Clicked += SetListener;
        }
    }

    //Обе функции корутинами
    public void OpenInventoryOnClick()
    {
        _animator.SetBool("IsOpened", true);
        //this.gameObject.SetActive(true);
    }

    public void CloseInventoryOnClick()
    {
        _animator.SetBool("IsOpened", false);
        //this.gameObject.SetActive(false);
    }
}
