using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotButton : MonoBehaviour
{
    private RealItem _item;

    //Поля кнопки
    [SerializeField] private Text _name;
    [SerializeField] private Image _spriteOfObject;
    [SerializeField] private Text _numberOfItems;

    private Button _useButton;
    private InformationPanelController _controller;
    private ReactiveProperty<bool> _isEquiped;
    private Action<ItemEmpty> Clicked;

    public void SetEquipmentPresenter(RealItem item, InformationPanelController controller, Button button)
    {
        //Информационная панель
        _controller = controller;
        Clicked += _controller.SetInformationPanel;

        //EquipController
        _useButton = button;

        _item = item;

        _name.text = item.Item.Name;
        _spriteOfObject.sprite = item.Item.Icon;
        //_numberOfItems.text = $"{_item.NumberOfItems}/{_item.MaxNumberOfItems}";

        Debug.Log($"{GetType()}: SetEquipmentPresenter : {item.Item.Name} is received");
    }

    public void OnClick()
    {
        if (_item.Item is ItemToEquip)
        {
            _useButton.gameObject.SetActive(true);
            _useButton.GetComponent<EquipButton>().SetItem(_item);

            //Сообщаем о необходимости обновить данные на информационной панели
            Clicked?.Invoke(_item.Item);
        }
        else
        {
            _useButton.gameObject.SetActive(false);

            Clicked?.Invoke(_item.Item);
        }

        //На момент, когда я перепишу логику использования предметов
        /*else(_item is ItemToUse && !(_item as ItemToUse).IsHarmful)
        {
            _useButton.onClick.AddListener((_item as ItemToUse).Use);
        }*/
    }

    private void ChangeStatus()
    {
        //
    }
}
