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
    NormalMonster,

    [Description("効果モンスター")]
    EffectMonster,

    [Description("儀式モンスター")]
    RitualMonster,

    [Description("融合モンスター")]
    FusionMonster,

    [Description("シンクロモンスター")]
    SynchroMonster,

    [Description("エクシーズモンスター")]
    XyzMonster,

    [Description("通常ペンデュラム")]
    PendulumNormalMonster,

    [Description("効果ペンデュラム")]
    PendulumEffectMonster,

    [Description("儀式ペンデュラム")]
    PendulumRitualMonster,

    [Description("融合ペンデュラム")]
    PendulumFusionMonster,

    [Description("シンクロペンデュラム")]
    PendulumSynchroMonster,

    [Description("エクシーズペンデュラム")]
    PendulumXyzMonster,

    [Description("リンクモンスター")]
    LinkMonster,

    [Description("通常魔法")]
    NormalSpell,

    [Description("速攻魔法")]
    QuickPlaySpell,

    [Description("永続魔法")]
    ContinuousSpell,

    [Description("装備魔法")]
    EquipSpell,

    [Description("儀式魔法")]
    RitualSpell,

    [Description("フィールド魔法")]
    FieldSpell,

    [Description("通常罠")]
    NormalTrap,

    [Description("永続罠")]
    ContinuousTrap,

    [Description("カウンター罠")]
    CounterTrap,

    [Description("トークン")]
    Token,

    [Description("トークン(記述可)")]
    TokenOptional
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
