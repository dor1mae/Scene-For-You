using System.Collections;
using UnityEngine;

public class IngameMenuWindow : MonoBehaviour
{
    [SerializeField] Animator _animator;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !UIManager.IsBusy() && !_animator.GetBool("IsOpen"))
        {
            StartCoroutine(OnMenuWindowOpen());
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && UIManager.IsBusy() && _animator.GetBool("IsOpen"))
        {
            StartCoroutine(OnMenuWindowClose());
        }
    }

    private IEnumerator OnMenuWindowClose()
    {
        UIManager.SetBusy(false);
        _animator.SetBool("IsOpen", false);

        yield return null;

        gameObject.GetComponent<CanvasGroup>().alpha = 0f;
    }

    private IEnumerator OnMenuWindowOpen()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 1.0f;
        UIManager.SetBusy(true);

        yield return null;

        _animator.SetBool("IsOpen", true);
    }
}
