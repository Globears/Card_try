using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 卡组 这个是储存套牌的基类，注意不要和Library混淆，后者是游戏内的牌库
/// </summary>
public class Deck
{
    public string name;
    public Supporter supporter;
    public List<CogCard> cogCards = new List<CogCard>();
    public List<Book> books = new List<Book>();
    public List<Card> cards = new List<Card>();
}
