
using UnityEngine;
using Unity.VisualScripting;

public enum TAGS {
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
    public static TAGS SuffixToTag(MindPhase.Suffix suffix) {
        switch (suffix) {
            case MindPhase.Suffix.Destoryed:
                return TAGS.DESTORYED;
            case MindPhase.Suffix.Firmness:
                return TAGS.FIRMNESS;
            case MindPhase.Suffix.Tenderness:
                return TAGS.TENDERNESS;
            case MindPhase.Suffix.Confidence:
                return TAGS.CONFIDENCE;
            case MindPhase.Suffix.Responsibility:
                return TAGS.RESPONSIBILITY;
            default:
                Debug.LogError(suffix + "未找到对应的CardTag");
                return TAGS.NULL; //默认标签
        }
    }
    public static TAGS PrefixToTag(MindPhase.Prefix prefix) {
        switch (prefix) {
            case MindPhase.Prefix.Leadership:
                return TAGS.LEADERSHIP;
            case MindPhase.Prefix.Friendship:
                return TAGS.FRIENDSHIP;
            case MindPhase.Prefix.Guardianship:
                return TAGS.GUARDIANSHIP;
            case MindPhase.Prefix.Speculator:
                return TAGS.SPECULATOR;
            default:
                Debug.LogError(prefix + "未找到对应的CardTag");
                return TAGS.NULL; //默认标签
        }
    }
}