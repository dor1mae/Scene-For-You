
using UnityEngine;

public class Enemy : Unit
{
    public Enemy() : base()
    {
        EventBus.onGetEnemy += () =>
        {
            return this;
        };
    }

    public void SelfDestroy()
    {
        DestroyImmediate(gameObject);
    }
}
