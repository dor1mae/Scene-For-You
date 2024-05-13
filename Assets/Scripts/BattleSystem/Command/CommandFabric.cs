public class CommandFabric
{
    private Unit _target;
    private Unit _initiator;

    public CommandFabric(Unit target, Unit initiator)
    {
        _target = target;
        _initiator = initiator;
    }

    public Command AddSimpleAttackCommand()
    {
        return new AttackCommand(_target, _initiator);
    }

    public Command AddSkillCommand(Skill _skill)
    {
        return new SkillCommand(_target, _initiator, _skill);
    }

    public Command AddSkipCommand()
    {
        return new SkipCommand(_initiator);
    }

    public Command AddItemCommand(RealItem item)
    {
        return new ItemCommand(_initiator, _target, item);
    }
}

