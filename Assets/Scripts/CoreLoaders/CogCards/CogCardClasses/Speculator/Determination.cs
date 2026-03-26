using UnityEngine;
namespace CogCards {
    public class Determination : CogCard {
        // 2决心
        // 在一个轮次内，如果你没有使用任何卡牌，抽一张牌
        public Determination() : base("PSC03", "Determination", 2) {
            Effect DeterminationEffect = new EventUntilEventEffect<RoundEndEvent,GameEndEvent>(
            (RoundEndEvent e) => {
            // 在一个轮次内，如果你没有使用任何卡牌，抽一张牌
                if(e.ActionCard == null && e.BonusActionCard == null) {
                    Debug.Log("决心效果触发：在一个轮次内，如果你没有使用任何卡牌，抽一张牌");
                    Player.Instance.Draw();
                }
            });
            AddEffect(DeterminationEffect);
        }
    }
}