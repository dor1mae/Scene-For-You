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
			var inventory = GameManagerSingltone.Instance.Inventory.GetItems();
			var skillBook = GameManagerSingltone.Instance.SkillBook.GetItems();
			
			BattleSystemTransfer.Transfer(collision.GetComponentInParent<Player>(), GetComponentInParent<Enemy>(), inventory, skillBook);
			_worldScene.OnClick();
		}
	}
}
