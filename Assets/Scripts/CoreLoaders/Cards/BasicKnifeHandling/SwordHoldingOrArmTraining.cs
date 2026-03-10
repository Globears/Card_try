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
    public SwordHoldingOrArmTraining()
    : base("sword_holding_or_arm_training", MindPhase.Prefix.Leadership, MindPhase.Suffix.Firmness)
    {
        action.CreateDefenseSequence("1:5-3:8");
        bonusAction.CreateDefenseSequence("1:5632");
    }

    public class Instant : Effect
    {
        public Instant()
        {
            
        }

        public void Cast()
        {
            
        }

        public void Trigger()
        {
            
        }

        public void Affect()
        {
            //滤抽
        }
    }

}
