using System;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentPresenter : MonoBehaviour
{
    private ItemEmpty _item;

    //���� ������
    [SerializeField] private Text _name;
    [SerializeField] private Image _spriteOfObject;
    [SerializeField] private Text _numberOfItems;

    private Button _useButton;
    private InformationPanelController _controller;
    private ReactiveProperty<bool> _isEquiped;
    private Action<ItemEmpty> Clicked;

    public void SetEquipmentPresenter(ItemEmpty item, InformationPanelController controller, Button button)
    {
        //�������������� ������
        _controller = controller;
        Clicked += _controller.SetInformationPanel;

        //EquipController
        _useButton = button;

        _item = item;

        _name.text = item.Name;
        _spriteOfObject.sprite = item.Icon;
        //_numberOfItems.text = $"{_item.NumberOfItems}/{_item.MaxNumberOfItems}";

        Debug.Log($"{GetType()}: SetEquipmentPresenter : {item.Name} is received");
    }

    public void OnClick()
    {
        if (_item is ItemToEquip)
        {
            _useButton.gameObject.SetActive(true);
            _useButton.GetComponent<EquipController>().SetItem(_item as ItemToEquip);

            //�������� � ������������� �������� ������ �� �������������� ������
            Clicked?.Invoke(_item);
        }
        else
        {
            _useButton.gameObject.SetActive(false);

            Clicked?.Invoke(_item);
        }

        //�� ������, ����� � �������� ������ ������������� ���������
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
