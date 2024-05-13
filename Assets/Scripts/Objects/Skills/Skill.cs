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
        Debug.Log($"{GetType()} вызывает скилл {_skillConfig.SkillName}");

        if(!TryCast())
        {
            return;
        }

        if (SkillTypes.Contains(SkillType.Positive))
        {
            Debug.Log($"Позитивный выбор");
            _skillConfig.Use(_owner);
        }
        else
        {
            Debug.Log($"Негативный выбор");
            if (_owner is Player)
            {
                _skillConfig.Use(BattleSystem.OnGetEnemy.Invoke());
            }
            else
            {
                _skillConfig.Use(GameManagerSingltone.Instance.Player);
            }
        }
    }

    public bool TryCast()
    {
        if (Owner.Intelligence.Bar - _skillConfig.CostSkill < 0)
        {
            return false;
        }
        else return true;
    }
}

