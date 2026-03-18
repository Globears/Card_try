using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 加载认知卡数据的类
/// </summary>
public static class CogCards{
    public static Dictionary<int, CogCard> cogCards = new Dictionary<int, CogCard>();
    public static Dictionary<MindPhase.Prefix,List<CogCard>> publicCogCards = new Dictionary<MindPhase.Prefix, List<CogCard>>();

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
        
    }

    private static void LoadLeaderPublicCard() {
        // 3责任
        // 在最后一回合中，你的所有卡牌+1力
        // PLC = publicLeaderCogcard
        Responsibility = new Responsibility();
        // 2自律
        // 你的“领袖的”书页同时具有“坚定”心相
        SelfDiscipline = new CogCard("PLC02","SelfDiscipline",2);
        // 1沉稳
        // 你所能承受的最大“摧毁”影响从7提升为9
        Composure = new CogCard("PLC03","Composure",1);
    }
}