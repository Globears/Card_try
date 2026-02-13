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

    public static void Load()
    {
        cardInfos = CardInfoLoader.LoadFromResources("CardsInfo");
        Debug.Log("Loaded card info");

        //输出字典中所有的键
        foreach (var key in cardInfos.Keys)
        {
            Debug.Log(key);
        }
    }

    public static CardInfo GetCardInfo(string id)
    {
        return cardInfos[id];
    }
}