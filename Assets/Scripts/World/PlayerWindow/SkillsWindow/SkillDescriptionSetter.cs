using UnityEngine;
using TMPro;

public class SkillDescriptionSetter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _cost;
    [SerializeField] private TextMeshProUGUI _attributes;
    [SerializeField] private TextMeshProUGUI _categories;
    [SerializeField] private TextMeshProUGUI _description;

    public void SetInfo(Skill skill)
    {
        _name.text = skill.SkillName;

        _cost.text = skill.CostSkill.ToString();

        _attributes.text = skill.AttributeType.ToString();

        _categories.text = "";
        foreach (var type in skill.SkillTypes)
        {
            _categories.text += type.ToString();
        }

        _description.text = skill.Description;
    }
}
