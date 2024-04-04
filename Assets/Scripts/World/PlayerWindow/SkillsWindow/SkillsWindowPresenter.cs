using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SkillsWindowPresenter : AbstractObjectPresenter
{
    public ReactiveProperty<List<SkillType>> _skillsCat;
    public ReactiveProperty<string> _searchField;

    private SkillsSearchController _searchController;

    public SkillsWindowPresenter(GameObject prefabObject, Transform content) : base(prefabObject, content)
    {
        _skillsCat.OnChange += OnSkillsCatChange;
        _searchField.OnChange += OnSearchFieldChange;
    }

    private void OnSkillsCatChange(List<SkillType> obj)
    {
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
            //Debug.Log(item.Item.Name);

        }
    }
}
