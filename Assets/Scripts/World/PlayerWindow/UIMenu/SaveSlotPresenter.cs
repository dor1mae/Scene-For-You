using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveSlotsPresenter : AbstractObjectPresenter
{
    protected GameObject _loadButton;
    protected GameObject _toSaveButton;

    public SaveSlotsPresenter(GameObject LoadButton, GameObject prefabObject, GameObject ButtonToSave, Transform content) : base(prefabObject, content)
    {
        _loadButton = LoadButton;
        _loadButton.GetComponentInChildren<TextMeshProUGUI>().text = "Перезаписать";

        _toSaveButton = ButtonToSave;
        _toSaveButton.GetComponent<CreatorSaveSlot>().onCreatedSave += PresentObjects;
    }

    public override void PresentObjects()
    {
        CleanObjects();

        var saveButton = MonoBehaviour.Instantiate(_toSaveButton);
        saveButton.transform.SetParent(_content, false);

        var database = GameManagerSingltone.Instance.SaveScriptableDatabase;

        foreach (var item in database.GetItems())
        {
            var slot = MonoBehaviour.Instantiate(_prefabObject);

            slot.transform.SetParent(_content, false);
            slot.GetComponent<Button>().onClick.AddListener(() => //Через лямбда выражение присваиваю логику смены функции у кнопки загрузки
            {
                var button = _loadButton.GetComponent<Button>();
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => //Сама логика, которая помещается в кнопку загрузки при нажатии на слоты сохранений
                {
                    var saveName = item.SaveName;

                    database.Delete(saveName);
                    database.Save(saveName);

                    slot.GetComponent<SaveSlotSetter>().SetSlot(item);
                });
            });
            slot.GetComponent<SaveSlotSetter>().SetSlot(item);
        }
    }
}