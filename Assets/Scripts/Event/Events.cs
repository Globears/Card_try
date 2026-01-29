using UnityEngine;

public class DrawEvent : Event<DrawEvent>
{
    public Card Card;
}

public class HandAddEvent : Event<HandAddEvent>
{
    public Card card;
    
}

public class DrawStateEvent
{
    public class Pre : Event<Pre>
    {
        
    }

    public class Post : Event<Post>
    {

    }

}

public class CardResolveEvent : Event<CardResolveEvent>
{
    public Card card;
}

public class ActResolveEvent : Event<ActResolveEvent>
{
    public Act act;
}

public class DiscardEvent : Event<DiscardEvent>
{
    public Card card;
}