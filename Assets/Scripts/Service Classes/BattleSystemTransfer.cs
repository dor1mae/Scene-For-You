using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

public static class BattleSystemTransfer
{
	private static Player _player;
	private static List<RealItem> _inventory = new();
	private static List<Skill> _skillBook = new();
	private static Enemy _enemy;

	public static void Transfer(Player player, Enemy enemy, List<RealItem> inventory, List<Skill> skillBook)
	{
		_player = player;
		_enemy = enemy;
		_inventory = inventory;
		_skillBook = skillBook;
	}

	public static void Get(out Player player, out Enemy enemy, out List<RealItem> inventory, out List<Skill> skillBook)
	{
		inventory = new();
		skillBook = new();

		player = _player;
		enemy = _enemy;
		inventory = _inventory;
		skillBook = _skillBook;
	}
}
