public abstract class Command : ICommand
{
    protected TurnType _turnType;
    public TurnType TurnType => _turnType;
    public abstract void Execute();

    public abstract bool TryToExecute();
}
