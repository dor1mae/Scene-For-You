using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

        var database = GameManagerSingltone.Instance.SaveScriptableDatabase;

        foreach (var item in database.GetItems())
        {
            var slot = MonoBehaviour.Instantiate(_prefabObject);

            slot.transform.SetParent(_content, false);
            slot.GetComponent<Button>().onClick.AddListener(()=> //Через лямбда выражение присваиваю логику смены функции у кнопки загрузки
            {
                var button = _loadButton.GetComponent<Button>();
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => //Сама логика, которая помещается в кнопку загрузки при нажатии на слоты сохранений
                {
                    item.Load((a) =>
                    {
                        if(a)
                        {
                            Debug.Log($"{item.name} успешно загружен");
                        }
                    });
                });
            });
            slot.GetComponent<SaveSlotSetter>().SetSlot(item);
        }
    }
}
