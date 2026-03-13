using System.Collections.Generic;
using UnityEngine;

public class CardFactory
{
    public static Card CreateCard(string cardId)
    {
        Card prototype = null;
        try {
            prototype = Cards.CardPrototypes.GetByKey1(cardId);
        } catch (KeyNotFoundException) {
            try {
                prototype = Cards.CardPrototypes.GetByKey2(cardId);
            } catch {
                Debug.LogWarning(cardId + "没有找到对应的键值");
                prototype = null;
            }
        }
        if(prototype != null)
        {
            Card card = (Card)prototype.Clone();
            return card;
        }
        return null;
    }
}
