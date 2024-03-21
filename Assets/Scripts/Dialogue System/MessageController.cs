using UnityEngine;


//Скрипт для текстового поля, который выполняет функцию его заполнения сообщениями и очистки
public class MessageController : MonoBehaviour
{
    [SerializeField] GameObject _pfMessage;
    [SerializeField] GameObject _pfChoicePanel;
    [SerializeField] GameObject _pfChoiceButton;

    private RectTransform _content;
    private RectTransform _lastChoicePanel;

    public void Initialize()
    {
        _content = GetComponent<RectTransform>();
        ChoicedEnable();
    }

    private void OnChoiced()
    {
        foreach (Transform t in _lastChoicePanel)
        {
            var temp = t.GetComponent<DialogueChoiceButton>();

            if (!temp.isChoiced)
            {
                Destroy(t.gameObject);
            }
            else
            {
                Destroy(temp);
            }
        }
    }

    private void ChoicedEnable()
    {
        EventBus.Choiced += OnChoiced;
    }

    private void ChoicedDisable()
    {
        EventBus.Choiced -= OnChoiced;
    }

    public void CreateMessage(DialoguesObject.DialogueObject _d)
    {
        var message = Instantiate(_pfMessage);
        message.transform.SetParent(this.gameObject.transform, false);
        var m = message.GetComponentInChildren<Message>();
        m.SetData(_d.Name, _d.Words);
    }

    public void CreateChoiceMessage(DialoguesObject.DialogueObject _d)
    {
        //Ключевая фраза, после которой идет выбор
        var message = Instantiate(_pfMessage);
        message.transform.SetParent(this.transform, false);
        message.GetComponentInChildren<Message>().SetData(_d.Name, _d.Words);

        //Поле для вариантов ответа
        var choicePanel = Instantiate(_pfChoicePanel);
        choicePanel.transform.SetParent(this.gameObject.transform, false);
        _lastChoicePanel = choicePanel.GetComponent<RectTransform>();

        //Варианты ответа
        int i = 1;
        foreach (DialoguesObject.ChoiceElement c in _d.Choices)
        {
            var choiceButton = Instantiate(_pfChoiceButton);
            choiceButton.transform.SetParent(choicePanel.transform, false);

            choiceButton.GetComponent<Message>().SetData(i.ToString(), c.Text);
            choiceButton.GetComponent<DialogueChoiceButton>().Dialogues = c.Choice;

            i++;
        }
    }

    public void CleanMessages()
    {
        foreach (Transform m in _content)
        {
            Destroy(m.gameObject);
        }
    }
}
