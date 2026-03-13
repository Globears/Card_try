using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    public string name;
    public Supporter supporter;
    public List<CogCard> cogCards = new List<CogCard>();
    public List<Book> books = new List<Book>();
    public List<Card> cards = new List<Card>();
}
