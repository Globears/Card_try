using UnityEngine;

namespace CogCards {
    public class Sincerity : CogCard {
        // 3真诚
        // 第一回合开始时，为所有节点施加2温柔影响
        public Sincerity() : base("PFC02", "Sincerity", 3) {
        // 第一回合开始时，为所有节点施加2温柔影响
            Effect SincerityEffect = new NextEventEffect<TurnBeginEvent>(() => {
                for(int i = 1; i < 10; i++) {
                    GridManager.Instance.ApplyAffectOnNodeByIndex(i,MindPhase.Suffix.Tenderness,2);
                }
            });
            AddEffect(SincerityEffect);
        }
    }
}