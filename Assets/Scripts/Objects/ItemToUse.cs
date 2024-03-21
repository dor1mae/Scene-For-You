#if UNITY_EDITOR
#endif
public abstract class ItemToUse : ItemEmpty
{
    public override bool isUsable => true;
    public abstract bool IsHarmful { get; }
    public abstract void Use(Unit go);
    public abstract void Init();
    public abstract ActionData GetActionData();
}


