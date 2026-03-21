using System;
using System.Collections.Generic;


/// <summary>
/// 即刻
/// 共鸣、气场等效果不单独设立基类，因为特例太多
/// </summary>
public class Instant : Effect {
    private System.Action<Effect> action;
    public Instant(System.Action<Effect> action) { this.action = action; }
    public override void Cast() { action?.Invoke(this); }
    public override Effect Clone() { return new Instant(action); }
}