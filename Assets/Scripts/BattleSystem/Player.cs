using System;
using System.Collections.Generic;
using UnityEngine;

// ����� ������ ������ ������ �������, �������, ��� ����� �� ������� ����� � �� ����� ��� - ������ �������
// � ������ ������ ���� �����, ����������� � ��������� ������ � ����������������� � ������ � ������� ����������, �������
// ������� � EventBus

[Serializable]
public class Player : Unit, ICanLoadSave<Dictionary<string, int>>
{
    private bool _isTurned = false;

    public Player() : base()
    {
        EventBus.onGetPlayer += () =>
        {
            return this;
        };
    }

    public void LoadSave(Dictionary<string, int> data, Action<bool> callback = null)
    {
        _power = new Power(data["Power"]);

        _dexterity = new Dexterity(data["Dexterity"]);

        _intelligence = new Intelligence(data["Intelligence"]);

        _durability = new Durability(data["Durability"], this);

        _endurance = new Endurance(data["Endurance"]);

        callback?.Invoke(true);
    }

    public void NewTurn()
    {
        _isTurned = false;
    }
}
