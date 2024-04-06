public class AttackCommand : Command
{
    private Unit target;
    private Unit initiator;

    public AttackCommand(Unit target, Unit initiator)
    {
        this.target = target;
        this.initiator = initiator;
    }

    public override void Execute()
    {
        target.Durability.Spend(initiator.AttackController.Attack());
    }

    public override bool TryToExecute()
    {
        return true;
    }
}