using System;
using UnityEngine;

public class TurnStateMachine
{
    private static TurnStateMachine instance;

    public static TurnStateMachine Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new TurnStateMachine();
            }
            return instance;
        }

    }

    private TurnStateMachine()
    {
        
    }


    private TurnState currentState;

    public void TransitState(TurnState state)
    {
        currentState?.Exit();
        currentState = state;
        currentState?.Enter();
    }

    public void GoNextState()
    {
        TurnState nextState = currentState.NextState();
        TransitState(nextState);

    }

    public TurnState GetCurrentState()
    {
        return currentState;
    }
}
