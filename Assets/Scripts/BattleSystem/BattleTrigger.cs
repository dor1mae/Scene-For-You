using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleTrigger: MonoBehaviour
{
	[SerializeField] private ToValueScene _worldScene;
	private bool _inBattle = false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player" && !_inBattle)
		{
			_inBattle = true;
			BattleSystemTransfer.Transfer(collision.GetComponentInParent<Player>(), GetComponentInParent<Enemy>());
			_worldScene.OnClick();
		}
	}
}
