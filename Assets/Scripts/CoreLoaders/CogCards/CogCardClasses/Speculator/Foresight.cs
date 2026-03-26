using UnityEngine;

namespace CogCards {
    public class Foresight : CogCard {
        // 1远见
        // 第一回合开始时，抽一张牌
        public Foresight() : base("PSC01", "Foresight", 1) {
            Effect ForesightEffect = new NextEventEffect<TurnBeginEvent>(() => {
                // 第一回合开始时，抽一张牌
                Debug.Log("远见效果触发：第一回合开始时，抽一张牌");
                Player.Instance.Draw();
            });
            AddEffect(ForesightEffect);
        }
    }
}