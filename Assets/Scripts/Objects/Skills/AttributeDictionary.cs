using System.Collections.Generic;

public class AttributeDictionary : IDictionary<AttributeType, Stat>
{
    private Dictionary<AttributeType, Stat> _attributes;

    public AttributeDictionary()
    {
        var player = GameManagerSingltone.Instance.Player;

        _attributes = new Dictionary<AttributeType, Stat>
        {
            {AttributeType.ENDURANCE,  player.Endurance},
            {AttributeType.INTELLIGENCE, player.Intelligence },
            {AttributeType.POWER, player.Power},
            {AttributeType.DEXTERITY, player.Dexterity },
            {AttributeType.DURABILITY, player.Durability},
        };

    }

    public Dictionary<AttributeType, Stat> _dict
    { 
        get => _attributes;
    }
}

