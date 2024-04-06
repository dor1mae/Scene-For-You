public class SkillCommand : Command
{
    private Unit target;
    private Unit initiator;
    private Skill skill;

    public SkillCommand(Unit target, Unit initiator, Skill skill)
    {
        this.target = target;
        this.initiator = initiator;
        this.skill = skill;
    }

    public override void Execute()
    {
        skill.Use();
    }

    public override bool TryToExecute()
    {
        return skill.TryCast();
    }
}