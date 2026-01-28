using System;
using System.Collections.Generic;
using UnityEngine;

public class Hand
{
    public static Action<HandAddEvent> HandAddEvent;
    private static Hand instance;

    public static Hand Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new Hand();
                
            }
            return instance;
        }

    }

    private Hand()
    {
        
    }

    private List<Card> cards = new List<Card>();

    public void Add(Card card)
    {
        cards.Add(card);
        HandAddEvent?.Invoke(new HandAddEvent { card = card });
    }

    public void Remove(Card card)
    {
        cards.Remove(card);
    }


    


}
