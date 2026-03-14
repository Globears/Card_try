using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 一直监听TListen事件发生并执行Action，直到TUntil事件触发
/// 
/// 监听TListen事件，每次发生都执行TriggerAction
/// 监听到TUntil事件后，执行EndAction然后取消二者的订阅
/// </summary>
/// <typeparam name="TListen">TListen应该传输为Event<TListen>类型</typeparam>
/// <typeparam name="TUntil">TUntil应该传输为Event<TUntil>类型</typeparam>
public class EventUntilEventEffect<TListen,TUntil> : Effect where TListen : Event<TListen> where TUntil : Event<TUntil> {
    /// <summary>
    /// 执行的Action 以Tlisten为参数
    /// </summary>
    private Action<TListen> TriggerAction;
    /// <summary>
    /// 结束监听的Action 以TUntil为参数
    /// </summary>
    private Action<TUntil> UntilAction;
    /// <summary>
    /// 监听TListen事件的触发函数
    /// </summary>
    private Action<TListen> TriggerHandler;
    /// <summary>
    /// 监听TUntil事件的触发函数
    /// </summary>
    private Action<TUntil> UntilHandler;

    /// <summary>
    /// 传入一个参数的EventUntilEventEffect的构造函数，UntilAction默认为空
    /// </summary>
    /// <param name="triggerAction"></param>
    public EventUntilEventEffect(Action<TListen> triggerAction) {
        this.TriggerAction = triggerAction;
        this.UntilAction = null;
        this.TriggerHandler = Trigger;
        this.UntilHandler = Until;
    }

    /// <summary>
    /// 传入两个参数的EventUntilEventEffect的构造函数
    /// </summary>
    /// <param name="triggerAction"></param>
    /// <param name="untilAction"></param>
    public EventUntilEventEffect(Action<TListen> triggerAction,Action<TUntil> untilAction) : base()
    {
        this.TriggerAction = triggerAction;
        this.UntilAction = untilAction;
        this.TriggerHandler = Trigger;
        this.UntilHandler = Until;
    }
    
    public override void Cast()
    {
        Event<TListen>.subscriber += TriggerHandler;
        Event<TUntil>.subscriber += UntilHandler;
    }
    
    private void Trigger(TListen e)
    {
        if (!e.IsCancled())
        {
            TriggerAction(e);
        }
    }

    private void Until(TUntil e) {
        if (!e.IsCancled() & UntilAction != null) {
            UntilAction(e);
        }
        Event<TListen>.subscriber -= TriggerHandler;
        Event<TUntil>.subscriber -= UntilHandler;
    }
}