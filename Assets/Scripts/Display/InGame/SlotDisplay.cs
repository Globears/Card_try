using UnityEngine;

public class SlotDisplay : MonoBehaviour
{
    public Slot slot;

    public CardDisplay cardDisplay;

    public void Add(CardDisplay cardDisplay)
    {
        this.cardDisplay = cardDisplay;
    }

    public void Release(CardDisplay cardDisplay)
    {
        this.cardDisplay = null;
    }

    void Update()
    {
        if(cardDisplay != null)
        {
            cardDisplay.setPosition(transform.position);
        }
    }
}
