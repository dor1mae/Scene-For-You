
using System;
using UnityEngine;

public class SaveButton: AbstractButton
{
    [SerializeField] private Animator _saveAnimator;

    public override void OnClick()
    {
        _saveAnimator.SetBool("isOpen", true);
    }
}
