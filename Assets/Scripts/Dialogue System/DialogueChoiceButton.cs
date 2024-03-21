using UnityEngine;

public class DialogueChoiceButton : MonoBehaviour
{
    private bool _isChoiced = false;
    private DialoguesObject dialoguesObject;

    public bool isChoiced => _isChoiced;

    public DialoguesObject Dialogues
    {
        set { dialoguesObject = value; }
    }

    public void Choiced()
    {
        Debug.Log("Choice is done");

        _isChoiced = true;

        EventBus.DialogStarted?.Invoke(dialoguesObject);
        EventBus.Choiced?.Invoke();
    }
}
