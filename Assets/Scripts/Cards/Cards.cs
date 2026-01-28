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


    public static void Load()
    {
        slashOrResist = new Card("slash_or_resist", MindPhase.Prefix.Leadership, MindPhase.Suffix.Firmness);
        slashOrResist.action.CreateDefenseSequence("2:258, 2:852");
        slashOrResist.bonusAction.CreateDefenseSequence("1:168, 1:348, 1:762, 1:942");
        CardPrototypes["slash_or_resist"] = slashOrResist;

        sideParryOrSheathe = new SideParryOrSheathe();
        CardPrototypes["side_parry_or_sheathe"] = sideParryOrSheathe;

        

    }
}
