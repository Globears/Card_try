using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardInfoJsonData
{
    public string id;
    public string card_name;
    public string action_name;
    public string action_description;
    public string bonus_action_name;
    public string bonus_action_description;
}

[System.Serializable]
public class RootCardJsonData
{
    public CardInfoJsonData[] cardsInfo;
}

public class CardInfoLoader
{
    public static Dictionary<string, CardInfo> LoadFromResources(string cardsInfoPath)
    {
        if (cardsInfoPath.EndsWith(".json"))
        {
            cardsInfoPath = cardsInfoPath.Replace(".json", "");
        }

        TextAsset textAsset = Resources.Load<TextAsset>(cardsInfoPath);
        if (textAsset == null)
        {
            Debug.LogError("Failed to load JSON file from Resources: " + cardsInfoPath);
            return null;
        }

        string jsonString = textAsset.text;
        RootCardJsonData rootData = JsonUtility.FromJson<RootCardJsonData>(jsonString);

        if (rootData == null)
        {
            Debug.LogError($"Failed to parse JSON (rootData==null) from Resources: {cardsInfoPath}\nJSON:\n{jsonString}");
            return null;
        }
        if (rootData.cardsInfo == null || rootData.cardsInfo.Length == 0)
        {
            Debug.LogError($"No 'rootInfos' found or empty in JSON: {cardsInfoPath}\nJSON:\n{jsonString}");
            return null;
        }

        Dictionary<string, CardInfo> cardInfos = new Dictionary<string, CardInfo>();
        foreach (var cardInfo in rootData.cardsInfo)
        {
            cardInfos[cardInfo.id] = new CardInfo
            {
                id = cardInfo.id,
                card_name = cardInfo.card_name,
                action_name = cardInfo.action_name,
                action_description = cardInfo.action_description,
                bonus_action_name = cardInfo.bonus_action_name,
                bonus_action_description = cardInfo.bonus_action_description
            };
        }

        return cardInfos;
    }
}
