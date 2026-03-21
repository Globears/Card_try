using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SideParryOrSheathe : Card
{
    // 侧挡（正）
    // 领袖的 坚定
    // 1力：56341
    // 绽放（2坚定）：具有+2力度
    // tag：绽放

    // 收刀（反）
    // 领袖的 坚定
    // 1力：51，52，54，56
    // 共鸣（领袖的）：具有力度+1
    // 共鸣（自信）：具有力度+1
    // tag：共鸣

    public Effect blossom, vibration;
    public SideParryOrSheathe()
    : base("B02C02","side_parry_or_sheathe", MindPhase.Prefix.Leadership, MindPhase.Suffix.Confidence)
    {
        action.CreateDefenseSequence("1:56341");
        bonusAction.CreateDefenseSequence("1:51,1:52,1:54,1:56");
        //绽放（2坚定）：具有+2力度
        blossom = new Instant(e => {
            if(Beacon.Instance.GetCurrentNode().MindPhases[MindPhase.Suffix.Firmness] >= 2) {
                Debug.Log("侧挡&收刀 : 绽放（2坚定）：具有+2力度");
                action.AddPowerOnDefenseSequences(2);
            }
        });
        vibration = new Instant(e => {
            // 共鸣（领袖的）：具有力度+1
            // 共鸣（自信）：具有力度+1
            Act lastAct = Logger.getLastAct();
            if(lastAct != null && lastAct.HasTag(TAGS.LEADERSHIP)){
                Debug.Log("侧挡&收刀 : 共鸣（领袖的）：具有力度+1");
                bonusAction.AddPowerOnDefenseSequences(1);
            }
            if(lastAct != null && lastAct.HasTag(TAGS.CONFIDENCE)){
                Debug.Log("侧挡&收刀 : 共鸣（自信）：具有力度+1");
                bonusAction.AddPowerOnDefenseSequences(1);
            }
        });
        action.AddEffect(blossom);
        action.AddTag(TAGS.BLOSSOM);
        bonusAction.AddEffect(vibration);
        bonusAction.AddTag(TAGS.VIBRATION);
    }
}
