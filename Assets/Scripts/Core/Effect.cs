using UnityEngine;

public abstract class Effect {
    public Act owner;
    public virtual void Cast() {}
    public virtual Effect Clone() { return (Effect)this.MemberwiseClone(); }
}