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

    //插页
    public static Card insertImage;

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
        Debug.Log("开始加载卡牌原型");
        // 插图
        LoadPublicCard();
        //《心镇设定集》
        LoadBook1();
        //《基础持刀》
        LoadBook2();



        Debug.Log("加载卡牌原型完毕");
    }

    private static void LoadPublicCard() {
        Debug.Log("加载插图");
        insertImage = new InsertImage();
        //insertImage.action.CreateDefenseSequence("1:12,1:23,1:34,1:45,1:56,1:67,1:78,1:89");
        //insertImage.bonusAction.CreateDefenseSequence("");
        CardPrototypes.Add("B00C01","insert_image",insertImage);
    }

    private static void LoadBook1() {
        Debug.Log("加载《心镇设定集》");
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

        // 羁绊关系（正）
        // 领袖的 温柔
        // 1力：536841
        // tag：

        // 协助者（反）
        // 领袖的 温柔
        // 3力：5
        // tag：
        bondOrSupporter = new Card("B01C03","bond_or_supporter", MindPhase.Prefix.Leadership, MindPhase.Suffix.Tenderness);
        bondOrSupporter.action.CreateDefenseSequence("1:536841");
        bondOrSupporter.bonusAction.CreateDefenseSequence("3:5");
        CardPrototypes.Add("B01C03", "bond_or_supporter", bondOrSupporter);

        // 改变（正）
        // 领袖的 责任
        // 2力：152，678
        // tag：

        // 关卡（反）
        // 领袖的 责任
        // 1力：254，896
        // tag：
        changeOrLevel = new Card("B01C04","change_or_level", MindPhase.Prefix.Leadership, MindPhase.Suffix.Responsibility);
        changeOrLevel.action.CreateDefenseSequence("2:152,2:678");
        changeOrLevel.bonusAction.CreateDefenseSequence("1:254,1:896");
        CardPrototypes.Add("B01C04", "change_or_level", changeOrLevel);

        // 封底（4/4）
        // 未来（正）
        // 领袖的 责任
        // 3力：126547
        // tag：封底

        // 结局（反）
        // 领袖的 责任
        // 6力：1，5，9
        // tag：封底

        futureOrEnding = new Card("B01C05","future_or_ending", MindPhase.Prefix.Leadership, MindPhase.Suffix.Firmness);
        futureOrEnding.action.CreateDefenseSequence("3:126547");
        futureOrEnding.bonusAction.CreateDefenseSequence("6:1,6:5,6:9");
        futureOrEnding.SetCover();
        CardPrototypes.Add("B01C05", "future_or_ending", futureOrEnding);
    }

    public static void LoadBook2() {
        Debug.Log("加载《基础持刀》");
        // 直斩（正）
        // 领袖的 坚定
        // 2力：258
        // tag：

        // 抵剑（反）
        // 领袖的 坚定
        // 1力：168，348
        // tag：


        slashOrResist = new Card("B02C01","slash_or_resist", MindPhase.Prefix.Leadership, MindPhase.Suffix.Firmness);
        slashOrResist.action.CreateDefenseSequence("2:258");
        slashOrResist.bonusAction.CreateDefenseSequence("1:168, 1:348,");
        CardPrototypes.Add("B02C01", "slash_or_resist", slashOrResist);

        // 侧挡（正）
        // 领袖的 坚定
        // 1力：56341
        // 绽放（1坚定）：具有+2力度
        // tag：绽放

        // 收刀（反）
        // 领袖的 坚定
        // 1力：812，476
        // 共鸣（领袖的）：具有力度+1
        // 共鸣（自信）：具有力度+1
        // tag：共鸣


        sideParryOrSheathe = new SideParryOrSheathe();
        CardPrototypes.Add("B02C02", "side_parry_or_sheathe", sideParryOrSheathe);

        // 握剑姿态（正）
        // 领袖的 温柔
        // 2力：38
        // 即刻：抽一张“领袖的”卡牌
        // tag：抽牌

        // 臂力训练（反）
        // 领袖的 温柔
        // 1力：5632
        // 气场：“领袖的”卡牌具有力度+1
        // tag：气场


        swordHoldingOrArmTraining = new SwordHoldingOrArmTraining();
        CardPrototypes.Add("B02C03", "sword_holding_or_arm_training", swordHoldingOrArmTraining);

        // 呼吸法（正）
        // 领袖的 责任
        // 1力：72，34
        // 即刻：抽两张牌
        // tag：抽牌

        // 闪避步伐（反）
        // 领袖的 责任
        // 3力：687，159
        // 气场：你的卡牌具有力度-1
        // tag：气场


        breathSkillOrDodge = new BreathSkillOrDodge();
        CardPrototypes.Add("B02C04", "breath_skill_or_dodge", breathSkillOrDodge);

        // 封底（3/4）
        // 十字力斩（正）
        // 领袖的坚定
        // 5力：456，258
        // 气场：你的卡牌具有力度+2
        // tag：封底

        // 付诸武力（反）
        // 领袖的坚定
        // 3力：5
        // 即刻：在本局游戏中，你的卡牌具有力度+1
        // tag：封底


        crossSlashOrArmed = new CrossSlashOrArmed();
        crossSlashOrArmed.SetCover(); //设定为封底牌
        CardPrototypes.Add("B02C05", "cross_slash_or_armed", crossSlashOrArmed);
    }

    public static void LoadBook3() {
        
    }
}
