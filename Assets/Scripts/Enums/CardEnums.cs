using System.ComponentModel;

public enum NameColor
{
    Black = 0,
    White,
    Shilver,
    Gold,
    Red
}

public enum NameSize
{
    Medium,
    Small
}

public enum Frame
{
    [Description("通常モンスター")]
    NormalMonster = 0,

    [Description("効果モンスター")]
    EffectMonster = 1,

    [Description("儀式モンスター")]
    RitualMonster = 2,

    [Description("融合モンスター")]
    FusionMonster = 3,

    [Description("シンクロモンスター")]
    SynchroMonster = 4,

    [Description("エクシーズモンスター")]
    XyzMonster = 5,

    [Description("通常ペンデュラム")]
    PendulumNormalMonster = 6,

    [Description("効果ペンデュラム")]
    PendulumEffectMonster = 7,

    [Description("儀式ペンデュラム")]
    PendulumRitualMonster = 8,

    [Description("融合ペンデュラム")]
    PendulumFusionMonster = 9,

    [Description("シンクロペンデュラム")]
    PendulumSynchroMonster = 10,

    [Description("エクシーズペンデュラム")]
    PendulumXyzMonster = 11,

    [Description("リンクモンスター")]
    LinkMonster = 12,

    [Description("通常魔法")]
    NormalSpell = 13,

    [Description("速攻魔法")]
    QuickPlaySpell = 14,

    [Description("永続魔法")]
    ContinuousSpell = 15,

    [Description("装備魔法")]
    EquipSpell = 16,

    [Description("儀式魔法")]
    RitualSpell = 17,

    [Description("フィールド魔法")]
    FieldSpell = 18,

    [Description("通常罠")]
    NormalTrap = 19,

    [Description("永続罠")]
    ContinuousTrap = 20,

    [Description("カウンター罠")]
    CounterTrap = 21,

    [Description("トークン")]
    Token = 22,

    [Description("トークン(記述可)")]
    TokenOptional = 23
}

public enum MonsterAttribute
{
    Darkness,
    Light,
    Earth,
    Water,
    Flame,
    Wind,
    God
}

public enum MonsterLevel
{
    Zero,
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Sevel,
    Eight,
    Nine,
    Ten,
    Elevel,
    Twelve
}

public enum TextSize
{
    Large,
    Medium,
    Small
}

public enum PendulumTextSize
{
    Medium,
    Small
}

public enum PendulumNumBlue
{
    Zero,
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Sevel,
    Eight,
    Nine,
    Ten,
    Elevel,
    Twelve,
    Thirteen
}

public enum PendulumNumRed
{
    Zero,
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Sevel,
    Eight,
    Nine,
    Ten,
    Elevel,
    Twelve,
    Thirteen
}

public enum LinkNum
{
    Zero,
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight
}

public enum LinkPosition
{
    UpperLeft,
    Up,
    UpperRight,
    Left,
    Right,
    LowerLeft,
    Down,
    LowerRight
}
