using UnityEngine;

namespace CogCards {
    public class Loyalty : CogCard {
        // 5忠诚
        // 你的“领袖的”书页同时具有“责任”心相
        public Loyalty() : base("PGC01", "Loyalty", 5) {
            Effect LoyaltyEffect = new NextEventEffect<GameLoadEvent.Post>(() => {
                // 你的“领袖的”书页同时具有“责任”心相
                foreach(Card card in Library.Instance.cards) {
                    if (card.cardTags.Contains(TAGS.LEADERSHIP)) {
                        card.AddSuffix(MindPhase.Suffix.Responsibility);
                    }
                }
            });
            AddEffect(LoyaltyEffect);
        }
    }
}