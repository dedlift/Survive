public class BaseStat {

    private int _baseValue; //base value
    private int _buffValue; //amount bonused to stat from a buff
    private int _expToLevel; //total amount needed to raise this skill
    private float _levelModifier;   //to modifier applied to the exp needed to raise the skill

    public BaseStat()
    {
        _baseValue = 0;
        _buffValue = 0;
        _levelModifier = 1.1f;
        _expToLevel = 100;
    }

// Basic Setters and Getters
    public int BaseValue
    { 
        get { return _baseValue; }
        set { _baseValue = value; }
    }

    public int BuffValue
    {
        get { return _buffValue; }
        set { _buffValue = value; }
    }
    public int ExpToLevel
    {
        get { return _expToLevel; }
        set { _expToLevel = value; }
    }
    public float LevelModifier
    {
        get { return (int)_levelModifier; }
        set { _levelModifier = value; }
    }

    private int CalculateExpToLevel()
    { return _expToLevel * (int)_levelModifier; }

    public void LevelUp()
    {
        _expToLevel = CalculateExpToLevel();
        _baseValue++;
    }

    public int AdjustedBaseValue()
    {
        return _baseValue + _buffValue;
    }
}
