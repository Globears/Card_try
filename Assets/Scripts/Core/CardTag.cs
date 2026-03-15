
using UnityEngine;
using Unity.VisualScripting;

public enum CARD_TAG {
    NULL,
    /// <summary>
    /// 领袖
    /// </summary>
    LEADERSHIP,
    /// <summary>
    /// 投机者
    /// </summary>
    SPECULATOR,
    /// <summary>
    /// 朋友
    /// </summary>
    FRIENDSHIP,
    /// <summary>
    /// 守护者
    /// </summary>
    GUARDIANSHIP,
    /// <summary>
    /// 被毁
    /// </summary>
    DESTORYED,
    /// <summary>
    /// 坚定
    /// </summary>
    FIRMNESS,
    /// <summary>
    /// 温柔
    /// </summary>
    TENDERNESS,
    /// <summary>
    /// 自信
    /// </summary>
    CONFIDENCE,
    /// <summary>
    /// 责任
    /// </summary>
    RESPONSIBILITY,
    
    /// <summary>
    /// 封底牌
    /// </summary>
    COVER
}

public static class CardTag {
    public static CARD_TAG SuffixToTag(MindPhase.Suffix suffix) {
        switch (suffix) {
            case MindPhase.Suffix.Destoryed:
                return CARD_TAG.DESTORYED;
            case MindPhase.Suffix.Firmness:
                return CARD_TAG.FIRMNESS;
            case MindPhase.Suffix.Tenderness:
                return CARD_TAG.TENDERNESS;
            case MindPhase.Suffix.Confidence:
                return CARD_TAG.CONFIDENCE;
            case MindPhase.Suffix.Responsibility:
                return CARD_TAG.RESPONSIBILITY;
            default:
                Debug.LogError(suffix + "未找到对应的CardTag");
                return CARD_TAG.NULL; //默认标签
        }
    }
    public static CARD_TAG PrefixToTag(MindPhase.Prefix prefix) {
        switch (prefix) {
            case MindPhase.Prefix.Leadership:
                return CARD_TAG.LEADERSHIP;
            case MindPhase.Prefix.Friendship:
                return CARD_TAG.FRIENDSHIP;
            case MindPhase.Prefix.Guardianship:
                return CARD_TAG.GUARDIANSHIP;
            case MindPhase.Prefix.Speculator:
                return CARD_TAG.SPECULATOR;
            default:
                Debug.LogError(prefix + "未找到对应的CardTag");
                return CARD_TAG.NULL; //默认标签
        }
    }
}