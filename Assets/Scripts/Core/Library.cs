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
        //洗牌
        System.Random random = new System.Random();
        for (int i = 0; i < Instance.cards.Count; i++)
        {
            int j = random.Next(Instance.cards.Count);
            Card temp = Instance.cards[i];
            Instance.cards[i] = Instance.cards[j];
            Instance.cards[j] = temp;
        }
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

    public int Count()
    {
        return cards.Count;
    }

    public Card TopCard()
    {
        if (cards.Count == 0)
        {
            return null;
        }
        return cards[0];
    }

    public Card SearchWithTag(TAGS tag) {
        if (cards.Count == 0)
        {
            Debug.Log("牌库无牌");
            return null;
        }
        foreach(Card card in cards) {
            if (card.cardTags.Contains(tag)) {
                return card;
            }
        }
        Debug.Log("牌库没有符合条件的牌");
        return null;
    }
}
