using System.Collections.Generic;

public class SkillDictionary : IDictionary<AttributeType, Stat>
{
    private Dictionary<AttributeType, Stat> _skills;

    public SkillDictionary()
    {
        var player = GameManagerSingltone.Instance.Player;

        _skills = new();

    }

    public Dictionary<AttributeType, Stat> _dict
    {
        get => _skills;
    }
}
