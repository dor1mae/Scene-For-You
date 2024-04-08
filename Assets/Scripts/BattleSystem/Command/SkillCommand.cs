using UnityEngine;

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

        _turnType = TurnType.Skill;
    }

    public override void Execute()
    {
        //Debug.Log($"{skill.GetType()}, {skill.SkillName}");

        skill.Use();
    }

    public override bool TryToExecute()
    {
        Debug.Log($"{skill.GetType()}, {skill.SkillName}");

        return skill.TryCast();
    }
}