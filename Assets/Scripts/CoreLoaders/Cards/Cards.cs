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

    //心镇设定集
    public static Card spiritOrHeartLib ,  knowledgeOrBook , bondOrSupporter ,
        changeOrLevel , futureOrEnding;

    /// <summary>
    /// 加载卡牌数据 其他的CoreLoader的XXXs.cs的Load也同理
    /// </summary>
    public static void Load()
    {
        //《心镇设定集》
        //精神世界 & 心镇
        spiritOrHeartLib = new Card("spirit_or_heartlib", MindPhase.Prefix.Leadership, MindPhase.Suffix.Firmness);
        CardPrototypes["spirit_or_heartlib"] = spiritOrHeartLib;

        //知识 & 书籍
        knowledgeOrBook = new Card("knowledge_or_book", MindPhase.Prefix.Leadership, MindPhase.Suffix.Confidence);
        CardPrototypes["knowledge_or_book"] = knowledgeOrBook;

        //羁绊关系 & 协助者
        bondOrSupporter = new Card("bond_or_supporter", MindPhase.Prefix.Leadership, MindPhase.Suffix.Tenderness);
        CardPrototypes["bond_or_supporter"] = bondOrSupporter;

        //改变 & 关卡
        changeOrLevel = new Card("change_or_level", MindPhase.Prefix.Leadership, MindPhase.Suffix.Responsibility);
        CardPrototypes["change_or_level"] = changeOrLevel;

        //未来 & 结局
        futureOrEnding = new Card("future_or_ending", MindPhase.Prefix.Leadership, MindPhase.Suffix.Firmness);
        CardPrototypes["future_or_ending"] = futureOrEnding;

        //《基础持刀》
        //直斩 & 抵剑
        slashOrResist = new Card("slash_or_resist", MindPhase.Prefix.Leadership, MindPhase.Suffix.Firmness);
        slashOrResist.action.CreateDefenseSequence("2:258, 2:852");
        slashOrResist.bonusAction.CreateDefenseSequence("1:168, 1:348, 1:762, 1:942");
        CardPrototypes["slash_or_resist"] = slashOrResist;

        //侧挡 & 收刀
        sideParryOrSheathe = new SideParryOrSheathe();
        CardPrototypes["side_parry_or_sheathe"] = sideParryOrSheathe;

        //握剑姿态 & 臂力训练
        swordHoldingOrArmTraining = new Card("sword_holding_or_arm_training", MindPhase.Prefix.Leadership, MindPhase.Suffix.Tenderness);
        swordHoldingOrArmTraining.action.CreateDefenseSequence("1:5-3:8");
        swordHoldingOrArmTraining.bonusAction.CreateDefenseSequence("1:5632");
        CardPrototypes["sword_holding_or_arm_training"] = swordHoldingOrArmTraining;

        //呼吸法 & 闪避步伐
        breathSkillOrDodge = new Card("breath_skill_or_dodge", MindPhase.Prefix.Leadership, MindPhase.Suffix.Responsibility);
        breathSkillOrDodge.action.CreateDefenseSequence("0:1, 0:2, 0:3, 0:4, 0:5, 0:6, 0:7, 0:8, 0:9");
        breathSkillOrDodge.bonusAction.CreateDefenseSequence("2:687, 2:489, 2:987, 2:789, 2:85");
        CardPrototypes["breath_skill_or_dodge"] = breathSkillOrDodge;

        //封底牌：十字力斩 & 付诸武力
        crossSlashOrArmed = new Card("cross_slash_or_armed", MindPhase.Prefix.Leadership, MindPhase.Suffix.Firmness);
        crossSlashOrArmed.action.CreateDefenseSequence("4:456, 4:654, 4:852, 4:258");
        crossSlashOrArmed.bonusAction.CreateDefenseSequence("3:5");
        CardPrototypes["cross_slash_or_armed"] = crossSlashOrArmed;

    }
}
