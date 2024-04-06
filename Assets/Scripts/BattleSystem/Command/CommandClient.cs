using UnityEngine;

public abstract class CommandClient : MonoBehaviour
{ 
    [SerializeField] protected TurnManager _turnManager;
    protected CommandFabric _commandFabric;

    public void AddCommand(Command command)
    {
        _turnManager.AddCommand(command);
    }

    protected abstract void CreateFabric();
}
