using UnityEngine;

namespace CogCards {
    public class Unity : CogCard {
        // 2团结
        // 回合结束时，你每保留一张手牌，随机为一个节点施加1坚定影响
        public Unity() : base("PFC01", "Unity", 2) {
            // 回合结束时，你每保留一张手牌，随机为一个节点施加1坚定影响
            Effect UnityEffect = new EventUntilEventEffect<TurnEndEvent,GameEndEvent>(
            (TurnEndEvent e) => {
                int handCount = Hand.Instance.cards.Count;
                for(int i = 0;i < handCount; i++) {
                    GridManager.Instance.ApplyAffectOnNodeByIndex(Random.Range(1,10),MindPhase.Suffix.Firmness,1);
                }
            });
            AddEffect(UnityEffect);
        }
    }
}