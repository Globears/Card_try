using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

/// <summary>
/// 加载认知卡数据的类
/// </summary>
public static class CogCards{
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

    public static void AddCogCardToPrototype(CogCard cogCard) {
        cogCardsPrototypes.Add(cogCard.ID,cogCard);
    }
    /// <summary>
    /// 公共认知卡-领袖
    /// </summary>
    private static CogCard Responsibility,SelfDiscipline,Composure;
    /// <summary>
    /// 公共认知卡-投机者：
    /// </summary>
    private static CogCard Foresight,Changeability,Determination;
    /// <summary>
    /// 公共认知卡-朋友：
    /// </summary>
    private static CogCard Unity,Sincerity,Inclusiveness;
    /// <summary>
    /// 公共认知卡-守护者：
    /// </summary>
    private static CogCard Loyalty,Commitment,Commitment2;
    public static void Load() {
        LoadLeaderPublicCard();
    }

    private static void LoadLeaderPublicCard() {
        // 3责任
        // 在最后一回合中，你的所有卡牌+1力
        // PLC = publicLeaderCogcard
        Responsibility = new Responsibility();
        AddCogCardToPrototype(Responsibility);
        
        // 2自律
        // 你的“领袖的”书页同时具有“坚定”心相
        SelfDiscipline = new CogCard("PLC02","SelfDiscipline",2);
        
        // 1沉稳
        // 你所能承受的最大“摧毁”影响从7提升为9
        Composure = new CogCard("PLC03","Composure",1);
    }
}