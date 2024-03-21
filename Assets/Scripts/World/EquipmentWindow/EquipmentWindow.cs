using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentWindow : InitClass
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private GameObject _containerUI;
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private Button _useButton;
    [SerializeField] private InformationPanelController _controller;
    [SerializeField] private ItemPresentController _presentController;

    private ItemSearchController _searchController;

    public static List<EquipmentType> SearchTagList = new();
    public static string SearchString;

    //Событие, которое вызывается либо переключением Toggle категорий, либо Submit поисковой строки. Запускает поиск предметов
    public static Action OnSearch;

    private Animator _animator;


    public override void Init()
    {
        _inventory.Init();
        _searchController = new ItemSearchController(_inventory);
        _presentController.SetItemPresentController(_containerUI, _itemPrefab, _searchController, _controller, _useButton);

        OnSearch += _presentController.PresentItems;
        _presentController.PresentItems();
        Debug.Log($"{GetType()}: is initialized");
    }

    private void OnOpenEquipmentWindow()
    {

    }

    private void OnCloseEquipmentWindow()
    {

    }
}

