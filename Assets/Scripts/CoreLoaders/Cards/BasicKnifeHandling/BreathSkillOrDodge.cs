using UnityEngine;

public class BreathSkillOrDodge : Card
{
    // 呼吸法（正）
    // 领袖的 责任
    // 0力：5
    // 即刻：抽两张牌
    // tag：抽牌

    // 闪避步伐（反）
    // 领袖的 责任
    // 3力：687，489
    // 气场：你的卡牌具有力度-1
    // tag：气场

    public static Effect instantEffect,aruaEffect;
    public BreathSkillOrDodge()
    : base("B02C04","breath_skill_or_dodge", MindPhase.Prefix.Leadership, MindPhase.Suffix.Responsibility)
    {
        action.CreateDefenseSequence("0:5");
        bonusAction.CreateDefenseSequence("3:687,3:489");

        instantEffect = new NextEventEffect<TurnBeginEvent>(() => {
            //抽取一张“领袖的”卡牌
            Debug.Log("即刻：抽两张牌");
            Player.Instance.Draw();
            Player.Instance.Draw();
        });
        aruaEffect = new EventUntilEventEffect<CardResolveEvent.Pre, TurnEndEvent>((CardResolveEvent.Pre e) => {
            Debug.Log("气场：你的卡牌具有力度-1");
            e.card.action.AddPowerOnDefenseSequences(-1);
            e.card.bonusAction.AddPowerOnDefenseSequences(-1);
        },(TurnEndEvent e) => {
            
        });
        action.AddEffect(instantEffect);
        bonusAction.AddEffect(aruaEffect);
        bonusAction.AddTag(TAGS.AURA);
    }
}
