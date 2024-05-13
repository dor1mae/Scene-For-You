using System.Collections;
using UnityEngine;

public class SkillsWindow : AbstractUIWindow
{
    [SerializeField] private SkillsWindowPresenter _skillsPresenter;

    public override void Init()
    {
        _skillsPresenter.Set();
        _skillsPresenter.PresentObjects();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            StartOpenAnimation();
        }
        else if (Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.Escape))
        {
            StartCloseAnimation();
        }
    }

    protected override IEnumerator OnCloseAnimation()
    {
        UIManager.SetBusy(false);
        UIManager.SetCanPlayerMove(true);

        _animator.SetBool("IsOpen", false);

        _animator.Play("Close");

        yield return new WaitForSeconds(1);

        Debug.Log("Попытка вызвать закрытие и отключение объекта");

        gameObject.GetComponent<CanvasGroup>().alpha = 0.0f;

        _isActive = false;
    }

    protected override IEnumerator OnOpenAnimation()
    {
        UIManager.SetBusy(true);
        UIManager.SetCanPlayerMove(false);

        gameObject.GetComponent<CanvasGroup>().alpha = 1.0f;
        _skillsPresenter.PresentObjects();

        _animator.SetBool("IsOpen", true);

        _animator.Play("Open");

        Debug.Log("Попытка вызвать открытие и включение объекта");
        yield return new WaitForSeconds(1);

        _isActive = false;
    }

    public override void StartCloseAnimation()
    {
        if(UIManager.IsBusy() && _animator.GetBool("IsOpen") && !_isActive)
        {
            base.StartCloseAnimation();
        }
    }

    public override void StartOpenAnimation()
    {
        if(!UIManager.IsBusy() && !_animator.GetBool("IsOpen") && !_isActive)
        {
            base.StartOpenAnimation();
        }
    }
}
