using System;
using System.Collections.Generic;
using UnityEngine;

public class CardInfo
{
    /// <summary>
    /// 卡牌的ID
    /// </summary>
    public string id;
    /// <summary>
    /// 卡牌的名称
    /// </summary>
    public string card_name;

    /// <summary>
    /// 卡牌的描述
    /// </summary>
    public string card_description;
    
    /// <summary>
    /// 卡牌的动作名称
    /// </summary>
    public string action_name;

    /// <summary>
    /// 卡牌的动作描述
    /// </summary>
    public string action_description;

    /// <summary>
    /// 卡牌的附赠动作名称
    /// </summary>
    public string bonus_action_name;
    
    /// <summary>
    /// 卡牌的附赠动作描述
    /// </summary>
    public string bonus_action_description;
}


public class CardsInfo
{
    public static Dictionary<String, CardInfo> cardInfos = new Dictionary<String, CardInfo>();

    public static CardInfo insertImageInfo = new CardInfo(){
        id = "B00C01",
        card_name = "插图",
        card_description="这是插图",
        action_name="插图",
        action_description="无心相\n1力：12，23，34，45，56，67，78，89",
        bonus_action_name="",
        bonus_action_description=""
    };

    public static void Load()
    {
        cardInfos = CardInfoLoader.LoadFromResources("CardsInfos/Cardsinfo");
        cardInfos.Add("B00C01",insertImageInfo);
        
        Debug.Log("Loaded card info");

        //输出字典中所有的键
        foreach (var key in cardInfos.Keys)
        {
            Debug.Log(key + ":" + cardInfos[key].card_name);
        }
    }

    public static CardInfo GetCardInfo(string id) {
        return cardInfos[id];
    }
}