public static class BattleSystemTransfer
{
	private static Player _player;
	private static Enemy _enemy;

	public static void Transfer(Player player, Enemy enemy)
	{
		_player = player;
		_enemy = enemy;
	}

	public static void Get(out Player player, out Enemy enemy)
	{
		player = _player;
		enemy = _enemy;
	}
}
