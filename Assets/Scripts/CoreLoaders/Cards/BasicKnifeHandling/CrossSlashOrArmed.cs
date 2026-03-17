using UnityEngine;

public class CrossSlashOrArmed : Card
{
    // 封底（3/4）
    // 十字力斩（正）
    // 领袖的坚定
    // 5力：456，258
    // 气场：你的卡牌具有力度+2
    // tag：封底

    // 付诸武力（反）
    // 领袖的坚定
    // 3力：5
    // 即刻：在本局游戏中，你的卡牌具有力度+1
    // tag：封底


    public static Effect instantEffect,aruaEffect;
    public CrossSlashOrArmed()
    : base("B02C05","cross_slash_or_armed", MindPhase.Prefix.Leadership, MindPhase.Suffix.Firmness)
    {
        action.CreateDefenseSequence("5:456,5:258");
        bonusAction.CreateDefenseSequence("3:5");
        
        aruaEffect = new EventUntilEventEffect<CardResolveEvent.Pre, TurnEndEvent>((CardResolveEvent.Pre e) => {
            Debug.Log("气场：你的卡牌具有力度+2");
            e.card.action.AddPowerOnDefenseSequences(2);
            e.card.bonusAction.AddPowerOnDefenseSequences(2);
        },(TurnEndEvent e) => {
            
        });
        
        instantEffect = new EventUntilEventEffect<CardResolveEvent.Pre, GameEndEvent>((CardResolveEvent.Pre e) => {
            Debug.Log("即刻：在本局游戏中，你的卡牌具有力度+1");
            e.card.action.AddPowerOnDefenseSequences(1);
            e.card.bonusAction.AddPowerOnDefenseSequences(1);
        },(GameEndEvent e) => {
            
        });

        action.AddEffect(instantEffect);
        bonusAction.AddEffect(aruaEffect);
        bonusAction.AddTag(TAGS.AURA);
    }
}
