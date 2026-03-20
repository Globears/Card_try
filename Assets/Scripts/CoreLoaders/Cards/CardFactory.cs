using System.Collections.Generic;
using UnityEngine;

public class CardFactory
{
    public static Card CreateCard(string cardId)
    {
        Card prototype = Cards.GetPrototypeById(cardId);
        if(prototype == null) prototype = Cards.GetPrototypeByName(cardId);
        if(prototype != null)
        {
            Card card = (Card)prototype.Clone();
            return card;
        } else {
            Debug.LogWarning(cardId + "没有找到对应的键值");
            return null;
        }
    }
}
