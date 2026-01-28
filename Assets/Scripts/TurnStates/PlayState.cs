using UnityEngine;

public class PlayState : TurnState
{

    public PlayState()
    {
        title = "Play State";
    }

    public override void Enter()
    {
        Debug.Log("Entering play state");
    }

    public override void Exit()
    {
        Debug.Log("Leaving play state");
    }

    public override TurnState NextState()
    {
        CombatState combatState = new CombatState();
        return combatState;
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }
}
