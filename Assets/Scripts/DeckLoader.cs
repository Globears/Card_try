using System;
using UnityEngine;


[System.Serializable]
public class DeckJsonData
{
    public string deckName;
    public string[] cardIds;
}

/// <summary>
/// DeckLoader负责从资源文件夹中的json文件加载套牌数据
/// </summary>
public class DeckLoader
{
    public static Deck LoadDeckFromResources(string deckPath)
    {
        //去掉后缀，如果有
        if (deckPath.EndsWith(".json"))
        {
            deckPath = deckPath.Replace(".json", "");
        }

        //读取json文件
        TextAsset jsonFile = Resources.Load<TextAsset>(deckPath);
        if (jsonFile == null)
        {
            Debug.LogError($"Deck file not found: {deckPath}");
            return null;
        }

        //解析json文件
        DeckJsonData deckData = JsonUtility.FromJson<DeckJsonData>(jsonFile.text);

        //根据json文件创建套牌
        Deck deck = new Deck();

        foreach(string cardId in deckData.cardIds)
        {
            // Load each card by ID
            Card card = CardFactory.CreateCard(cardId);
            if (card != null)
            {
                deck.cards.Add(card);
                Debug.Log($"Card added to deck: {card.Id}");
            }
        }

        return deck;
    } 
}
