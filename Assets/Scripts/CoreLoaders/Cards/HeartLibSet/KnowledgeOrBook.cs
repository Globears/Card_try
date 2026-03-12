using UnityEngine;

public class KnowledgeOrBook : Card
{
// 知识（正）
// 领袖的 自信
// 1力：5
// 即刻：抽一张牌
// 书籍（反）
// 领袖的 自信
// 1力：521
    public Effect bloom, vibration;
    public KnowledgeOrBook()
    : base("knowledge_or_book", MindPhase.Prefix.Leadership, MindPhase.Suffix.Confidence)
    {
        action.CreateDefenseSequence("1:5");
        bonusAction.CreateDefenseSequence("1:521");
    }

    
}
