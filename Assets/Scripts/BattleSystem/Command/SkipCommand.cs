public class SkipCommand : Command
{
    private Unit initiator;

    public SkipCommand(Unit initiator)
    {
        this.initiator = initiator;
    }

    public override void Execute()
    {
        initiator.Endurance.Restore(initiator.Endurance.Value * 5);
    }

    public override bool TryToExecute()
    {
        return true;
    }
}