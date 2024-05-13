public interface ICommand
{
    void Execute();
    bool TryToExecute();
}
