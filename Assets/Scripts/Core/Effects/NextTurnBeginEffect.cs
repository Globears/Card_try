using System;
using System.Collections.Generic;
using UnityEngine;

public class NextTurnBeginEffect : Effect{
    private System.Action action;
    public NextTurnBeginEffect(Action action) : base() {
        this.action = action;
    }

    public override void Cast() {
        TurnBeginEvent.subscriber += Trigger;
    }

    public void Trigger(TurnBeginEvent e) {
        action();
        TurnBeginEvent.subscriber -= Trigger;
    }
}