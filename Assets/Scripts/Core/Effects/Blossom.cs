using System;
using System.Collections.Generic;

/// <summary>
/// 绽放，传递的E是节点信息
/// </summary>
public class Blossom : Effect
{
    private System.Func<ApplyDefenseEvent, bool> action;
    public Blossom(Func<ApplyDefenseEvent, bool> action) : base() {
        this.action = action;
    }

    public override void Cast() {
        GridManager.applyDefenseEvent += Trigger;
    }

    public void Trigger(ApplyDefenseEvent e) {
        action(e);
    }
}