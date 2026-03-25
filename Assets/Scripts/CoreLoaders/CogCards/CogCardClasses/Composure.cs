using UnityEngine;

public class Composure : CogCard {
    
    // 1沉稳
    // 你所能承受的最大“摧毁”影响从7提升为8
    public Composure() : base("PLC03", "Composure", 3) {
        Effect ResponsibilityEffect = new NextEventEffect<GameLoadEvent.Post>(() => {
            // 你所能承受的最大“摧毁”影响从7提升为8
            CardGameManager.HEALTH = 8;
        });
        AddEffect(ResponsibilityEffect);
    }
}