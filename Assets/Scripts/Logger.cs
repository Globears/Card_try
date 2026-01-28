using System.Collections.Generic;
using UnityEngine;

public class Logger
{

    public static void Init()
    {
        ActResolveEvent.subscriber += OnActResolve;
    }

    public static List<Card> historyCards = new List<Card>();

    public static List<Act> historyActs = new List<Act>();

    public static Card getLastCard()
    {
        if (historyCards.Count > 0)
        {
            return historyCards[historyCards.Count - 1];
        }
        return null;
    }

    public static Act getLastAct()
    {
        if (historyActs.Count > 0)
        {
            return historyActs[historyActs.Count - 1];
        }
        return null;
    }

    public static void OnActResolve(ActResolveEvent actResolveEvent)
    {
        historyActs.Add(actResolveEvent.act.Clone());
    }
}
