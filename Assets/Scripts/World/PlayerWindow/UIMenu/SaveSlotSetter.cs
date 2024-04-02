using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.IO;
using System.Linq;

/// <summary>
/// Установщик слота сохранения. Устанавливает функцию удаления, обновляет информацию на слоте о сохранении
/// </summary>
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
            var files = Directory.GetFiles(Path.Combine(Application.persistentDataPath)).ToList();
            
            var save = files.Find(x => x.Contains(_saveName.text));
            Debug.Log(save);
            if (save != null) 
            {
                File.Delete(save);
                Destroy(gameObject);

                Debug.Log($"Удаление {save} прошло успешно");
            }
        });
    }
}

