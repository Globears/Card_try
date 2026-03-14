using UnityEngine;

public class SwordHoldingOrArmTraining : Card
{
    // 握剑姿态（正）
    // 领袖的 温柔
    // 1力：5-3力：8
    // 即刻：下回合开始时抽取一张“领袖的”卡牌
    // 臂力训练（反）
    // 领袖的 温柔
    // 1力：5632
    // 气场：“领袖的”卡牌具有力度+1
    public static Effect instantEffect,aruaEffect;
    public SwordHoldingOrArmTraining()
    : base("B01C03","sword_holding_or_arm_training", MindPhase.Prefix.Leadership, MindPhase.Suffix.Firmness)
    {
        action.CreateDefenseSequence("1:5-3:8");
        bonusAction.CreateDefenseSequence("1:5632");

        instantEffect = new NextEventEffect<TurnBeginEvent>(() => {
            //抽取一张“领袖的”卡牌
            Debug.Log("下回合开始时,抽取一张“领袖的”卡牌");
            Player.Instance.Draw(CARD_TAG.LEADERSHIP);
        });
        aruaEffect = new EventUntilEventEffect<CardResolveEvent, TurnEndEvent>((CardResolveEvent e) => {
            if(e.card.cardTags.Contains(CARD_TAG.LEADERSHIP)){
                Debug.Log("“领袖的”卡牌具有力度+1");
                e.card.action.AddPowerOnDefenseSequences(1);
                e.card.bonusAction.AddPowerOnDefenseSequences(1);
            }
        },(TurnEndEvent e) => {
            
        });
    }
}
