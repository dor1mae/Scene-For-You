using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsWindowPresenter : AbstractObjectPresenter, IMonoSet
{
    public ReactiveProperty<List<SkillType>> _skillsCat = new();
    public ReactiveProperty<string> _searchField = new();

    private SkillsSearchController _searchController;

    [SerializeField] private SkillDescriptionSetter _skillDescriptionSetter;
    [SerializeField] private SkillUseButton _skillUse;
    [SerializeField] private SkillBook _skillBook;

    public void Set()
    {
        _skillsCat.Value = new List<SkillType>();

        _skillsCat.OnChange += OnSkillsCatChange;
        _searchField.OnChange += OnSearchFieldChange;

        _searchController = new(this, _skillBook);
    }

    private void OnSkillsCatChange(List<SkillType> obj)
    {
        Debug.Log("Тоггл меняет значение");
        PresentObjects();
    }

    private void OnSearchFieldChange(string field)
    {
        PresentObjects();
    }

    public override void PresentObjects()
    {
        CleanObjects();

        var items = _searchController.SearchItems();
        Debug.Log($"Число предметов: {items.Count}");

        foreach (var item in items)
        {
            Debug.Log(item.SkillName);

            var prefab = Instantiate(_prefabObject);
            prefab.transform.SetParent(_content, false);

            var skillSetter = prefab.GetComponent<SkillBoxSetter>();
            skillSetter.SetInfo(item);

            var button = prefab.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() =>
            {
                _skillDescriptionSetter.SetInfo(item);
                if (GameManagerSingltone.Instance.IsBattle)
                {
                    Debug.Log($"{item.SkillName}");

                    _skillUse.SetSkill(item);
                }
            });
        }
    }
}
