using System.Collections;
using UnityEngine;

public class SkillUseButton : MonoBehaviour
{
    [SerializeField] private PlayerCommandClient _client;
    private Skill _skill;

    public void SetSkill(Skill skill)
    {
        Debug.Log($"{skill.SkillName} получен");
        _skill = skill;
    }

    public void UseSkill()
    {
        Debug.Log($"{_skill.SkillName} пытаюсь использовать");
        _client.AddSkillCommand(_skill);
    }
}