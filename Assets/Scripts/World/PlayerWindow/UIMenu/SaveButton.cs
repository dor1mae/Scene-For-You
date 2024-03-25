
using System;
using UnityEngine;

public class SaveButton: AbstractButton
{
    [SerializeField] private SaveLoadWindow _window;
    public override void OnClick()
    {
        _window.SetStateOfWindow(false);
        _window.StartOpenAnimation();
    }
}
