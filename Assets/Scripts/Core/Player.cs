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
