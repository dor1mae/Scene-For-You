using UnityEngine;
using System;
using System.Collections;

public abstract class AbstractUIWindow: InitClass
{
    [SerializeField] protected Animator _animator;
    protected Action onEndAnimation;
    protected bool _isActive = false;

    protected abstract IEnumerator OnCloseAnimation();

    protected abstract IEnumerator OnOpenAnimation();

    public virtual void StartOpenAnimation()
    {
        _isActive = true;
        StartCoroutine(OnOpenAnimation());
    }

    public virtual void StartCloseAnimation()
    {
        _isActive = true;
        StartCoroutine(OnCloseAnimation());
    }
}
