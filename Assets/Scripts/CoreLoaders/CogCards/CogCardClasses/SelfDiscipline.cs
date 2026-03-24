

using UnityEngine;

public class SelfDiscipline : CogCard {
    
    // 2自律
    // 你的“领袖的”书页同时具有“坚定”心相
    public SelfDiscipline() : base("PLC02", "SelfDiscipline", 2) {
        // 你的“领袖的”书页同时具有“坚定”心相
        foreach(Card card in Library.Instance.cards) {
            if (card.cardTags.Contains(TAGS.LEADERSHIP)) {
                card.AddSuffix(MindPhase.Suffix.Firmness);
            }
        }
    }
}