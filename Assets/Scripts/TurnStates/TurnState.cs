using UnityEngine;

public abstract class TurnState
{
    protected TurnStateMachine turnStateMachine;

    public string title = "Undefined State";

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
    public abstract TurnState NextState();
}
