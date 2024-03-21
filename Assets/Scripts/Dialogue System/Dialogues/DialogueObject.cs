using UnityEngine;

[CreateAssetMenu(menuName = "Asset/Data")]
public class DialoguesObject : ScriptableObject
{
    [SerializeField] private DialogueObject[] _dialogueObject;
    public DialogueObject[] Get => _dialogueObject;

    [System.Serializable]
    public class DialogueObject
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _sprite;
        [SerializeField][TextArea(3, 5)] private string _words;
        [SerializeField] private ChoiceElement[] _choice;

        public string Name => _name;
        public Sprite Sprite => _sprite;
        public string Words => _words;
        public ChoiceElement[] Choices => _choice;
    }

    [System.Serializable]
    public class ChoiceElement
    {
        [SerializeField] private string _text;
        [SerializeField] private DialoguesObject _dialogueObject;

        public string Text => _text;
        public DialoguesObject Choice => _dialogueObject;
    }


}
