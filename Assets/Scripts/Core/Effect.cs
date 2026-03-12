using UnityEngine;

public abstract class Effect
{
    public Act owner;

    public Effect() {
        
    }

    //Cast由行动在结算时释放
    public virtual void Cast() {
        //可能负责订阅事件之类的
    }

    


}
