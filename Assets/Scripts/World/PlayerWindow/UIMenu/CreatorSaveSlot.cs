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
            var json = new JsonFileToStorageSaveManager();

            json.Save(_inputfield.text, new Save(_inputfield.text));
            onCreatedSave?.Invoke();
        }
    }
}

