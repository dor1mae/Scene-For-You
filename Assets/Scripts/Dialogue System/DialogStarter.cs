using UnityEngine;

public interface DialogStarter
{
    public void StartDialogue();
}

public abstract class DialogTrigger : MonoBehaviour, DialogStarter
{
    [SerializeField] protected DialoguesObject _dialogues;
    public abstract void StartDialogue();
}