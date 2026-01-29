using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiscardState : TurnState
{
    public DiscardState()
    {
        title = "Discard State";
    }

    public override void Enter()
    {
        Update();
    }

    public override void Exit()
    {
        
    }

    public override TurnState NextState()
    {
        ClearState clearState = new ClearState();
        return clearState;
    }

    public override void Update()
    {
        //实现自信的特殊效果：回合结束时，有10x%的概率不丢弃手牌
        List<Node> nodes = GridManager.Instance.Nodes;
        int confidenceLevel = 0;
        foreach(Node node in nodes)
        {
            if(node.MindPhases.ContainsKey(MindPhase.Suffix.Confidence))
                confidenceLevel += node.MindPhases[MindPhase.Suffix.Confidence];
        }
        if (Random.Range(0, 100) < 10 * confidenceLevel)
        {
            // 不丢弃手牌

        }
        else
        {
            //丢弃手牌
            List<Card> cards = new List<Card>();
            foreach(Card card in Hand.Instance.GetCards())
            {
                cards.Add(card);
            }
            foreach(Card card in cards)
            {
                Player.Instance.Discard(card);
            }
        }

    }
}
