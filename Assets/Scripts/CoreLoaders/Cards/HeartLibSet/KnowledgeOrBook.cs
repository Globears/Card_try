using UnityEngine;

namespace Cards {
    public class KnowledgeOrBook : Card
    {
        // 知识（正）
        // 领袖的 自信
        // 1力：12，45，78
        // 即刻：抽一张牌
        // tag：抽牌

        // 书籍（反）
        // 领袖的 自信
        // 1力：95，84，62
        // tag：
        public Effect instantEffect;
        public KnowledgeOrBook()
        : base("B01C02","knowledge_or_book", MindPhase.Prefix.Leadership, MindPhase.Suffix.Confidence)
        {
            action.CreateDefenseSequence("1:12,45,78");
            bonusAction.CreateDefenseSequence("1:95,84,62");

            instantEffect = new Instant(e => {
                Debug.Log("知识 & 书籍 即刻效果：抽一张牌");
                Player.Instance.Draw();
            });
            action.AddEffect(instantEffect);
            action.AddTag(TAGS.DRAWCARD);
        }
    }
}