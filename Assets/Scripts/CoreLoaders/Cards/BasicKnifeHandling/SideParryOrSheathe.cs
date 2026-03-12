using UnityEngine;

public class SideParryOrSheathe : Card
{
    // 侧挡（正）
    // 领袖的 自信
    // 1力：56341
    // 绽放（2坚定）：具有+2力度
    // 收刀（反）
    // 领袖的 自信
    // 1力：15，25，35，45，55，65，75，85，95
    // 共鸣（领袖的）：具有力度+1
    // 共鸣（自信）：具有力度+1
    public Effect bloom, vibration;
    public SideParryOrSheathe()
    : base("side_parry_or_sheathe", MindPhase.Prefix.Leadership, MindPhase.Suffix.Confidence)
    {
        action.CreateDefenseSequence("1:56341");
        bonusAction.CreateDefenseSequence("1:15, 1:25, 1:35, 1:45, 1:55, 1:65, 1:75, 1:85, 1:95");

        bloom = new Blossom();
        action.AddEffect(bloom);

        vibration = new Vibration();
        bonusAction.AddEffect(vibration);
    }

    

    public class Blossom : Effect
    {
        public Blossom()
        {

        }

        public void Cast() {
            GridManager.applyDefenseEvent += Trigger;
        }

        public void Trigger(ApplyDefenseEvent e)
        {
            Node node = e.node;
            if(node.MindPhases[MindPhase.Suffix.Firmness] >= 2)
            {
                Affect(e);
            }
        }

        public void Affect(ApplyDefenseEvent e)
        {
            e.defense.Power += 2;
        }
    }

    public class Vibration : Effect
    {
        public Vibration()
        {
            
        }

        public void Cast()
        {
            GridManager.applyDefenseEvent += Trigger;
        }

        public void Trigger(ApplyDefenseEvent e)
        {
            Node node = e.node;
            if(Logger.getLastCard().Prefix == MindPhase.Prefix.Leadership)
            {
                Affect(e);
            }
        }

        public void Affect(ApplyDefenseEvent e)
        {
            e.defense.Power += 1;
        }

    }

}
