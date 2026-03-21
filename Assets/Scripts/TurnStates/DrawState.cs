using UnityEngine;

public class DrawState : TurnState
{
    
    public DrawState()
    {
        title = "Draw State";
    }

    public override void Enter()
    {
        TurnBeginEvent.Publish(new TurnBeginEvent());

        //自信Confidence节点：回合开始时，如果心灵信标位于该节点上，有10*x%的概率额外抽取2张卡牌
        if(Beacon.Instance.GetCurrentNode().MindPhases[MindPhase.Suffix.Confidence] > 0) {
            int rand = Random.Range(1,101);
            if(rand <= Beacon.Instance.GetCurrentNode().MindPhases[MindPhase.Suffix.Confidence] * 10) {
                Debug.Log("自信触发");
                Player.Instance.Draw(2);
            }
        }

        DrawStateEvent.Pre.Publish(new DrawStateEvent.Pre());
        Player.Instance.Draw(5);
        DrawStateEvent.Post.Publish(new DrawStateEvent.Post());


    }

    public override void Exit()
    {
        
    }

    public override TurnState NextState()
    {
        EnemySpawnState enemySpawnState = new EnemySpawnState();
        return enemySpawnState;
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }
}
