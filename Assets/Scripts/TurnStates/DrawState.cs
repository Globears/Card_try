using UnityEngine;

public class DrawState : TurnState
{
    
    public DrawState()
    {
        title = "Draw State";
    }

    public override void Enter()
    {
        DrawStateEvent.Pre.Publish(new DrawStateEvent.Pre());
        Library.Instance.Draw();
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
