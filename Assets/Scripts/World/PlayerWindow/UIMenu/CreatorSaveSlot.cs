using UnityEngine;
using System;
using TMPro;

public class CreatorSaveSlot : MonoBehaviour
{
    public Action onCreatedSave;

    public void OnSubmit(TMP_InputField _inputfield)
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            GameManagerSingltone.Instance.SaveScriptableDatabase.Save(_inputfield.text);
            onCreatedSave?.Invoke();
        }
    }
}

