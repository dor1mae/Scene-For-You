using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private float _durationForCommand = 1;
    [SerializeField] private Transform _content;
    [SerializeField] private GameObject _commandBox;

    private List<Command> commandList = new();

    public event Action OnSequenceEnd;
    public event Action OnSequenceStart;
    public event Action OnSequenceFailed;

    public event Action OnCommandAdd;
    public event Action OnCommandFinished;
    public event Action OnCommandCanceled;

    public void AddCommand(Command command)
    {
        commandList.Add(command);

        var pref = Instantiate(_commandBox);
        pref.GetComponentInChildren<TextMeshProUGUI>().text = command.TurnType.ToString();
        pref.transform.SetParent(_content, false);

        OnCommandAdd?.Invoke();
    }

    public void Undo()
    {
        if(commandList.Count > 0)
        {
            commandList.RemoveAt(commandList.Count - 1);
            OnCommandCanceled?.Invoke();

            CleanContent();
        }
    }

    private void CleanContent()
    {
        foreach (Transform item in _content)
        {
            Destroy(item.gameObject);
        }
    }

    public void Play()
    {
        OnSequenceStart?.Invoke();
        StartCoroutine(ExecuteCommandCoroutine());
        CleanContent();
    }

    private IEnumerator ExecuteCommandCoroutine()
    {
        foreach(var command in commandList)
        {
            var answer = command.TryToExecute();

            if (!answer)
            {
                OnSequenceFailed?.Invoke();
                commandList.Clear();
                yield break;
            }

            OnCommandFinished?.Invoke();
            command.Execute();
            yield return new WaitForSeconds(_durationForCommand);
        }

        OnSequenceEnd?.Invoke();
        commandList.Clear();
        Debug.Log($"{commandList.Count} - число команд после чистки");
    }
}
