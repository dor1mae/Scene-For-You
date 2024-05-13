using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class RewardWindow : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _text;
	[SerializeField] private Button _exitButton;

	private int _valueOfPoints;
	private Player _player;

	public void Init(Player player, Enemy enemy)
	{
		_valueOfPoints = (BattleSystem.OnGetEnemy.Invoke()).CheckBattlePower() / 50;
		_player = player;

		_text.text = _text.text.Replace("Value", $"{_valueOfPoints}");
		GiveReward();

		_exitButton.onClick.RemoveAllListeners();
		_exitButton.onClick.AddListener(() =>
		{
			GameManagerSingltone.Instance.ChangeStatusWorld(true);
			GameManagerSingltone.Instance.ChangeIsBattle(false);
			enemy.SelfDestroy();
			SceneManager.UnloadSceneAsync(1);
		});
	}

	private void GiveReward()
	{
		while(_valueOfPoints != 0)
		{
			int value = Random.Range(1, _valueOfPoints);
			int chose = Random.Range(1, 5);

			switch (chose)
			{
				case 1:
					_player.Power.Upgrade(value); 
					break;
				case 2:
					_player.Dexterity.Upgrade(value);
					break;
				case 3:
					_player.Durability.Upgrade(value);
					break;
				case 4:
					_player.Endurance.Upgrade(value);
					break;
				case 5:
					_player.Intelligence.Upgrade(value);
					break;
			}

			_valueOfPoints -= value;
		}
	}
}
