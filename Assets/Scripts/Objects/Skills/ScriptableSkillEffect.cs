using System;
using UnityEngine;

public abstract class ScriptableSkillEffect : ScriptableSkill, IEffect
{

    [SerializeField]
    protected int _durationEffect;

    public int DurationEffect => _durationEffect;

    public abstract bool Effect(Unit unit);
    public abstract void EndEffect(Unit unit);

    public override Skill Learn(Unit unit)
    {
        return new SkillWithEffect(this, unit);
    }
}
