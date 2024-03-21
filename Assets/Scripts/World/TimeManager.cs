using System;
using UnityEngine;
using UnityEngine.UI;


public class TimeManager : InitClass
{
    [SerializeField] private TimeStates _timeState;
    [SerializeField] private Text _timeField;
    [SerializeField] private Text _stateField;

    public static Func<TimeStates> onTestTime;

    [SerializeField] private int _year;
    [SerializeField] private int _month;
    [SerializeField] private int _day;

    private Date _date;

    public override void Init()
    {
        OnTestTimeEnable();
        OnActionReadyEnable();
        _date = new Date(_year, _month, _day);
        SyncDateInField();
        OnTimeChangeEnable();

        Debug.Log($"{GetType()}: is initialized");
    }

    //Синхронизация времени объекта с игрой
    private void SyncDateInField()
    {
        _timeField.text = $"{_date.Year}:{_date.Month}:{_date.Day}";
        _stateField.text = _timeState.ToString();
    }

    //Синхронизация времени игры со временем на объекте движка
    private void SyncDateInObject()
    {
        (_year, _month, _day) = (_date.Year, _date.Month, _date.Day);
    }

    //Сообщает о текущем времени слушателей события onTestTime
    private TimeStates OnTestTime()
    {
        return _timeState;
    }

    //Реакция на взаимодействие с любой точкой действия
    private void OnActionDone()
    {
        if (_timeState == TimeStates.NIGHT)
        {
            _timeState = TimeStates.MORNING;
            _date.AddDay();
        }
        else
        {
            _timeState++;
            SyncDateInField();
        }

        Debug.Log($"{this.GetType()}: {_timeState}");
    }

    private void OnActionReady(AbstractActionPoint act)
    {
        act.ActionDone += OnActionDone;
    }

    //Событие реакции на изменение даты
    private void OnTimeChangeEnable()
    {
        _date.onDateChange += SyncDateInField;
        _date.onDateChange += SyncDateInObject;
    }

    private void OnTimeChangeDisable()
    {
        _date.onDateChange -= SyncDateInField;
        _date.onDateChange -= SyncDateInObject;
    }

    //Событие готовности точек действий
    private void OnActionReadyEnable()
    {
        EventBus.onActionReady += OnActionReady;
    }

    private void OnActionReadyDisable()
    {
        EventBus.onActionReady -= OnActionReady;
    }

    //Событие сообщения текущего времени игровым объектам
    private void OnTestTimeEnable()
    {
        onTestTime += OnTestTime;
    }

    private void OnTestTimeDisable()
    {
        onTestTime -= OnTestTime;
    }
}

