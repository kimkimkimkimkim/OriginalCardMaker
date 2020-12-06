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

[Description("枠の種類")]
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

[Description("属性")]
public enum MonsterAttribute
{
    [Description("闇")]
    Darkness = 0,

    [Description("光")]
    Light = 1,

    [Description("地")]
    Earth = 2,

    [Description("水")]
    Water = 3,

    [Description("炎")]
    Flame = 4,

    [Description("風")]
    Wind = 5,

    [Description("神")]
    God = 6
}

[Description("レベル・ランク")]
public enum MonsterLevel
{
    [Description("0")]
    Zero = 0,

    [Description("1")]
    One = 1,

    [Description("2")]
    Two = 2,

    [Description("3")]
    Three = 3,

    [Description("4")]
    Four = 4,

    [Description("5")]
    Five = 5,

    [Description("6")]
    Six = 6,

    [Description("7")]
    Sevel = 7,

    [Description("8")]
    Eight = 8,

    [Description("9")]
    Nine = 9,

    [Description("10")]
    Ten = 10,

    [Description("11")]
    Elevel = 11,

    [Description("12")]
    Twelve = 12
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
