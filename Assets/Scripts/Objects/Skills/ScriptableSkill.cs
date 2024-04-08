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

    [SerializeField] 
    protected int _powerSkill;


    public string skillID => _skillID;
    public string SkillName => _skillName;
    public string Description => _skillDescription;
    public AttributeType AttributeType => _attributeType;

    [SerializeField]
    protected SkillClassEnum _skillClassEnum;
    public SkillClassEnum SkillClass => _skillClassEnum;
    public float CostSkill => _costSkill;
    public Sprite Sprite => _skillSprite;
    public SkillType[] SkillType => skillTypes;

    public int PowerSkill => _powerSkill;

    public abstract void Use(Unit target);

    public Skill Learn(Unit unit)
    {
        SkillDictionary dict = new(unit, this);

        Debug.Log($"{this.GetType()}-скилл изучен");

        dict._dict.TryGetValue(this.GetType(), out Skill skill);

        return skill;
    }
}
