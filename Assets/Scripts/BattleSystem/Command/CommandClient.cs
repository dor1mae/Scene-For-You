using UnityEngine;

public abstract class CommandClient : InitClass
{ 
    [SerializeField] protected TurnManager _turnManager;
    [SerializeField] protected BattleSystem _battleSystem;
    protected CommandFabric _commandFabric;

    protected Unit _owner;
    protected ActionPointChecker _actionPointChecker;

	public void AddSimpleAttackCommand()
	{
		if (!CheckOpportunity())
		{
			return;
		}

		CreateFabric();
		_turnManager.AddCommand(_commandFabric.AddSimpleAttackCommand());
	}

	public void AddSkillCommand(Skill _skill)
	{
		if (!CheckOpportunity())
		{
			return;
		}

		CreateFabric();

		_turnManager.AddCommand(_commandFabric.AddSkillCommand(_skill));
	}

	public void AddSkipCommand()
	{
		if (!CheckOpportunity())
		{
			return;
		}

		CreateFabric();

		_turnManager.AddCommand(_commandFabric.AddSkipCommand());
	}

	public void AddItemCommand(RealItem item)
	{
		if (!CheckOpportunity())
		{
			return;
		}

		CreateFabric();

		_turnManager.AddCommand(_commandFabric.AddItemCommand(item));
	}

	protected abstract bool CheckOpportunity();

    protected abstract void CreateFabric();
}
