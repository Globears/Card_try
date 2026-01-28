using UnityEngine;

public class Level : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //初始化所有卡牌
        Cards.Load();
        //从json加载卡牌的描述信息
        CardsInfo.Load();

        //初始化所有敌人
        Enemies.Load();
        //敌人还没有什么描述信息

        //初始化日志
        Logger.Init();

        //从套牌json读取套牌到内存中
        Deck deck = DeckLoader.LoadDeckFromResources("Decks/deck");
        Library.Instance.LoadDeck(deck);

        //回合进入抓牌阶段
        TurnStateMachine.Instance.TransitState(new DrawState());


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitLevel()
    {
        
    }

    public void NextState()
    {
        TurnStateMachine.Instance.GoNextState();
    }

    public void Draw()
    {
        Library.Instance.Draw();
    }

    
}
