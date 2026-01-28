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
            card.ResolveAction();
        }
        else
        {
            card.ResolveBonusAction();
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
}
