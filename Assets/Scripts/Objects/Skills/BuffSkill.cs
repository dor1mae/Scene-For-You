using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CreateAssetMenu(fileName = "BuffSkill", menuName = "Skills/SkillWithEffect")]

public class BuffSkill : ScriptableSkillEffect
{
    public override bool Effect(Unit owner)
    {
        if(!owner._isBuffed)
        {
            AttributeDictionary dict = new(owner);

            dict._dict[AttributeType].Upgrade(PowerSkill);

            Debug.Log($"{dict._dict[AttributeType].Value} после баффа");
            
            owner._isBuffed = true;

            return true;
        }
        return false;
    }

    public override void EndEffect(Unit owner)
    {
        if(owner._isBuffed) 
        {
            AttributeDictionary dict = new(owner);

            dict._dict[AttributeType].Downgrade(PowerSkill);
        }
    }

    public override void Use(Unit owner)
    {
        Effect(owner);
    }
}
