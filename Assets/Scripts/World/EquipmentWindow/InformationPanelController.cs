using System;
using UnityEngine;
using UnityEngine.UI;


public class InformationPanelController : MonoBehaviour
{
    //Поля информационного табло
    [SerializeField] private Text _infName;
    [SerializeField] private Text _infDesc;
    [SerializeField] private Image _infSprite;
    [SerializeField] private Text _infDexterity;
    [SerializeField] private Text _infIntelligence;
    [SerializeField] private Text _infPower;
    [SerializeField] private Text _infDurability;
    [SerializeField] private Text _infEndurance;

    public void SetInformationPanel(ItemEmpty _item)
    {
        Debug.Log($"{GetType()}: {_item.Name} : {_item.Description}");
        Debug.Log($"{GetType()}: {_infName.text} : {_infDesc.text}");

        _infDesc.text = _item.Description;
        _infName.text = _item.Name;
        _infSprite.sprite = _item.Icon;

        if (_item is ItemToEquip)
        {
            Tuple<int, int, int, int, int> stats = (_item as ItemToEquip).GetStats();

            _infPower.text = stats.Item1.ToString();
            _infDurability.text = stats.Item2.ToString();
            _infEndurance.text = stats.Item3.ToString();
            _infDexterity.text = stats.Item4.ToString();
            _infIntelligence.text = stats.Item5.ToString();
        }
        else
        {
            _infPower.text = "0";
            _infDurability.text = "0";
            _infEndurance.text = "0";
            _infDexterity.text = "0";
            _infIntelligence.text = "0";
        }
    }
}

