public class ItemCommand : Command
{
    private Unit initiator;
    private Unit target;
    private RealItem item;

    public ItemCommand(Unit initiator, Unit target, RealItem item)
    {
        this.initiator = initiator;
        this.target = target;
        this.item = item;
    }

    public override void Execute()
    {
        item.Use();
    }

    public override bool TryToExecute()
    {
        return item.TryUse();
    }
}