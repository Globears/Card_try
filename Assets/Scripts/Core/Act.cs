using System.Collections.Generic;
using UnityEngine;

public class Act
{


    public Card owner; //防守来自哪个卡牌

    //心相
    public MindPhase.Prefix Prefix;
    public MindPhase.Suffix Suffix;
    public List<TAGS> tags = new List<TAGS>();

    public List<DefenseSequence> DefenseSequences = new List<DefenseSequence>();

    public List<Effect> Effects = new List<Effect>();

    public Act(Card owner, MindPhase.Prefix prefix, MindPhase.Suffix suffix)
    {
        this.owner = owner;
        Prefix = prefix;
        Suffix = suffix;
    }

    public Act(Card owner, MindPhase.Prefix prefix, MindPhase.Suffix suffix,List<TAGS> tAGS)
    {
        this.owner = owner;
        Prefix = prefix;
        Suffix = suffix;
        tags = tAGS;
        tags.Add(CardTag.PrefixToTag(prefix));
        tags.Add(CardTag.SuffixToTag(suffix));
    }

    public void ResolveEffects()
    {
        foreach (Effect effect in Effects)
        {
            effect.Cast();
        }
    }
    
    public void ResolveDefence()
    {
        //基类可以实现基本的设防逻辑
        foreach (DefenseSequence defenseSequence in DefenseSequences)
        {
            Defense defense = defenseSequence.Begin;
            //TODO:这里需要改成Beacon的位置在序列中就可以跑通，但是效果是在序列中的Beacon位置（包括）的后续才会设防，在这之前（不包括）的就不会
            //比如说1力123456789 beacon在5 那就会给1力56789，1234不会给防御
            if(defense.Position == Beacon.Instance.Position)
            {
                //该设防序列是可用的，结算它
                //如果上一个动作或附赠具有和这个动作相同的心相，该设防序列中的所有防御+1力
                if (Logger.getLastAct() != null &&( Logger.getLastAct().Prefix == Prefix || Logger.getLastAct().Suffix == Suffix))
                {
                    for (int i = 0; i < defenseSequence.Sequence.Count; i++)
                    {
                        defenseSequence.Sequence[i].Power += 1;
                    }
                }
                defenseSequence.Apply();
            }
        }
    }

    /// <summary>
    /// 为防御序列添加力度
    /// </summary>
    /// <param name="power"></param>
    public void AddPowerOnDefenseSequences(int power) {
        foreach (DefenseSequence defenseSequence in DefenseSequences)
        {
            for (int i = 0; i < defenseSequence.Sequence.Count; i++)
            {
                defenseSequence.Sequence[i].Power += power;
            }
        }
    }
    
    public void CreateDefenseSequence(string config)
    {
        DefenseSequences = DefenseSequence.CreateDefenseSequences(config, this, Prefix, Suffix);
    }

    public void AddEffect(Effect effect)
    {
        if (!Effects.Contains(effect))
        {
            Effects.Add(effect);
        }
        
        effect.owner = this;
    }

    public Act Clone()
    {
        Act clone = (Act)this.MemberwiseClone();
        clone.DefenseSequences = new List<DefenseSequence>(DefenseSequences);
        clone.Effects = new List<Effect>(Effects);
        foreach (Effect effect in Effects)
        {
            clone.AddEffect(effect);
        }

        return clone;
    }


}
