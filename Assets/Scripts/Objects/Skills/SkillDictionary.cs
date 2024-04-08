using System;
using System.Collections.Generic;
using UnityEditor;

public class SkillDictionary : IDictionary<Type, Skill>
{
    private readonly Dictionary<Type, Skill> _skills;
    private readonly Unit _owner;
    private readonly ScriptableSkill _skill;

    public SkillDictionary(Unit owner, ScriptableSkill skill)
    {
        _owner = owner;
        _skill = skill;

        _skills = new()
        {
            [typeof(BuffSkill)] = new SkillWithEffect(_skill, _owner),
            [typeof(DamageSkill)] = new Skill(_skill, _owner)
        };

    }

    public Dictionary<Type, Skill> _dict
    {
        get => _skills;
    }
}
