using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SkillsSearchController : AbstractSearchController<SkillsWindowPresenter, SkillBook, List<Skill>>
{
    public SkillsSearchController(SkillsWindowPresenter window, SkillBook target) : base(window, target)
    {
    }

    public override List<Skill> SearchItems()
    {
        var stringSearch = _window._searchField.Value;
        var tagSearchList = _window._skillsCat.Value;

        Debug.Log($"{GetType()}: stringSearch = {stringSearch}, tagSearchList = {tagSearchList}");

        List<Skill> temp = _target.GetItems();
        List<Skill> newTemp = new List<Skill>();

        if (stringSearch == "" || stringSearch == null)
        {
            if (tagSearchList.Count == 0)
            {
                return temp;
            }
            else
            {
                foreach (var t in tagSearchList)
                {
                    newTemp.AddRange(temp.FindAll(x => (x.SkillTypes.Contains(t) && !newTemp.Contains(x))));
                }

                return newTemp;
            }
        }
        else
        {
            if (tagSearchList.Count == 0)
            {
                newTemp.AddRange(temp.FindAll(x => x.SkillName.Contains(stringSearch)));

                return newTemp;
            }
            else
            {
                List<Skill> newTemp2 = new List<Skill>();

                newTemp.AddRange(temp.FindAll(x => x.SkillName.Contains(stringSearch)));

                foreach (var t in tagSearchList)
                {
                    newTemp2.AddRange(newTemp.FindAll(x => (x.SkillTypes.Contains(t) && !newTemp2.Contains(x))));
                }

                return newTemp2;
            }
        }
    }
}
