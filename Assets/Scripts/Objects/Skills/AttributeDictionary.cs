using System.Collections.Generic;

public class AttributeDictionary : IDictionary<AttributeType, Stat>
{
    private Dictionary<AttributeType, Stat> _attributes;

    public AttributeDictionary(Unit unit)
    {

        _attributes = new Dictionary<AttributeType, Stat>
        {
            {AttributeType.ENDURANCE,  unit.Endurance},
            {AttributeType.INTELLIGENCE, unit.Intelligence },
            {AttributeType.POWER, unit.Power},
            {AttributeType.DEXTERITY, unit.Dexterity },
            {AttributeType.DURABILITY, unit.Durability},
        };

    }

    public Dictionary<AttributeType, Stat> _dict
    { 
        get => _attributes;
    }
}

