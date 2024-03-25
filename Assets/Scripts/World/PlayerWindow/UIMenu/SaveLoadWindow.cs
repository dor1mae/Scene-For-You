using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadWindow : AbstractUIWindow
{
    [SerializeField] protected GameObject _saveSlotPrefab;
    [SerializeField] protected GameObject _toSaveGameButton;
    [SerializeField] protected GameObject _buttonToLoadGame;
    [SerializeField] protected Transform _content;
    protected AbstractObjectPresenter _presenter; //Позаботься о том, чтобы класс удалялся каждый раз, когда окно закрывается
    protected bool _isLoad = true;

    public override void Init() { }

    public void SetStateOfWindow(bool beh)
    {
        _isLoad = beh;

        if(_isLoad)
        {
            _presenter = new LoadSlotsPresenter(_buttonToLoadGame, _saveSlotPrefab, _content);
            _presenter.PresentObjects();
        }
        else
        {
            _presenter = new SaveSlotsPresenter(_buttonToLoadGame, _saveSlotPrefab, _toSaveGameButton, _content);
            _presenter.PresentObjects();
        }
    }

    protected override IEnumerator OnCloseAnimation()
    {
        _animator.SetBool("IsOpen", false);

        _animator.Play("Close");

        yield return new WaitForSeconds(1);

        Debug.Log("Попытка вызвать закрытие и отключение объекта");

        gameObject.GetComponent<CanvasGroup>().alpha = 0.0f;

        onEndAnimation?.Invoke();
    }


    protected override IEnumerator OnOpenAnimation()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 1.0f;

        _animator.SetBool("IsOpen", true);

        _animator.Play("Open");

        Debug.Log("Попытка вызвать открытие и включение объекта");
        yield return new WaitForSeconds(1);

        onEndAnimation?.Invoke();
    }
}
