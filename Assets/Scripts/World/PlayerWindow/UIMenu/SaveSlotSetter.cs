using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.IO;

public class SaveSlotSetter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _saveName;
    [SerializeField] private TextMeshProUGUI _savePlayer;
    [SerializeField] private TextMeshProUGUI _saveDate;
    [SerializeField] private Button _deleteButton;

    public void SetSlot(Save item)
    {
        _saveName.text = item.SaveName;
        _savePlayer.text = item.PlayerName;
        _saveDate.text = item.SaveDate;

        _deleteButton.onClick.RemoveAllListeners();
        _deleteButton.onClick.AddListener(()=>
        {
            Directory.Delete(Path.Combine(Application.persistentDataPath, $"{item.SaveName}.json"));
            Destroy(gameObject);
        });
    }
}

