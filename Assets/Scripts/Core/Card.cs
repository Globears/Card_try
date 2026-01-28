using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Card
{
    public String Id;
    public MindPhase.Prefix Prefix;
    public MindPhase.Suffix Suffix;

    public Act action;
    public BonusAct bonusAction;

    public delegate void DrawEventHandler(DrawEvent e);
    public event DrawEventHandler DrawEvent;


    public virtual void ResolveAction()
    {
        action.Resolve();
    }

    public virtual void ResolveBonusAction()
    {
        bonusAction.Resolve();
    }

    public Card(string Id, MindPhase.Prefix Prefix, MindPhase.Suffix Suffix)
    {
        this.Id = Id;
        this.Prefix = Prefix;
        this.Suffix = Suffix;
        action = new Act(this, Prefix, Suffix);
        bonusAction = new BonusAct(this, Prefix, Suffix);
    }

    public virtual Card Clone()
    {
        //应当创建一个新的对象，拷贝该卡牌的各种属性
        Card clone = (Card)this.MemberwiseClone();
        clone.action = action.Clone();
        clone.bonusAction = bonusAction.Clone();

        return clone;
    }
}
