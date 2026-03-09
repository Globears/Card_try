using UnityEngine;

public class StartState : TurnState
{
    
    public StartState()
    {
        title = "Start State";
    }

    public override void Enter(){
        Debug.Log("进入初始化阶段");
    }

    public override void Exit(){
        
    }

    public override TurnState NextState()
    {
        DrawState drawState = new DrawState();
        return drawState;
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }

    public void Initialize() {
        //这里应该是游戏加载时的初始化，关卡加载已经在Level中实现
    }
}
