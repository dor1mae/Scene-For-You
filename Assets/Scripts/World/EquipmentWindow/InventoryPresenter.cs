using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Выводит предметы в поле инвентаря
/// </summary>
public class InventoryPresenter : MonoBehaviour
{
    [SerializeField] private GameObject _containerUI;
    private GameObject _itemPrefab;
    private ItemSearchController _searchController;
    private InformationPanelController _infPanelController;
    private Button _useButton;
    private ItemUseButton _useItemButton;

    public void SetItemPresentController(GameObject itemPrefab,
        ItemSearchController isc, InformationPanelController controller, Button button, ItemUseButton button1)
    {
        _useButton = button;
        _infPanelController = controller;
        _itemPrefab = itemPrefab;
        _searchController = isc;
        _useItemButton = button1;
    }

    public void PresentItems()
    {
        CleanItems();

        var items = _searchController.SearchItems();
        Debug.Log($"Число предметов: {items.Count}");

        foreach (var item in items)
        {
            Debug.Log(item.Item.Name);

            //Создаем новый предмет в инвентаре в виде кнопки
            var itemPrefab = Instantiate(_itemPrefab);
            itemPrefab.transform.SetParent(_containerUI.transform, false);

            //Создаем связь между UI и данными о предмете в инвентаре. Роль ItemPresenter - отвечать за автоматическое удаление предмета.
            var eqPres = itemPrefab.GetComponent<ItemSlotButton>();
            eqPres.SetEquipmentPresenter(item, _infPanelController, _useButton);

            var eqPresButton = eqPres.GetComponent<Button>();
			eqPresButton.onClick.RemoveAllListeners();
			eqPresButton.onClick.AddListener(() =>
            {
				if (GameManagerSingltone.Instance.IsBattle && item.Item is ItemToUse)
				{
					_useItemButton.gameObject.SetActive(true);
					Debug.Log($"Пытаюсь передедать предмет в кнопку активации {item.Item.Name}");
					_useItemButton.SetItem(item);
				}
				else
                {
					_useItemButton.gameObject.SetActive(false);
				}

			});
        }
    }

    private void CleanItems()
    {
        foreach (Transform m in _containerUI.transform)
        {
            Destroy(m.gameObject);
        }
    }
}
