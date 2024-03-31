using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using static UnityEditor.Progress;

public class LoadSlotsPresenter : AbstractObjectPresenter
{
    protected GameObject _loadButton;

    public LoadSlotsPresenter(GameObject LoadButton, GameObject prefabObject, Transform content) : base(prefabObject, content)
    {
        _loadButton = LoadButton;
        _loadButton.GetComponentInChildren<TextMeshProUGUI>().text = "Загрузить";
    }

    public override void PresentObjects()
    {
        CleanObjects();
        JsonFileToStorageSaveManager json = new();

        var database = Directory.GetFiles(Application.persistentDataPath);

        foreach (var file in database)
        {
            var save = json.Load<Save>(file, (a) =>
            {
                if (a)
                {
                    Debug.Log("Загрузка сохранения прошла успешно");
                }
            });

            var slot = MonoBehaviour.Instantiate(_prefabObject);

            slot.transform.SetParent(_content, false);
            slot.GetComponent<Button>().onClick.AddListener(() => //Через лямбда выражение присваиваю логику смены функции у кнопки загрузки
            {
                var button = _loadButton.GetComponent<Button>();
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => //Сама логика, которая помещается в кнопку загрузки при нажатии на слоты сохранений
                {
                    save.Load((a) =>
                    {
                        if (a)
                        {
                            Debug.Log($"{save.SaveName} успешно загружен");
                        }
                    });
                });
            });
            slot.GetComponent<SaveSlotSetter>().SetSlot(save);
        }
    }
}
