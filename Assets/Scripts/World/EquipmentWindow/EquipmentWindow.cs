﻿using System;
using System.Collections;
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
    [SerializeField] private InventoryPresenter _presentController;

    private ItemSearchController _searchController;

    public static List<EquipmentType> SearchTagList = new();
    public static string SearchString;

    //Событие, которое вызывается либо переключением Toggle категорий, либо Submit поисковой строки. Запускает поиск предметов
    public static Action OnSearch;
    private Action onEndAnimation;

    private bool _isActive = false;

    private Animator _animator;


    public override void Init()
    {
        _inventory.Init();
        _searchController = new ItemSearchController(_inventory);
        _presentController.SetItemPresentController(_containerUI, _itemPrefab, _searchController, _controller, _useButton);
        _animator = GetComponent<Animator>();
        
        onEndAnimation = () =>
        {
            _isActive = false;
        };

        OnSearch += _presentController.PresentItems;
        _presentController.PresentItems();
        Debug.Log($"{GetType()}: is initialized");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) && !_animator.GetBool("isOpen") && !UIManager.IsBusy() && !_isActive)
        {
            StartOpenAnimation();
        }
        else if(Input.GetKeyDown(KeyCode.I) && _animator.GetBool("isOpen") && UIManager.IsBusy() && !_isActive)
        {
            StartCloseAnimation();
        }
    }

    private IEnumerator OnOpenEquipmentWindow()
    {
        UIManager.SetBusy(true);

        gameObject.GetComponent<CanvasGroup>().alpha = 1.0f;

        _animator.SetBool("isOpen", true);

        _animator.Play("Open");

        Debug.Log("Попытка вызвать открытие и включение объекта");
        yield return new WaitForSeconds(1);

        onEndAnimation?.Invoke();
    }

    private IEnumerator OnCloseEquipmentWindow()
    {
        UIManager.SetBusy(false);

        _animator.SetBool("isOpen", false);
        
        _animator.Play("Close");

        yield return new WaitForSeconds(1);

        Debug.Log("Попытка вызвать закрытие и отключение объекта");
         
        gameObject.GetComponent<CanvasGroup>().alpha = 0.0f;

        onEndAnimation?.Invoke();
    }

    private void StartOpenAnimation()
    {
        _isActive = true;
        StartCoroutine(OnOpenEquipmentWindow());
    }

    private void StartCloseAnimation()
    {
        _isActive = true;
        StartCoroutine(OnCloseEquipmentWindow());
    }
}

