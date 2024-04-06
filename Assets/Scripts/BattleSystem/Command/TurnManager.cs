using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private float _durationForCommand = 1;
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
        OnCommandAdd?.Invoke();
    }

    public void Undo()
    {
        if(commandList.Count > 0)
        {
            commandList.RemoveAt(commandList.Count - 1);
            OnCommandCanceled?.Invoke();
        }
    }

    public void Play()
    {
        OnSequenceStart?.Invoke();
        StartCoroutine(ExecuteCommandCoroutine());
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
    }
}
