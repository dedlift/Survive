public class Attribute : BaseStat {

    public Attribute()
    {
        ExpToLevel = 50;
        LevelModifier = 1.05f;
    }
}

public enum AttributeName
{
    Brawn,  //STR strength
    Agility,    //DEX dexterity
    Vitality,   //CON stamina
    Intellect,  //INT intelligence
    Wisdom, //WIS wits
    Awareness,  //WIS perception
    Charm,  //CHA charisma
    Cunning,    //CHA manipulation
    Looks   //CHA looks
}