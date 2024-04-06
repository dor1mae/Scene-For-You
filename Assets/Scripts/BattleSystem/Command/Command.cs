public abstract class Command : ICommand
{
    public abstract void Execute();

    public abstract bool TryToExecute();
}
