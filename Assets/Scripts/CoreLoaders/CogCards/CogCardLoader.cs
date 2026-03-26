using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CogCards;

/// <summary>
/// 加载认知卡数据的类
/// </summary>
public static class CogCardLoader{
    public static Dictionary<string, CogCard> cogCardsPrototypes = new Dictionary<string, CogCard>();
    public static Dictionary<MindPhase.Prefix,List<CogCard>> publicCogCardsPrototypes = new Dictionary<MindPhase.Prefix, List<CogCard>>();

    public static CogCard GetCogCard(string cogCardId) {
        return cogCardsPrototypes[cogCardId].Clone();
    }

    public static List<CogCard> GetCogCardListByMindPhase(MindPhase.Prefix prefix) {
        List<CogCard> result = new List<CogCard>();
        foreach(CogCard cogCard in publicCogCardsPrototypes[prefix]) {
            result.Add(cogCard.Clone());
        }
        return result;
    }

    private static void AddCogCardToPrototype(CogCard cogCard) {
        cogCardsPrototypes.Add(cogCard.ID,cogCard);
    }

    private static void AddCogCardToMindPhaseProtoType(MindPhase.Prefix prefix,params CogCard[] cogCards) {
        publicCogCardsPrototypes.Add(prefix,cogCards.ToList<CogCard>());
        foreach(CogCard cogCard in cogCards) {
            AddCogCardToPrototype(cogCard);
        }
    }

    /// <summary>
    /// 公共认知卡-领袖
    /// </summary>
    private static CogCard _Responsibility,_SelfDiscipline,_Composure;
    /// <summary>
    /// 公共认知卡-投机者：
    /// </summary>
    private static CogCard _Foresight,_ChangeAbility,_Determination;
    /// <summary>
    /// 公共认知卡-朋友：
    /// </summary>
    private static CogCard _Unity,_Sincerity,_Inclusiveness;
    /// <summary>
    /// 公共认知卡-守护者：
    /// </summary>
    private static CogCard _Loyalty,_Commitment,_KeepVow;
    public static void Load() {
        LoadLeaderPublicCard();
        LoadSpeculatorPublicCard();
        LoadFriendshipPublicCard();
        LoadGuardianshipPublicCard();
    }

    private static void LoadLeaderPublicCard() {
        // 3责任
        // 在最后一回合中，你的所有卡牌+1力
        // PLC = publicLeaderCogcard
        _Responsibility = new Responsibility();
        //AddCogCardToPrototype(Responsibility);
        
        // 2自律
        // 你的“领袖的”书页同时具有“坚定”心相
        _SelfDiscipline = new SelfDiscipline();
        //AddCogCardToPrototype(SelfDiscipline);
        
        // 1沉稳
        // 你所能承受的最大“摧毁”影响从7提升为8
        _Composure = new Composure();

        AddCogCardToMindPhaseProtoType(MindPhase.Prefix.Leadership,
        _Responsibility,_SelfDiscipline,_Composure);
    }

    private static void LoadSpeculatorPublicCard() {
        // 1远见
        // 第一回合开始时，抽一张牌
        _Foresight = new Foresight();
        // 1善变
        // 当你使用“封底”卡时，抽一张牌
        _ChangeAbility = new ChangeAbility();

        // 2决心
        // 在一个轮次内，如果你没有使用任何卡牌，抽一张牌
        _Determination = new Determination();

        AddCogCardToMindPhaseProtoType(MindPhase.Prefix.Speculator,
        _Foresight,_ChangeAbility,_Determination);
    }

    private static void LoadFriendshipPublicCard() {
        // 2团结
        // 回合结束时，你每保留一张手牌，随机为一个节点施加1坚定影响
        _Unity = new CogCards.Unity();

        // 3真诚
        // 第一回合开始时，为所有节点施加2温柔影响
        _Sincerity = new Sincerity();

        // 2包容
        // 如果你携带了领袖，投机者，朋友，守护者四种书籍各一本进入战斗，则第一回合开始时，你抽取每本书的各一张书页
        _Inclusiveness = new Inclusiveness();

        AddCogCardToMindPhaseProtoType(MindPhase.Prefix.Friendship,
        _Unity,_Sincerity,_Inclusiveness);
    }

    private static void LoadGuardianshipPublicCard() {
        // 5忠诚
        // 你的“领袖的”书页同时具有“责任”心相
        _Loyalty = new Loyalty();
        // 2担当
        // 在已有“摧毁”影响的节点上，你具有+1力
        _Commitment = new Commitment();
        // 3守誓
        // 你的“封底”卡具有气场：力度+1
        _KeepVow = new KeepVow();
        AddCogCardToMindPhaseProtoType(MindPhase.Prefix.Guardianship,
        _Loyalty,_Commitment,_KeepVow);
    }
}