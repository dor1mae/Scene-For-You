using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LoadSceneController : InitClass, IWorkWithScene
{
    [SerializeField] private Image _progressBar;
    [SerializeField] private TextMeshProUGUI _text;

    private int _selfId = 3;

    public override void Init()
    {
        _progressBar.fillAmount = 0;
        _text.text = $"{0}%";

        Debug.Log("Инициализация экрана загрузки");

        SceneTransferManager.onRequestScene?.Invoke(this);
    }

    public void LoadScene(Action<bool> callback = null, int sceneID = default)
    {
        Debug.Log(sceneID);

        StartCoroutine(LoadSceneAsync(sceneID));
    }

    private IEnumerator LoadSceneAsync(int sceneNumber) 
    {
        UnityEngine.AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneNumber, LoadSceneMode.Additive);

        while (!asyncOperation.isDone)
        {
            _progressBar.fillAmount = asyncOperation.progress * 100;
            _text.text = $"{asyncOperation.progress * 100}%";
            yield return null;
        }

        UnloadScene();
    }

    public void UnloadScene(Action<bool> callback = null)
    {
        SceneManager.UnloadSceneAsync(_selfId);
    }
}
