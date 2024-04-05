using TMPro;
using UnityEngine;

public class SkillSearchFieldController : AbstractSearchFieldController<SkillsWindowPresenter>
{
    public override void OnValueSubmit(TMP_InputField tMP_InputField)
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            _target._searchField.Value = tMP_InputField.text;
        }
    }
}
