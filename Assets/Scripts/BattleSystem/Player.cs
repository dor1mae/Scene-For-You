using System;
using System.Collections.Generic;
using UnityEngine;

// ����� ������ ������ ������ �������, �������, ��� ����� �� ������� ����� � �� ����� ��� - ������ �������
// � ������ ������ ���� �����, ����������� � ��������� ������ � ����������������� � ������ � ������� ����������, �������
// ������� � EventBus

public class Player : Unit, ICanLoadSave<Tuple<Dictionary<string, int>, string>>
{
    protected bool _isTurned = false;

    public override void Init()
    {
        base.Init();

        EventBus.onGetPlayer += GetPlayer;
    }

    public void LoadSave(Tuple<Dictionary<string, int>, string> tuple, Action<bool> callback = null)
    {
        _power.LoadSave(tuple.Item1["Power"]);

        _dexterity.LoadSave(tuple.Item1["Dexterity"]);

        _intelligence.LoadSave(tuple.Item1["Intelligence"]);

        _durability.LoadSave(tuple.Item1["Durability"]);

        _endurance.LoadSave(tuple.Item1["Endurance"]);

        _name = tuple.Item2;

        callback?.Invoke(true);
    }

    public void NewTurn()
    {
        _isTurned = false;
    }

    public Player GetPlayer()
    {
        return this;
    }
}
