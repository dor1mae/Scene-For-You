using UnityEngine;

public class LoadButton : AbstractButton
{
    [SerializeField] private SaveLoadWindow _saveLoadWindow;

    public override void OnClick()
    {
        _saveLoadWindow.SetStateOfWindow(true);
        _saveLoadWindow.StartOpenAnimation();
    }
}
