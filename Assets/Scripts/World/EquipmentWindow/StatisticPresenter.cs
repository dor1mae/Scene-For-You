using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Обновляет данные о характеристиках игрока в окне снаряжения
/// </summary>
public class StatisticPresenter : InitClass
{
    [SerializeField] private Text _durability;
    [SerializeField] private Text _dexterity;
    [SerializeField] private Text _intelligence;
    [SerializeField] private Text _power;
    [SerializeField] private Text _endurance;
    [SerializeField] private Text _mana;
    [SerializeField] private Text _health;
    [SerializeField] private Text _stamina;
    [SerializeField] private Text _magicDamage;
    [SerializeField] private Text _physDamage;

    public override void Init()
    {
        var player = GameManagerSingltone.Instance.Player;

        player.Dexterity.onValueChange += SyncDexterity;
        player.Durability.onValueChange += SyncDurability;
        player.Intelligence.onValueChange += SyncIntelligence;
        player.Power.onValueChange += SyncPower;
        player.Endurance.onValueChange += SyncEndurance;
        player.Intelligence.isChanged += SyncMana;
        player.Endurance.isChanged += SyncStamina;
        player.Durability.isChanged += SyncHealth;

        _durability.text = player.Durability.Value.ToString();
        _dexterity.text = player.Dexterity.Value.ToString();
        _intelligence.text = player.Intelligence.Value.ToString();
        _power.text = player.Power.Value.ToString();
        _endurance.text = player.Endurance.Value.ToString();
        _stamina.text = player.Endurance.MaxBar.ToString();
        _mana.text = player.Intelligence.MaxBar.ToString();
        _health.text = player.Durability.MaxBar.ToString();
        _physDamage.text = player.Power.CheckDamage().ToString();
        _magicDamage.text = player.Intelligence.CheckDamage().ToString();

        Debug.Log($"{GetType()}: is initialized");
    }

    private void SyncDexterity(int value)
    {
        _dexterity.text = value.ToString();
    }

    private void SyncPower(int value)
    {
        _power.text = value.ToString();

        SyncDamage(EventBus.onCheckDamage?.Invoke());
    }

    private void SyncDurability(int value)
    {
        _durability.text = value.ToString();
    }

    private void SyncIntelligence(int value)
    {
        _intelligence.text = value.ToString();

        SyncDamage(EventBus.onCheckDamage?.Invoke());
    }

    private void SyncEndurance(int value)
    {
        _endurance.text = value.ToString();
    }

    private void SyncMana(float bar, float maxbar)
    {
        _mana.text = maxbar.ToString();
    }

    private void SyncStamina(float bar, float maxbar)
    {
        _stamina.text = maxbar.ToString();
    }

    private void SyncHealth(float bar, float maxbar)
    {
        _health.text = maxbar.ToString();
    }

    private void SyncDamage(Tuple<float, float> tuple)
    {
        _physDamage.text = tuple.Item1.ToString();
        _magicDamage.text = tuple.Item2.ToString();
    }
}

