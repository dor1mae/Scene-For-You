using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SkillBook : AbstractInventory<ScriptableSkill, Skill>
{
    [SerializeField] private ScriptableSkill[] _startSkills;
    private List<Skill> _skillBook = new List<Skill>();
    [SerializeField]
    private Unit _owner;

    public override void AddItem(ScriptableSkill item)
    {
        _skillBook.Add(item.Learn(_owner));
    }
}
