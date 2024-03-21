using UnityEngine;


public class TestSave : MonoBehaviour
{
    private JsonFileToStorageSaveManager saveSystem;

    private PlayerContainer test;

    private void Start()
    {
        saveSystem = new JsonFileToStorageSaveManager();
        test = new PlayerContainer(GameManagerSingltone.Instance.Player, GameManagerSingltone.Instance.Inventory);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            saveSystem.Save<PlayerContainer>("save1", test, (bool t) =>
            {
                Debug.Log("Okay Save");
            });
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            var playerContainer = saveSystem.Load<PlayerContainer>("save1", (bool t) =>
            {
                Debug.Log("Okay Load");
            });

            playerContainer.Load();

            Debug.Log(playerContainer.GetType());
        }
    }
}
