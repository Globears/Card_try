using UnityEngine;
namespace CogCards {
    public class KeepVow : CogCard {
        // 3守誓
        // 你的“封底”卡具有气场：力度+1
        public KeepVow() : base("PGC03", "KeepVow", 3) {
            Effect KeepVowEffect = new NextEventEffect<GameLoadEvent.Post>(() => {
                // 你的“封底”卡具有气场：力度+1
                Debug.Log("守誓：为“封底”卡添加：气场：力度+1");
                foreach(Card card in CoverLibrary.Instance.cards) {
                    Effect KeepVowAuraEffect = new EventUntilEventEffect<CardResolveEvent.Pre, TurnEndEvent>(
                    (CardResolveEvent.Pre e) => {
                        Debug.Log("守誓：你的“封底”卡具有气场：力度+1");
                        e.card.action.AddPowerOnDefenseSequences(1);
                        e.card.bonusAction.AddPowerOnDefenseSequences(1);
                    },(TurnEndEvent e) => {
                        
                    });
                    card.action.AddEffect(KeepVowAuraEffect);
                    card.bonusAction.AddEffect(KeepVowAuraEffect);
                }
            });
            AddEffect(KeepVowEffect);
        }
    }
}