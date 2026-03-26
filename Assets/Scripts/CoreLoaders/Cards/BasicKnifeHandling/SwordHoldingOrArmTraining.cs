using UnityEngine;

namespace Cards {
    public class SwordHoldingOrArmTraining : Card
    {
        // 握剑姿态（正）
        // 领袖的 温柔
        // 2力：38
        // 即刻：抽一张“领袖的”卡牌
        // tag：抽牌

        // 臂力训练（反）
        // 领袖的 温柔
        // 1力：5632
        // 气场：“领袖的”卡牌具有力度+1
        // tag：气场


        public static Effect instantEffect,aruaEffect;
        public SwordHoldingOrArmTraining()
        : base("B02C03","sword_holding_or_arm_training", MindPhase.Prefix.Leadership, MindPhase.Suffix.Firmness)
        {
            action.CreateDefenseSequence("2:38");
            bonusAction.CreateDefenseSequence("1:5632");

            instantEffect = new NextEventEffect<TurnBeginEvent>(() => {
                //抽取一张“领袖的”卡牌
                Debug.Log("抽取一张“领袖的”卡牌");
                Player.Instance.Draw(TAGS.LEADERSHIP);
            });
            aruaEffect = new EventUntilEventEffect<CardResolveEvent.Pre, TurnEndEvent>((CardResolveEvent.Pre e) => {
                if(e.card.cardTags.Contains(TAGS.LEADERSHIP)){
                    Debug.Log("气场：“领袖的”卡牌具有力度+1");
                    e.card.action.AddPowerOnDefenseSequences(1);
                    e.card.bonusAction.AddPowerOnDefenseSequences(1);
                }
            },(TurnEndEvent e) => {
                
            });
            action.AddEffect(instantEffect);
            bonusAction.AddEffect(aruaEffect);
            bonusAction.AddTag(TAGS.AURA);
        }
    }
}