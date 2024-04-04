using System;
using UnityEngine;

public abstract class ScriptableSkillEffect : ScriptableSkill, IEffect
{

    [SerializeField]
    protected int _durationEffect;

    public int DurationEffect => _durationEffect;

    public abstract bool Effect(Unit unit);
    public abstract void EndEffect(Unit unit);
}
