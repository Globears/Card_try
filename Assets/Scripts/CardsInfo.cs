using System;
using System.Collections.Generic;
using UnityEngine;

public class CardInfo
{
    public string id;
    public string action_name;
    public string action_description;
    public string bonus_action_name;
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