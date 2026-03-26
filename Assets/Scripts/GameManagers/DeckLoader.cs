using System;
using UnityEngine;
using CogCards;

[System.Serializable]
public class DeckJsonData
{
    public string deckName;
    public int supporterId;
    public string[] cogCardIds;
    public int[] bookIds;
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

        Deck deck = new Deck {
            //根据json文件创建套牌
            //套牌名称
            name = deckData.deckName,
        };
        
        //协助者
        if(deckData.supporterId != 0) {
            Supporter supporter = Supporters.supporters[deckData.supporterId];
            deck.supporter = supporter;
            Debug.Log($"协助者为{supporter.Name},认知等级为{supporter.CogCurrentLevel}");

            //添加认知卡
            int cogLevelAmount = 0;
            foreach(string cogCardId in deckData.cogCardIds) {
                CogCard cogCard = CogCardLoader.GetCogCard(cogCardId);
                if(cogCard != null) {
                    deck.cogCards.Add(cogCard);
                    Debug.Log($"加入了认知卡{cogCard.Name},认知等级为{cogCard.CogLevel}");
                    cogLevelAmount += cogCard.CogLevel;
                }
            }

            //检查认知卡合法性
            if(cogLevelAmount >= supporter.CogCurrentLevel) {
                Debug.LogWarning("套牌认知等级不合法");
            }
        }

        foreach (int bookId in deckData.bookIds) {
            Book book = Books.books.GetByKey1(bookId);
        }
        //加载套牌的卡牌列表
        foreach (string cardId in deckData.cardIds) {
            // Load each card by ID
            Card card = CardFactory.CreateCard(cardId);
            if (card != null)
            {
                deck.cards.Add(card);
                Debug.Log($"Card added to deck: {card.Id},{card.Name}");
            }
        }

        return deck;
    }
}
