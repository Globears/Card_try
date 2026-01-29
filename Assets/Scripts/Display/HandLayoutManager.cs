using System.Collections.Generic;
using UnityEngine;

public class HandLayoutManager : MonoBehaviour
{

    private static HandLayoutManager instance;  

    public static HandLayoutManager Instance
    {
        get
        {

            return instance;
        }

    }

    public static List<CardDisplay> cardDisplays = new List<CardDisplay>();

    private float width = 16, height = 2;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
        DiscardEvent.subscriber += OnDiscard;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float interval = width / ( cardDisplays.Count + 1 );
        for(int i = 0 ; i < cardDisplays.Count ; i++)
        {
            if(cardDisplays[i] == null)
            {
                continue;
            }
            cardDisplays[i].setPosition(new Vector2(transform.position.x - width/2 + interval * (i+1), transform.position.y));
        }
    }

    public void OnHandAddEvent(HandAddEvent e)
    {
        
    }

    public void OnDiscard(DiscardEvent e)
    {
        CardDisplay cardDisplay = CardDisplayManager.GetCardDisplay(e.card);
        if(cardDisplay != null)
        {
            Remove(cardDisplay);
        }

        
    }

    public void Hold(CardDisplay cardDisplay)
    {
        cardDisplays.Add(cardDisplay);
    }

    public void Remove(CardDisplay cardDisplay)
    {
        cardDisplays.Remove(cardDisplay);
    }
}
