using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

public class Skill : IUse
{
    protected ScriptableSkill _skillConfig;

    protected Unit _owner;

    public Unit Owner => _owner;
    public string SkillID => _skillConfig.skillID;
    public List<SkillType> SkillTypes => _skillConfig.SkillType.ToList();

    public Skill(ScriptableSkill skillConfig, Unit owner)
    {
        _skillConfig = skillConfig;
        _owner = owner;
    }

    public virtual void Use(Unit t = null)
    {
        if(SkillTypes.Contains(SkillType.Positive))
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
}

