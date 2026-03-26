using System;
using System.Collections.Generic;

public class Book
{
    public int Id;
    public String Name;

    public List<Card> ContainCards = new List<Card>();

    public MindPhase.Prefix prefix;

    /// <summary>
    /// 封底卡
    /// </summary>
    public List<Card> FinalCards = new List<Card>();

    public int FinishThreshold = 0;

    //检测是否完书，以及完书时的效果函数

    public Book(int Id,string Name) {
        this.Id = Id;
        this.Name = Name;
    }
    
    public Book(int Id,string Name,int threshold,MindPhase.Prefix prefix,params string[] containsCardIds) {
        this.Id = Id;
        this.Name = Name;
        FinishThreshold = threshold;
        this.prefix = prefix;
        foreach(string cardId in containsCardIds) {
            ContainCards.Add(CardLoader.GetPrototypeById(cardId));
        }
        foreach(Card card in ContainCards) {
            card.bookBelong = this;
            card.bookBelongId = this.Id;
        }
    }

    public void AddFinalCard(params string[] FinalCardIds) {
        foreach(string cardId in FinalCardIds) {
            FinalCards.Add(CardLoader.GetPrototypeById(cardId));
        }
        foreach(Card card in FinalCards) {
            card.bookBelong = this;
            card.bookBelongId = this.Id;
        }
    }
}

public class BookData
{
    
}
