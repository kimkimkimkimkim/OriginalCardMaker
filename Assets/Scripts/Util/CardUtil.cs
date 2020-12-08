using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardUtil
{
    public static string GetInitialMonsterText(Frame frame)
    {
        switch (frame)
        {
            case Frame.NormalMonster:
                return "【●族】";
            case Frame.EffectMonster:
                return "【●族／効果】";
            case Frame.RitualMonster:
                return "【●族／儀式／効果】";
            case Frame.FusionMonster:
                return "【●族／融合／効果】";
            case Frame.SynchroMonster:
                return "【●族／シンクロ／効果】";
            case Frame.XyzMonster:
                return "【●族／エクシーズ／効果】";
            case Frame.PendulumNormalMonster:
                return "【●族／ペンデュラム】";
            case Frame.PendulumEffectMonster:
                return "【●族／ペンデュラム／効果】";
            case Frame.PendulumRitualMonster:
                return "【●族／儀式／ペンデュラム／効果】";
            case Frame.PendulumFusionMonster:
                return "【●族／融合／ペンデュラム／効果】";
            case Frame.PendulumSynchroMonster:
                return "【●族／シンクロ／ペンデュラム／効果】";
            case Frame.PendulumXyzMonster:
                return "【●族／エクシーズ／ペンデュラム／効果】";
            case Frame.LinkMonster:
                return "【●族／リンク／効果】";
            case Frame.TokenOptional:
                return "【●族／効果】";
            case Frame.NormalSpell:
            case Frame.QuickPlaySpell:
            case Frame.ContinuousSpell:
            case Frame.EquipSpell:
            case Frame.RitualSpell:
            case Frame.FieldSpell:
            case Frame.NormalTrap:
            case Frame.ContinuousTrap:
            case Frame.CounterTrap:
            case Frame.Token:
            default:
                return "";
        }
    }

    public static Color GetColor(NameColor nameColor)
    {
        switch (nameColor)
        {
            case NameColor.Black:
                return new Color(0.0f, 0.0f, 0.0f);
            case NameColor.White:
                return new Color(0.95f, 0.95f, 0.95f);
            case NameColor.Shilver:
                return new Color(0.77f, 0.77f, 0.77f);
            case NameColor.Gold:
                return new Color(0.77f, 0.77f, 0.0f);
            case NameColor.Red:
                return new Color(0.77f, 0.05f, 0.05f);
            default:
                return new Color(0.0f, 0.0f, 0.0f);
        }
    }

    public static int GetSize(NameSize nameSize)
    {
        switch (nameSize)
        {
            case NameSize.Medium:
                return 70;
            case NameSize.Small:
                return 50;
            default:
                return 70;
        }
    }

    public static int GetSize(TextSize textSize)
    {
        switch (textSize)
        {
            case TextSize.Large:
                return 37;
            case TextSize.Medium:
                return 31;
            case TextSize.Small:
                return 23;
            default:
                return 31;
        }
    }

    public static int GetSize(PendulumTextSize pendulumTextSize)
    {
        switch (pendulumTextSize)
        {
            case PendulumTextSize.Medium:
                return 30;
            case PendulumTextSize.Small:
                return 22;
            default:
                return 30;
        }
    }
}
