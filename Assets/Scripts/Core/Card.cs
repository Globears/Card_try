using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 卡牌基类
/// </summary>
public class Card
{

    public String Id;

    /// <summary>
    /// 卡牌的前缀心相
    /// </summary>
    public MindPhase.Prefix Prefix;
    
    /// <summary>
    /// 卡牌的后缀心相
    /// </summary>
    public MindPhase.Suffix Suffix;

    /// <summary>
    /// 卡牌的动作
    /// </summary>
    public Act action;

    /// <summary>
    /// 卡牌的附赠动作
    /// </summary>
    public BonusAct bonusAction;

    public bool IsCoverCard = false; //是否为封底牌
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
