using Unity.VisualScripting;

public class StatView
{
    private Dexterity _realDexterity;
    private Intelligence _realIntelligence;
    private Power _realPower;
    private Durability _realDurability;
    private Endurance _realEndurance;

    private Dexterity _viewDexterity;
    private Intelligence _viewIntelligence;
    private Power _viewPower;
    private Durability _viewDurability;
    private Endurance _viewEndurance;

    public StatView(Dexterity dex, Intelligence intel, Power pw, Durability dr, Endurance end, Unit owner)
    {
        _viewDexterity = dex;
        _viewIntelligence = intel;
        _viewPower = pw;
        _viewDurability = dr;
        _viewEndurance = end;

        _realDexterity = new(dex.Value);
        _realDurability = new(dr.Value, owner);
        _realEndurance = new(end.Value);
        
    }
}
