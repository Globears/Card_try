using UnityEngine;
namespace CogCards {
    public class ChangeAbility : CogCard {
        // 1善变
        // 当你使用“封底”卡时，抽一张牌
        public ChangeAbility() : base("PSC02", "ChangeAbility", 1) {
            Effect ChangeAbilityEffect = new EventUntilEventEffect<CardResolveEvent.Pre,GameEndEvent>(
            (CardResolveEvent.Pre e) => {
            // 当你使用“封底”卡时，抽一张牌
                if(e.card.IsCoverCard == true) {
                    Debug.Log("善变效果触发：当你使用“封底”卡时，抽一张牌");
                    Player.Instance.Draw();
                }
            });
            AddEffect(ChangeAbilityEffect);
        }
    }
}