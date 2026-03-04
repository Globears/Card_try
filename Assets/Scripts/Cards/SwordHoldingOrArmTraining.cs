using UnityEngine;

public class SwordHoldingOrArmTraining : Card
{
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
