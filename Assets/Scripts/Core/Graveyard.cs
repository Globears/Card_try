using System;
using System.Collections.Generic;
using UnityEngine;

public class Graveyard
{
    private static Graveyard instance;

    private List<Card> cards = new List<Card>();

    public static Graveyard Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new Graveyard();
                
            }
            return instance;
        }

    }

    private Graveyard()
    {
        
    }

    public void Add(Card card)
    {
        cards.Add(card);
    }

    public void Remove(Card card)
    {
        if(cards.Contains(card))
        {
            cards.Remove(card);
        }
    }

    internal bool Contains(Card card)
    {
        return cards.Contains(card);
    }
}
