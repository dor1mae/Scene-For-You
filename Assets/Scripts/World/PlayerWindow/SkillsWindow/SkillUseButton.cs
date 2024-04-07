using System.Collections;
using UnityEngine;

public class SkillUseButton : MonoBehaviour
{
    [SerializeField] private PlayerCommandClient _client;
    private Skill _skill;

    public void SetSkill(Skill skill)
    {
        _skill = skill;
    }

    public void UseSkill()
    {
        _client.AddSkillCommand(_skill);
    }
}