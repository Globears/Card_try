using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 卡牌基类
/// </summary>
public class Card
{
    /// <summary>
    /// 卡牌ID，唯一标识符
    /// </summary>
    public String Id;
    /// <summary>
    /// 卡牌名称
    /// </summary>
    public string Name;

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
    /// <summary>
    /// 卡牌的Tag
    /// </summary>
    public List<TAGS> cardTags = new List<TAGS>();

    public bool IsCoverCard = false; //是否为封底牌
    public delegate void DrawEventHandler(DrawEvent e);
    public event DrawEventHandler DrawEvent;

    public virtual void ResolveActionEffects()
    {
        action.ResolveEffects();
    }
    public virtual void ResolveBonusActionEffects()
    {
        bonusAction.ResolveEffects();
    }

    public virtual void ResolveActionDefence()
    {
        action.ResolveDefence();
    }

    public virtual void ResolveBonusActionDefence()
    {
        bonusAction.ResolveDefence();
    }

    public Card(string Id,string Name, MindPhase.Prefix Prefix, MindPhase.Suffix Suffix)
    {
        this.Id = Id;
        this.Name = Name;
        this.Prefix = Prefix;
        this.Suffix = Suffix;
        action = new Act(this, Prefix, Suffix);
        bonusAction = new BonusAct(this, Prefix, Suffix);
        cardTags.Add(CardTag.PrefixToTag(Prefix));
        cardTags.Add(CardTag.SuffixToTag(Suffix));
    }

    public Card(string Id,string Name, MindPhase.Prefix Prefix, MindPhase.Suffix Suffix,List<TAGS> actTags,List<TAGS> bonusActTags)
    {
        this.Id = Id;
        this.Name = Name;
        this.Prefix = Prefix;
        this.Suffix = Suffix;
        action = new Act(this, Prefix, Suffix, actTags);
        bonusAction = new BonusAct(this, Prefix, Suffix,bonusActTags);
        cardTags.Add(CardTag.PrefixToTag(Prefix));
        cardTags.Add(CardTag.SuffixToTag(Suffix));
        foreach(TAGS tag in actTags) {
            cardTags.Add(tag);
        }
        foreach(TAGS tag in bonusActTags) {
            cardTags.Add(tag);
        }
    }

    public void SetCover() {
        this.IsCoverCard = true;
        cardTags.Add(TAGS.COVER);
        action.tags.Add(TAGS.COVER);
        bonusAction.tags.Add(TAGS.COVER);
    }

    public void AddTag(TAGS tAGS) {
        if(!cardTags.Contains(tAGS)) this.cardTags.Add(tAGS);
        if(!action.tags.Contains(tAGS)) this.action.tags.Add(tAGS);
        if(!bonusAction.tags.Contains(tAGS)) this.bonusAction.tags.Add(tAGS);
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
