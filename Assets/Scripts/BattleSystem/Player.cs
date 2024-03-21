using System;
using System.Collections.Generic;
using UnityEngine;

//  огда будешь чинить Ѕоевую систему, вспомни, что игрок на мировой карте и на сцене бо€ - разные объекты
// у одного должен быть класс, действующий в пошаговом режиме и взаимодействующий с атакой и прочими действи€ми, вызыва€
// событи€ у EventBus

public class Player : Unit, ICanLoadSave<Tuple<Dictionary<string, int>, string>>
{
    private bool _isTurned = false;

    private AttackController attackController;
    public AttackController AttackController => attackController;

    public Player() : base()
    {
        attackController = new AttackController(Intelligence, Dexterity, Power);

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
