using System.Collections.Generic;
using UnityEngine;

public static class Cards
{
    public static Dictionary<string, Card> CardPrototypes = new Dictionary<string, Card>();

    public static Card GetPrototype(string id)
    {
        return CardPrototypes[id];
    }

    //基础持刀
    public static Card slashOrResist, sideParryOrSheathe, swordHoldingOrArmTraining,
        breathSkillOrDodge, crossSlashOrArmed;

    //


    public static void Load()
    {
        slashOrResist = new Card("slash_or_resist", MindPhase.Prefix.Leadership, MindPhase.Suffix.Firmness);
        slashOrResist.action.CreateDefenseSequence("2:258, 2:852");
        slashOrResist.bonusAction.CreateDefenseSequence("1:168, 1:348, 1:762, 1:942");
        CardPrototypes["slash_or_resist"] = slashOrResist;

        sideParryOrSheathe = new SideParryOrSheathe();
        CardPrototypes["side_parry_or_sheathe"] = sideParryOrSheathe;

        swordHoldingOrArmTraining = new Card("sword_holding_or_arm_training", MindPhase.Prefix.Leadership, MindPhase.Suffix.Tenderness);
        swordHoldingOrArmTraining.action.CreateDefenseSequence("1:5-3:8");
        swordHoldingOrArmTraining.bonusAction.CreateDefenseSequence("1:5632");
        CardPrototypes["sword_holding_or_arm_training"] = swordHoldingOrArmTraining;

        breathSkillOrDodge = new Card("breath_skill_or_dodge", MindPhase.Prefix.Leadership, MindPhase.Suffix.Responsibility);
        breathSkillOrDodge.action.CreateDefenseSequence("0:1, 0:2, 0:3, 0:4, 0:5, 0:6, 0:7, 0:8, 0:9");
        breathSkillOrDodge.bonusAction.CreateDefenseSequence("2:687, 2:489, 2:987, 2:789, 2:85");
        CardPrototypes["breath_skill_or_dodge"] = breathSkillOrDodge;

        crossSlashOrArmed = new Card("cross_slash_or_armed", MindPhase.Prefix.Leadership, MindPhase.Suffix.Firmness);
        crossSlashOrArmed.action.CreateDefenseSequence("4:456, 4:654, 4:852, 4:258");
        crossSlashOrArmed.bonusAction.CreateDefenseSequence("3:5");
        CardPrototypes["cross_slash_or_armed"] = crossSlashOrArmed;

    }
}
