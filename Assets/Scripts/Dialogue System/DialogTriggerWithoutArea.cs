using UnityEngine;

public class DialogTriggerWithoutArea : DialogTrigger
{
    public void Initialize()
    {
        Debug.Log("DialogTriggerWithoutArea is started");
        StartDialogue();
    }

    public override void StartDialogue()
    {
        EventBus.DialogStarted?.Invoke(_dialogues);
    }
}
