using UnityEngine;

public class CardFactory
{
    public static Card CreateCard(string cardId)
    {
        Card prototype = Cards.CardPrototypes[cardId];
        if(prototype != null)
        {
            Card card = (Card)prototype.Clone();
            return card;
        }
        return null;
    }
}
