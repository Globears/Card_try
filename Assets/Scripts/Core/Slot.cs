using UnityEngine;

public class Slot
{
    private bool isActionSlot;

    public Card card;

    public bool IsActionSlot => isActionSlot;

    public void ResolveCard()
    {
        if(card == null)
        {
            return;
        }

        if (isActionSlot)
        {
            card.ResolveActionDefence();
        }
        else
        {
            card.ResolveBonusActionDefence();
        }
    }

    public void Hold(Card card)
    {
        this.card = card;
    }

    public Card GetCard()
    {
        return card;
    }

    public void Clear()
    {
        card = null;
    }

    public bool Contains(Card card)
    {
        return this.card == card;
    }
}
