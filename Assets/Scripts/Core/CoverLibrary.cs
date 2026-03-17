using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 封底卡牌库 储存封底卡
/// </summary>
public class CoverLibrary {
    private static CoverLibrary instance;  
    private List<Card> cards = new List<Card>();

    public static CoverLibrary Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new CoverLibrary();
                
            }
            return instance;
        }
    }

    private CoverLibrary()
    {
        
    }

    public static void Remove(Card cardRemove)
    {
        Instance.cards.Remove(cardRemove);
        CardLeaveFromLibEvent.Publish(new CardLeaveFromLibEvent() {
            card = cardRemove
        });
    }

    public static bool Has(Card card)
    {
        return Instance.cards.Contains(card);
    }

    public void Add(Card card)
    {
        cards.Add(card);
    }

    public void LoadDeck(Deck deck) {
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

    /// <summary>
    /// 根据卡牌的TAG搜索
    /// </summary>
    /// <param name="tag"></param>
    /// <returns></returns>
    public Card SearchWithTag(TAGS tag) {
        if (cards.Count == 0) {
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

    public Card SearchWithId(string CardId) {
        if (cards.Count == 0) {
            Debug.Log("牌库无牌");
            return null;
        }
        foreach(Card card in cards) {
            if (card.Id == CardId) {
                return card;
            }
        }
        Debug.Log("牌库没有符合条件的牌");
        return null;
    }

    public List<Card> SearchAllWithBookId(int bookId) {
        if (cards.Count == 0) {
            Debug.Log("牌库无牌");
            return null;
        }
        List<Card> SearchList = new List<Card>();
        foreach(Card card in cards) {
            if (card.bookBelongId == bookId) {
                SearchList.Add(card);
            }
        }
        return SearchList;
    }
}
