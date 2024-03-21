using UnityEngine;

public class BootstrapDialogSystem : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private DialogTriggerWithoutArea withoutArea;
    [SerializeField] private MessageController messageController;

    private void Start()
    {
        dialogueManager.Initialize();
        withoutArea.Initialize();
        messageController.Initialize();
    }
}
