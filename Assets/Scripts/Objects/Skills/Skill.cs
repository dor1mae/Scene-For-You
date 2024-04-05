using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Skill : IUse
{
    protected ScriptableSkill _skillConfig;

    protected Unit _owner;

    public Unit Owner => _owner;
    public string SkillID => _skillConfig.skillID;
    public List<SkillType> SkillTypes => _skillConfig.SkillType.ToList();
    public string SkillName => _skillConfig.SkillName;

    protected bool _isFail = false;
    public bool IsFail => _isFail;

    public float CostSkill => _skillConfig.CostSkill;
    public AttributeType AttributeType => _skillConfig.AttributeType;
    public string Description => _skillConfig.Description;
    public Sprite SkillSprite => _skillConfig.Sprite;

    public Skill(ScriptableSkill skillConfig, Unit owner)
    {
        _skillConfig = skillConfig;
        _owner = owner;
    }

    public virtual void Use(Unit t = null)
    {
        TryCast();

        if(IsFail)
        {
            return;
        }

        if (SkillTypes.Contains(SkillType.Positive))
        {
            _skillConfig.Use(_owner);
        }
        else
        {
            if(_owner is Player)
            {
                _skillConfig.Use(EventBus.onGetEnemy.Invoke());
            }
            else
            {
                _skillConfig.Use(GameManagerSingltone.Instance.Player);
            }
        }
    }

    protected void TryCast()
    {
        if (Owner.Intelligence.Value - _skillConfig.CostSkill < 0)
        {
            _isFail = true;
        }
        else _isFail = false;
    }
}

