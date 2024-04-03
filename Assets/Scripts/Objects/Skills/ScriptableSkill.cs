using UnityEngine;
using System;

[Serializable]
public abstract class ScriptableSkill : ScriptableObject, IUse
{
    [SerializeField]
    protected string _skillID;

    [SerializeField]
    protected string _skillName;

    [SerializeField]
    protected Sprite _skillSprite;
    
    [TextArea(5, 10)]
    [SerializeField]
    protected string _skillDescription;

    [SerializeField]
    protected float _costSkill;

    [SerializeField]
    protected AttributeType _attributeType;

    [SerializeField]
    protected SkillType[] skillTypes;

    public string skillID => _skillID;
    public string SkillName => _skillName;
    public string Description => _skillDescription;
    public AttributeType AttributeType => _attributeType;
    public float CostSkill => _costSkill;
    public Sprite Sprite => _skillSprite;
    public SkillType[] SkillType => skillTypes;

    public abstract void Use(Unit target);

    public virtual Skill Learn(Unit unit)
    {
        return new Skill(this, unit);
    }
}
