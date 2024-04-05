using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkillBoxSetter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Image _sprite;

    public void SetInfo(Skill skill)
    {
        _name.text = skill.SkillName;
        _sprite.sprite = skill.SkillSprite;
    }
}
