using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private MessageController _messageController;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _npc;

    private Text _playerName;
    private Text _npcName;
    private Image _npcSprite;
    private Queue<DialoguesObject.DialogueObject> _dialogues;

    public void Initialize()
    {
        Debug.Log("DialogueManager is started");
        DialogueStartedEnable();
        _npcName = _npc.GetComponentInChildren<Text>();
        _npcSprite = _npc.GetComponentInChildren<Image>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateMessagePrefab();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            _messageController.CleanMessages();
        }
    }

    private Queue<DialoguesObject.DialogueObject> ArrayToQueue(DialoguesObject d)
    {
        Queue<DialoguesObject.DialogueObject> temp = new Queue<DialoguesObject.DialogueObject>();

        for (int i = 0; i < d.Get.Length; i++)
        {
            temp.Enqueue(d.Get[i]);
        }

        return temp;
    }

    private void CreateMessagePrefab()
    {
        var dialogue = _dialogues.Dequeue();
        _npcName.text = dialogue.Name;
        if (dialogue.Sprite != null)
        {
            _npcSprite.sprite = dialogue.Sprite;
        }

        Debug.Log(dialogue.Choices.Length);
        if (dialogue.Choices.Length == 0)
        {
            _messageController.CreateMessage(dialogue);
        }
        else
        {
            _messageController.CreateChoiceMessage(dialogue);
        }
    }

    private void OnDialogueStarted(DialoguesObject dialogues)
    {
        Debug.Log("Dialogue is started");
        _dialogues = ArrayToQueue(dialogues);

        CreateMessagePrefab();


    }

    private void DialogueStartedEnable()
    {
        EventBus.DialogStarted += OnDialogueStarted;
    }

    private void DialogueStartedDisable()
    {
        EventBus.DialogStarted -= OnDialogueStarted;
    }
}
