using System;
using System.Collections.Generic;
using UnityEngine;

public class BonusAct : Act
{
    public BonusAct(Card owner, MindPhase.Prefix prefix, MindPhase.Suffix suffix)
        : base(owner, prefix, suffix) {
        
    }

    public BonusAct(Card owner, MindPhase.Prefix prefix, MindPhase.Suffix suffix,List<TAGS> tags)
        : base(owner, prefix, suffix, tags) {
        
    }

    public new BonusAct Clone()
    {
        BonusAct clone = (BonusAct)this.MemberwiseClone();
        clone.DefenseSequences = new List<DefenseSequence>(DefenseSequences);
        clone.Effects = new List<Effect>(Effects);
        foreach (Effect effect in Effects)
        {
            clone.AddEffect(effect);
        }
        return clone;
    }
}
