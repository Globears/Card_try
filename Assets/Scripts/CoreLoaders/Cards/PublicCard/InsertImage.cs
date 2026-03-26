using UnityEngine;

namespace Cards {
    public class InsertImage : Card
    {
    // 插图 只有行动
    // 1：信标当前位置，下一张卡牌的起始位置
    // 如果没有下一张卡牌则为5
        public Effect instantEffect;
        public InsertImage()
        : base("B00C01","insert_image",MindPhase.Prefix.NOMINDPHASE,MindPhase.Suffix.NOMINDPHASE) {
            // instantEffect = new Instant(() => {
            //     Debug.Log("1：信标当前位置，下一张卡牌的起始位置 如果没有下一张卡牌则为5");
            //     int beaconCurrentPosition = NumPositionTranslator.PositionToNum(Beacon.Instance.Position);
            //     if(CardGameManager.Instance.GetNextAction() != null) {
            //         int nextCard = NumPositionTranslator.PositionToNum(CardGameManager.Instance.GetNextAction().DefenseSequences[0].Begin.Position);
            //         Debug.Log("插图的防御序列是：1:" + beaconCurrentPosition.ToString() + nextCard.ToString()+".");
            //         action.CreateDefenseSequence("1:" + beaconCurrentPosition.ToString() + nextCard.ToString());
            //     } else {
            //         Debug.Log("插图的防御序列是：1:" + beaconCurrentPosition.ToString() + "5"+".");
            //         action.CreateDefenseSequence("1:" + beaconCurrentPosition.ToString() + "5");
            //     }
            // });
            instantEffect = new Instant(e => {
                var act = e.owner;
                if (act == null) return;

                int beaconCurrentPosition = NumPositionTranslator.PositionToNum(Beacon.Instance.Position);
                int nextPosNum = 5;
                var nextAct = CardGameManager.Instance.GetNextAction();
                if (nextAct != null && nextAct.DefenseSequences != null && nextAct.DefenseSequences.Count > 0 && nextAct.DefenseSequences[0].Begin != null)
                    nextPosNum = NumPositionTranslator.PositionToNum(nextAct.DefenseSequences[0].Begin.Position);
                act.CreateDefenseSequence("1:" + beaconCurrentPosition.ToString() + nextPosNum.ToString());
            });
            action.AddEffect(instantEffect);
        }
    }
}