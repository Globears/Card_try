using UnityEngine;

namespace CogCards {
    public class Commitment : CogCard {
        // 2担当
        // 在已有“摧毁”影响的节点上，你具有+1力
        public Commitment() : base("PGC02", "Commitment", 5) {
            Effect CommitmentEffect = new EventUntilEventEffect<ApplyDefenseEvent.Pre,GameEndEvent>(
            (ApplyDefenseEvent.Pre e) => {
                // 在已有“摧毁”影响的节点上，你具有+1力
                if(e.node.MindPhases[MindPhase.Suffix.Destoryed] > 0) {
                    e.defense.Power += 1;
                }
            });
            AddEffect(CommitmentEffect);
        }
    }
}