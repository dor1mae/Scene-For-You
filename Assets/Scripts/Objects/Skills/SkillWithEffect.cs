using UnityEngine;

public class SkillWithEffect : Skill, IEffect
{
    protected int _duration;
    public int Duration => _duration;

    public SkillWithEffect(ScriptableSkill skillConfig, Unit owner) : base(skillConfig, owner)
    {
    }

    public override void Use(Unit t = null)
    {
        Debug.Log($"{GetType()} вызывает скилл {_skillConfig.SkillName}");

        if (!TryCast())
        {
            return;
        }

        ScriptableSkillEffect skillConfig = (ScriptableSkillEffect)_skillConfig;

        _duration = (_skillConfig as ScriptableSkillEffect).DurationEffect;

        if (SkillTypes.Contains(SkillType.Positive))
        {
            Debug.Log($"Позитивный исход");
            _owner.EffectsController.AddEffect(this);
            _skillConfig.Use(_owner);
        }
        else
        {
            Debug.Log($"Негативный исход");
            if (_owner is Player)
            {
                EventBus.onGetEnemy.Invoke().EffectsController.AddEffect(this);
                _skillConfig.Use(Owner);
            }
            else
            {
                GameManagerSingltone.Instance.Player.EffectsController.AddEffect(this);
                _skillConfig.Use(Owner);
            }
        }
    }

    public bool Effect(Unit unit = null)
    {
        if(_duration > 0 && !TryCast())
        {
            (_skillConfig as ScriptableSkillEffect).Effect(Owner);
            _duration--;

            return false;
        }
        else
        {
            return true;
        }
        
    }

    public void EndEffect(Unit unit = null)
    {
        (_skillConfig as ScriptableSkillEffect).EndEffect(Owner);
    }
}
