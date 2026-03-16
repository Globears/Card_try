using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 负责加载所有卡牌数据的静态类
/// </summary>
public static class Cards
{
    private static MultiKeyDictionary<string, string, Card> CardPrototypes = new MultiKeyDictionary<string, string, Card>();
    public static Card GetPrototypeById(string id){
        return CardPrototypes.GetByKey1(id);
    }
    public static Card GetPrototypeByName(string card_name){
        return CardPrototypes.GetByKey2(card_name);
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
    public static void Load(){
        //《心镇设定集》
        LoadBook1();
        //《基础持刀》
        LoadBook2();
    }

    private static void LoadBook1() {
        //《心镇设定集》
        //精神世界 & 心镇
        // 精神世界（正）
        // 领袖的 坚定
        // 2力：13579
        // 心镇（反）
        // 领袖的 坚定
        // 1力：2456
        spiritOrHeartLib = new Card("B01C01","spirit_or_heartlib", MindPhase.Prefix.Leadership, MindPhase.Suffix.Firmness);
        spiritOrHeartLib.action.CreateDefenseSequence("2:13579");
        spiritOrHeartLib.bonusAction.CreateDefenseSequence("1:2456");
        CardPrototypes.Add("B01C01", "spirit_or_heartlib", spiritOrHeartLib);

        //知识 & 书籍
        knowledgeOrBook = new KnowledgeOrBook();
        CardPrototypes.Add("B01C02", "knowledge_or_book", knowledgeOrBook);

        //羁绊关系 & 协助者
        // 羁绊关系（正）
        // 领袖的 温柔
        // 1力：536842
        // 协助者（反）
        // 领袖的 温柔
        // 3力：5
        bondOrSupporter = new Card("B01C03","bond_or_supporter", MindPhase.Prefix.Leadership, MindPhase.Suffix.Tenderness);
        bondOrSupporter.action.CreateDefenseSequence("1:536842");
        bondOrSupporter.bonusAction.CreateDefenseSequence("3:5");
        CardPrototypes.Add("B01C03", "bond_or_supporter", bondOrSupporter);

        //改变 & 关卡
        // 改变（正）
        // 领袖的 责任
        // 2力：1651
        // 关卡（反）
        // 领袖的 责任
        // 2力：24，86
        changeOrLevel = new Card("B01C04","change_or_level", MindPhase.Prefix.Leadership, MindPhase.Suffix.Responsibility);
        changeOrLevel.action.CreateDefenseSequence("2:1651");
        changeOrLevel.bonusAction.CreateDefenseSequence("2:24,2:86");
        CardPrototypes.Add("B01C04", "change_or_level", changeOrLevel);

        //未来 & 结局
        // 封底（4/4）
        // 未来（正）
        // 领袖的坚定
        // 3力：123456789
        // 结局（反）
        // 6力：1，5，9
        futureOrEnding = new Card("B01C05","future_or_ending", MindPhase.Prefix.Leadership, MindPhase.Suffix.Firmness);
        futureOrEnding.action.CreateDefenseSequence("3:123456789");
        futureOrEnding.bonusAction.CreateDefenseSequence("6:1,6:5,6:9");
        futureOrEnding.IsCoverCard = true; //设定为封底牌
        futureOrEnding.cardTags.Add(TAGS.COVER);
        CardPrototypes.Add("B01C05", "future_or_ending", futureOrEnding);
    }

    public static void LoadBook2() {
        //《基础持刀》
        //直斩 & 抵剑
        // 直斩（正）
        // 领袖的 坚定
        // 2力：258
        // 抵剑（反）
        // 领袖的 坚定
        // 1力：168，348
        slashOrResist = new Card("B02C01","slash_or_resist", MindPhase.Prefix.Leadership, MindPhase.Suffix.Firmness);
        slashOrResist.action.CreateDefenseSequence("2:258");
        slashOrResist.bonusAction.CreateDefenseSequence("1:168, 1:348,");
        CardPrototypes.Add("B02C01", "slash_or_resist", slashOrResist);

        //侧挡 & 收刀
        // 侧挡（正）
        // 领袖的 自信
        // 1力：56341
        // 绽放（2坚定）：具有+2力度
        // 收刀（反）
        // 领袖的 自信
        // 1力：51，52，54，56
        // 共鸣（领袖的）：具有力度+1
        // 共鸣（自信）：具有力度+1
        sideParryOrSheathe = new SideParryOrSheathe();
        CardPrototypes.Add("B02C02", "side_parry_or_sheathe", sideParryOrSheathe);

        //握剑姿态 & 臂力训练
        // 侧挡（正）
        // 领袖的 自信
        // 1力：56341
        // 绽放（2坚定）：具有+2力度
        // 收刀（反）
        // 领袖的 自信
        // 1力：51，52，54，56
        // 共鸣（领袖的）：具有力度+1
        // 共鸣（自信）：具有力度+1
        swordHoldingOrArmTraining = new Card("B02C03","sword_holding_or_arm_training", MindPhase.Prefix.Leadership, MindPhase.Suffix.Tenderness);
        swordHoldingOrArmTraining.action.CreateDefenseSequence("1:5-3:8");
        swordHoldingOrArmTraining.bonusAction.CreateDefenseSequence("1:5632");
        CardPrototypes.Add("B02C03", "sword_holding_or_arm_training", swordHoldingOrArmTraining);

        //呼吸法 & 闪避步伐
        breathSkillOrDodge = new Card("B02C04","breath_skill_or_dodge", MindPhase.Prefix.Leadership, MindPhase.Suffix.Responsibility);
        breathSkillOrDodge.action.CreateDefenseSequence("0:1, 0:2, 0:3, 0:4, 0:5, 0:6, 0:7, 0:8, 0:9");
        breathSkillOrDodge.bonusAction.CreateDefenseSequence("2:687, 2:489, 2:987, 2:789, 2:85");
        CardPrototypes.Add("B02C04", "breath_skill_or_dodge", breathSkillOrDodge);

        //封底牌：十字力斩 & 付诸武力
        crossSlashOrArmed = new Card("B02C05","cross_slash_or_armed", MindPhase.Prefix.Leadership, MindPhase.Suffix.Firmness);
        crossSlashOrArmed.action.CreateDefenseSequence("4:456, 4:654, 4:852, 4:258");
        crossSlashOrArmed.bonusAction.CreateDefenseSequence("3:5");
        crossSlashOrArmed.IsCoverCard = true; //设定为封底牌
        CardPrototypes.Add("B02C05", "cross_slash_or_armed", crossSlashOrArmed);
    }

    public static void LoadBook3() {
        
    }
}
