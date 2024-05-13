public interface IState<T> : IEnum<T>
{
    void Enter();
    void Exit();
}