using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class SaveSlotsPresenter : AbstractObjectPresenter
{
    protected GameObject _loadButton;
    protected GameObject _toSaveButton;

    public SaveSlotsPresenter(GameObject LoadButton, GameObject prefabObject, GameObject ButtonToSave, Transform content) : base(prefabObject, content)
    {
        _loadButton = LoadButton;
        _loadButton.GetComponentInChildren<TextMeshProUGUI>().text = "Перезаписать";

        _toSaveButton = ButtonToSave;
    }

    public override void PresentObjects()
    {
        CleanObjects();
        JsonFileToStorageSaveManager json = new();

        var saveButton = MonoBehaviour.Instantiate(_toSaveButton);
        saveButton.GetComponent<CreatorSaveSlot>().onCreatedSave += PresentObjects;
        saveButton.transform.SetParent(_content, false);

        var database = Directory.GetFiles(Application.persistentDataPath);

        foreach (var file in database)
        {
            var save = json.Load<Save>(file, (a) =>
            {
                if (a)
                {
                    Debug.Log($"Загрузка сохранения {file} прошла успешно"); ;
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
                    var saveName = save.SaveName;

                    Directory.Delete(Path.Combine(Application.persistentDataPath, file));
                    json.Save(file, new Save(saveName));

                    slot.GetComponent<SaveSlotSetter>().SetSlot(save);
                });
            });
            slot.GetComponent<SaveSlotSetter>().SetSlot(save);
        }
    }
}