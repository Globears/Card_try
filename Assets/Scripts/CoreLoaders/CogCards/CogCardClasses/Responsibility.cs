

public class Responsibility : CogCard {
    
    // 3责任
    // 在最后一回合中，你的所有卡牌+1力
    public Responsibility() : base("PLC01", "Responsibility", 3) {
        Effect ResponsibilityEffect = new EventUntilEventEffect<TurnBeginEvent,GameEndEvent>((TurnBeginEvent e)=> {
            //TODO：判断是不是最后一回合
            Effect ResponsibilityEffect2 = new EventUntilEventEffect<CardResolveEvent.Pre,TurnEndEvent>((CardResolveEvent.Pre e) =>{
                e.card.action.AddPowerOnDefenseSequences(1);
                e.card.bonusAction.AddPowerOnDefenseSequences(1);
            });
            ResponsibilityEffect2.Cast();
        });
        this.AddEffect(ResponsibilityEffect);
    }
}