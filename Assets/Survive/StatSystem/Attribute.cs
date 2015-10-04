public class Attribute : BaseStat {
    //test
    public Attribute()
    {
        ExpToLevel = 50;
        LevelModifier = 1.05f;
    }
}

public enum AttributeName
{
    Brawn,  //STR power brawn
    Vitality,   //CON vitality stamina endurance toughness
    Agility,    //DEX quickness
    Intellect,  //INT intelligence intellect wits cunning
    Wisdom //WIS wits awareness perception
}