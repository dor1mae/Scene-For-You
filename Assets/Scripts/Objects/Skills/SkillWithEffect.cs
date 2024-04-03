public class SkillWithEffect : Skill, IEffect
{
    protected int _duration;
    public int Duration => _duration;
    public SkillWithEffect(ScriptableSkill skillConfig, Unit owner) : base(skillConfig, owner)
    {
    }

    public override void Use(Unit t = null)
    {
        _duration = (_skillConfig as ScriptableSkillEffect).DurationEffect;

        if (SkillTypes.Contains(SkillType.Positive))
        {
            _owner.GetComponent<EffectsController>().AddEffect(this);
        }
        else
        {
            if(_owner is Player)
            {
                EventBus.onGetEnemy.Invoke().GetComponent<EffectsController>().AddEffect(this);
            }
            else
            {
                GameManagerSingltone.Instance.Player.GetComponent<EffectsController>().AddEffect(this);
            }
        }
    }

    public bool Effect(Unit unit = null)
    {
        if(_duration > 0)
        {
            (_skillConfig as ScriptableSkillEffect).Effect();
            _duration--;

            return false;
        }
        else
        {
            return true;
        }
        
    }
}
