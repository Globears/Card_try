using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplayManager : SingletonBehaviour<CardDisplayManager>
{
    private static List<CardDisplay> cardDisplays = new List<CardDisplay>();

    private static Dictionary<Card, CardDisplay> cardToDisplays = new Dictionary<Card, CardDisplay>();

    public CardDisplay cardDisplayPrefab;

    protected override void Awake()
    {
        base.Awake();
        DrawEvent.subscriber += OnDraw;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnDraw(DrawEvent drawEvent)
    {
        Debug.Log("card draw, from carddisplay manager");
        CardDisplay cardDisplay = Instantiate(cardDisplayPrefab);
        cardDisplay.Bind(drawEvent.Card);
        
        cardDisplays.Add(cardDisplay);
        cardToDisplays.Add(drawEvent.Card, cardDisplay);
        HandLayoutManager.Instance.Hold(cardDisplay);
        
    }

    public static CardDisplay GetCardDisplay(Card card)
    {
        if (cardToDisplays.TryGetValue(card, out CardDisplay display))
        {
            return display;
        }
        return null;
    }

    
}
