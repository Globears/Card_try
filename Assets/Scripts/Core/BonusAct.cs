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

        // 深拷贝 tags
        clone.tags = new List<TAGS>(this.tags);

        // 深拷贝 DefenseSequences（每个 Defense 指向 clone）
        clone.DefenseSequences = new List<DefenseSequence>();
        foreach (var seq in this.DefenseSequences)
        {
            clone.DefenseSequences.Add(seq.Clone(clone));
        }

        // 深拷贝 Effects（每个 Effect 为新的实例）
        clone.Effects = new List<Effect>();
        foreach (var eff in this.Effects)
        {
            var effClone = eff.Clone();
            clone.AddEffect(effClone); // AddEffect 会设置 effClone.owner = clone
        }

        return clone;
    }
}
