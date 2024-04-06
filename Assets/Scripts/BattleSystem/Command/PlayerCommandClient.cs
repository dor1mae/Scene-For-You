using static UnityEngine.GraphicsBuffer;

public class PlayerCommandClient : CommandClient
{
    public void AddSimpleAttackCommand()
    {
        CreateFabric();

        _turnManager.AddCommand(_commandFabric.AddSimpleAttackCommand());
    }

    public void AddSkillCommand(Skill _skill)
    {
        CreateFabric();

        _turnManager.AddCommand(_commandFabric.AddSkillCommand(_skill));
    }

    public void AddSkipCommand()
    {
        CreateFabric();

        _turnManager.AddCommand(_commandFabric.AddSkipCommand());
    }

    public void AddItemCommand(RealItem item)
    {
        CreateFabric();

        _turnManager.AddCommand(_commandFabric.AddItemCommand(item));
    }

    protected override void CreateFabric()
    {
        if(_commandFabric == null)
        {
            _commandFabric = new CommandFabric(BattleSystem.OnGetEnemy.Invoke(), BattleSystem.OnGetPlayer.Invoke());
        }
    }
}
