using UnityEngine;

public class Player
{
    private static Player instance;

    public static Player Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new Player();
                
            }
            return instance;
        }

    }

    private Player()
    {
        
    }

    public void DrawFinalCard(Book book) {
        if(CoverLibrary.Instance.Count() == 0) {
            Debug.Log("封底牌牌库中没有牌");
            return;
        }
        foreach(Card card in CoverLibrary.Instance.SearchAllWithBookId(book.Id)) {
            CoverLibrary.Remove(card);
            Hand.Instance.Add(card);
            Debug.Log($"{card.Name}封底牌加入了手牌");
        }
    }

    public void Draw(TAGS tag) {
        if(Library.Instance.Count() == 0){
            Debug.Log("No cards in library");
            return;
        }
        
        Card card = Library.Instance.SearchWithTag(tag);

        DrawEvent e = new DrawEvent{Card = card};
        DrawEvent.Publish(e);
        Debug.Log("card draw, from player");

        if (e.IsCancled())
        {
            return;
        }

        Library.Remove(card);
        Hand.Instance.Add(card);
        
    }

    public void Draw()
    {
        if(Library.Instance.Count() == 0){
            Debug.Log("No cards in library");
            return;
            
        }
        Card card = Library.Instance.TopCard();

        DrawEvent e = new DrawEvent{Card = card};
        DrawEvent.Publish(e);
        Debug.Log("card draw, from player");

        if (e.IsCancled())
        {
            return;
        }

        Library.Remove(card);
        Hand.Instance.Add(card);
    }

    public void Discard(Card card)
    {
        if (Hand.Instance.Contains(card))
        {
            DiscardEvent.Publish(new DiscardEvent{card = card});
            Hand.Instance.Remove(card);
            Graveyard.Instance.Add(card);
        }
        
    }
}
