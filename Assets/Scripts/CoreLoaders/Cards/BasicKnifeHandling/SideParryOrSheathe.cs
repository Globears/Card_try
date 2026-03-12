using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

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
    public Effect blossom, vibration;
    public SideParryOrSheathe()
    : base("side_parry_or_sheathe", MindPhase.Prefix.Leadership, MindPhase.Suffix.Confidence)
    {
        action.CreateDefenseSequence("1:56341");
        bonusAction.CreateDefenseSequence("1:15, 1:25, 1:35, 1:45, 1:55, 1:65, 1:75, 1:85, 1:95");
        //绽放（2坚定）：具有+2力度
        blossom = new Instant(() => {
            if(Beacon.Instance.GetCurrentNode().MindPhases[MindPhase.Suffix.Firmness] >= 2) {
                Debug.Log("侧挡&收刀 : 绽放（2坚定）：具有+2力度");
                action.AddPowerOnDefenseSequences(2);
            }
        });
        action.AddEffect(blossom);
        bonusAction.AddEffect(vibration);
        vibration = new Instant(() => {
            // 共鸣（领袖的）：具有力度+1
            // 共鸣（自信）：具有力度+1
            Act lastAct = Logger.getLastAct();
            if(lastAct != null && (lastAct.Prefix == MindPhase.Prefix.Leadership)){
                Debug.Log("侧挡&收刀 : 共鸣（领袖的）：具有力度+1");
                bonusAction.AddPowerOnDefenseSequences(1);
            }
            if(lastAct != null && (lastAct.Suffix == MindPhase.Suffix.Confidence)){
                Debug.Log("侧挡&收刀 : 共鸣（自信）：具有力度+1");
                bonusAction.AddPowerOnDefenseSequences(1);
            }
        });
    }
}
