using System;
using System.Collections.Generic;
using UnityEditor;

public class SkillDictionary : IDictionary<Type, Func<ScriptableSkill, Unit, Skill>>
{
    private readonly Dictionary<Type, Func<ScriptableSkill, Unit, Skill>> _skills = new Dictionary<Type, Func<ScriptableSkill, Unit, Skill>>();

    public SkillDictionary()
    {
        _skills.Add(typeof(DamageSkill), (obj, unit) => new Skill(obj, unit));
        _skills.Add(typeof(BuffSkill), (obj, unit) => new SkillWithEffect(obj, unit));

    }

    public Dictionary<Type, Func<ScriptableSkill, Unit, Skill>> _dict
    {
        get => _skills;
    }
}
