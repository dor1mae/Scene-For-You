using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotButton : MonoBehaviour
{
    private RealItem _item;

    //���� ������
    [SerializeField] private Text _name;
    [SerializeField] private Image _spriteOfObject;
    [SerializeField] private Text _numberOfItems;

    private Button _useButton;
    private InformationPanelController _controller;
    private ReactiveProperty<bool> _isEquiped;
    private Action<ItemEmpty> Clicked;

    public void SetEquipmentPresenter(RealItem item, InformationPanelController controller, Button button)
    {
        //�������������� ������
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

            //�������� � ������������� �������� ������ �� �������������� ������
            Clicked?.Invoke(_item.Item);
        }
        else
        {
            _useButton.gameObject.SetActive(false);

            Clicked?.Invoke(_item.Item);
        }
    }
}
