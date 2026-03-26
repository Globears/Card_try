using System.Collections.Generic;
using UnityEngine;
using Cards;

public class CardFactory
{
    public static Card CreateCard(string cardId)
    {
        Card prototype = CardLoader.GetPrototypeById(cardId);
        if(prototype == null) prototype = CardLoader.GetPrototypeByName(cardId);
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
