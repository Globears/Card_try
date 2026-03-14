using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 监听下一次T事件发生并进行一次性触发的Action
/// </summary>
/// <typeparam name="T">T应该传输为Event<T>类型</typeparam>
public class NextEventEffect<T> : Effect where T : Event<T>
{
    private Action action;
    private Action<T> triggerHandler;
    
    public NextEventEffect(Action action) : base()
    {
        this.action = action;
        this.triggerHandler = Trigger;
    }
    
    public override void Cast()
    {
        Event<T>.subscriber += triggerHandler;
    }
    
    private void Trigger(T e)
    {
        if (!e.IsCancled())
        {
            action();
        }
        Event<T>.subscriber -= triggerHandler;
    }
}