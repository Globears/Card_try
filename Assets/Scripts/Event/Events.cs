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

public class CardResolveEvent
{
    public class Pre : Event<Pre>{
        public Card card;
        /// <summary>
        /// 卡牌在队列中的序号（轮次1的行动和附赠行动分别是12，以此类推）
        /// </summary>
        public int index;
    }

    public class Post : Event<Post> {
        public Card card;
        /// <summary>
        /// 卡牌在队列中的序号（轮次1的行动和附赠行动分别是12，以此类推）
        /// </summary>
        public int index;
    }
}

public class ActResolveEvent : Event<ActResolveEvent>{
    public Act act;
}

public class DiscardEvent : Event<DiscardEvent>
{
    public Card card;
}