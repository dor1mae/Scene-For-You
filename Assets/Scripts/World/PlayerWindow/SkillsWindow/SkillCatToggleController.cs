using UnityEngine.UI;

public class SkillCatToggleController : AbstractCatToggleController<SkillsWindowPresenter, SkillType>
{
    public override void OnToggleValueChanged(Toggle change)
    {
        if (change.isOn)
        {
            _target._skillsCat.Value.Add(_type);
            _target._skillsCat.OnChange?.Invoke(_target._skillsCat.Value);
        }
        else
        {
            _target._skillsCat.Value.RemoveAll(x => x == _type);
            _target._skillsCat.OnChange?.Invoke(_target._skillsCat.Value);
        }
    }
}