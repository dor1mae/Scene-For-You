using System.Collections;
using UnityEngine;
using System;


public class IngameMenuWindow : AbstractUIWindow
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !UIManager.IsBusy() && !_animator.GetBool("IsOpen") && !_isActive)
        {
            StartOpenAnimation();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && UIManager.IsBusy() && _animator.GetBool("IsOpen") && !_isActive)
        {
            StartCloseAnimation();
        }
    }

    protected override IEnumerator OnCloseAnimation()
    {
        UIManager.SetBusy(false);

        _animator.SetBool("IsOpen", false);

        _animator.Play("Close");

        yield return new WaitForSeconds(1);

        Debug.Log("Попытка вызвать закрытие и отключение объекта");

        gameObject.GetComponent<CanvasGroup>().alpha = 0.0f;

        onEndAnimation?.Invoke();
    }

    protected override IEnumerator OnOpenAnimation()
    {
        UIManager.SetBusy(true);

        gameObject.GetComponent<CanvasGroup>().alpha = 1.0f;

        _animator.SetBool("IsOpen", true);

        _animator.Play("Open");

        Debug.Log("Попытка вызвать открытие и включение объекта");
        yield return new WaitForSeconds(1);

        onEndAnimation?.Invoke();

    }

    public override void Init()
    {
        onEndAnimation += () =>
        {
            _isActive = false;
        };
    }
}
