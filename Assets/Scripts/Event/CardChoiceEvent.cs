using System;
using System.Collections.Generic;
using UnityEngine;

public class CardChoiceEvent : Event<CardChoiceEvent>
{
    public List<Card> Cards;
    public Action<Card> callBack;
}
