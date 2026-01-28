using System.Collections.Generic;
using UnityEngine;

public class DiscardState : TurnState
{
    public DiscardState()
    {
        title = "Discard State";
    }

    public override void Enter()
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    public override TurnState NextState()
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        //实现自信的特殊效果：回合结束时，有10x%的概率不丢弃手牌
        List<Node> nodes = GridManager.Instance.Nodes;
        int confidenceLevel = 0;
        foreach(Node node in nodes)
        {
            confidenceLevel += node.MindPhases[MindPhase.Suffix.Confidence];
        }
        if (Random.Range(0, 100) < 10 * confidenceLevel)
        {
            // 不丢弃手牌

        }
        else
        {
            //丢弃手牌
        }

    }
}
