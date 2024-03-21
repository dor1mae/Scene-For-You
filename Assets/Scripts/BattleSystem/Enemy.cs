
public class Enemy : Unit
{
    public Enemy() : base()
    {
        EventBus.onGetEnemy += () =>
        {
            return this;
        };
    }
}
