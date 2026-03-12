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
        DrawStateEvent.Pre.Publish(new DrawStateEvent.Pre());
        for(int i = 0 ; i < 5 ; i++)
        {
            Player.Instance.Draw();
        }
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
