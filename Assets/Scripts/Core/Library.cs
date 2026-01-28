using System;
using System.Collections.Generic;
using UnityEngine;

public class Library
{
    //游戏中只有一个牌库，牌库是所有牌的集合
    private static Library instance;  
    private List<Card> cards = new List<Card>();

    public static Library Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new Library();
                
            }
            return instance;
        }

    }

    private Library()
    {
        
    }

    public static void Shuffle()
    {
        
    }

    public void Draw()
    {
        if(Library.Instance.cards.Count == 0){
            return;
        }
        Card card = cards[0];
        if (!Library.Has(card))
        {
            return;
        }
        DrawEvent e = new DrawEvent{Card = card};
        DrawEvent.Publish(e);
        Debug.Log("card draw, from Library");

        if (e.IsCancled())
        {
            return;
        }

        Library.Remove(card);
        Hand.Instance.Add(card);
    }

    public static void Remove(Card card)
    {
        Instance.cards.Remove(card);
    }

    public static bool Has(Card card)
    {
        return Instance.cards.Contains(card);
    }

    public void Add(Card card)
    {
        cards.Add(card);
    }

    public void LoadDeck(Deck deck)
    {
        cards.Clear();
        foreach (Card card in deck.cards)
        {
            Add(card);
        }
    }

}
