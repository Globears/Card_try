using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// CardGameManager负责管理游戏卡牌对战环节内的流程
/// </summary>
public class CardGameManager : SingletonBehaviour<CardGameManager>
{
    protected bool IsStarted = false;
    public static int currentLevelId;
    public static Level currentLevel;
    /// <summary>
    /// 当前回合数，注意从1开始
    /// </summary>
    public static int currentTurn = 1;
    /// <summary>
    /// 当前回合的轮次数，注意从0开始
    /// </summary>
    public static int currentRound = 0;
    /// <summary>
    /// 所有在格子里的卡牌的List（按照轮次1行动 轮次1附赠 轮次2行动……来排列）
    /// </summary>
    public static List<Card> allSlotCards;
    /// <summary>
    /// 当前正在结算的卡牌在allSlotCards中的Index
    /// </summary>
    public static int currentResolveCardIndex = 0;
    /// <summary>
    /// 最大“摧毁”影响值
    /// </summary>
    public static int HEALTH = DEFAULT_HEALTH;
    public const int DEFAULT_HEALTH = 7;

    protected override void Awake() {
        base.Awake();
        GameStartEvent.subscriber += OnGameStart;
        TurnBeginEvent.subscriber += OnTurnStart;
        RoundStartEvent.subscriber += OnRoundStart;
        CombatStartEvent.subscriber += OnCombatStart;
        CardResolveEvent.Pre.subscriber += OnCardResolvePre;
    }
    void Start() {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitLevel()
    {
        
    }

    public void OnGameStart(GameStartEvent e) {
        StartGame();
    }

    public void OnTurnStart(TurnBeginEvent e) {
        currentTurn ++;
        Debug.Log($"CurrentTurn被+1 现在是：{currentTurn}");
    }

    public void OnRoundStart(RoundStartEvent e) {
        currentRound = e.roundNum;
        Debug.Log($"CurrentNum被更新,现在是{currentRound}");
    }

    public void OnCombatStart(CombatStartEvent e) {
        allSlotCards = SlotManager.Instance.GetAllCardInSlots();
    }

    public void OnCardResolvePre(CardResolveEvent.Pre e) {
        currentResolveCardIndex = e.index;
    }

    public Card GetNextCard() {
        Debug.Log($"寻找{currentResolveCardIndex}的下一张牌");
        for(int i = currentResolveCardIndex+1;i < allSlotCards.Count; i++) {
            if(allSlotCards[i] != null) return allSlotCards[i];
        }
        Debug.Log("没有找到下一张牌!");
        return null;
    }

    public Act GetNextAction() {
        Debug.Log($"寻找{currentResolveCardIndex}的下一张牌的行动");
        for(int i = currentResolveCardIndex+1;i < allSlotCards.Count; i++) {
            if(allSlotCards[i] != null) {
                if(i%2 == 0) return allSlotCards[i].action;
                if(i%2 == 1) return allSlotCards[i].bonusAction;
            }
        }
        Debug.Log("没有找到下一张牌!");
        return null;
    }

    public void StartGame() {
        //初始化挪到了GameLoader中，这里只负责游戏（指游戏内卡牌对战的环节）开始时的逻辑
        if(IsStarted) {
            Debug.LogError("IsStarted为真，检查代码");
            return;
        }
        IsStarted = true;
        Debug.Log("CardGameManager: 开始游戏");
        //检查当前场景名称
        if(SceneManager.GetActiveScene().name != "CardGameScene") {
            Debug.LogError($"{this}:当前场景不是CardGameScene");
            return;
        }
        if(GameLoader.Instance == null) {
            Debug.LogError($"{this}:GameLoader的Instance为空");
            return;
        }
        if(!GameLoader.Instance.isLoaded) {
            Debug.LogError($"{this}:GameLoader未加载完成");
            return;
        }
        GameLoadEvent.Pre.Publish(new GameLoadEvent.Pre());

        //从套牌json读取套牌到内存中
        Deck deck = DeckLoader.LoadDeckFromResources("Decks/deck");
        //TODO:处理Level
        currentLevelId = 1;
        currentTurn = 0;
        currentLevel = Levels.GetLevelWithId(currentLevelId);
        //TODO:初始化数值
        HEALTH = DEFAULT_HEALTH;
        //TODO:处理目标

        //TODO:处理Deck

        //处理认知卡
        if(deck.cogCards != null) {
            foreach(CogCard cogCard in deck.cogCards) {
                //调用所有认知卡的效果的Cast函数 订阅对应的事件 效果在Effect里面触发后处理Trigger函数
                cogCard.ResloveAllEffects();
            }
        }

        //处理封底
        if(deck.books != null) {
            foreach(Book book in deck.books) {
                foreach(Card finishCard in book.FinalCards) {
                    CoverLibrary.Instance.Add(finishCard);
                }
                new FinishCardAdderEffect(book).Cast();
            }
        }

        if(deck.cards.Count < 30) {
            int insertNum = 30 - deck.cards.Count;
            for(int i = 0;i< insertNum; i++) {
                deck.cards.Add(Cards.GetPrototypeById("B00C01").Clone());
            }
        }
        //把插页洗入牌库
        Library.Instance.LoadDeck(deck);
        Library.Shuffle();

        //处理关卡
        

        Debug.Log("加载完毕");
        GameLoadEvent.Post.Publish(new GameLoadEvent.Post());
        //回合进入开始阶段
        TurnStateMachine.Instance.TransitState(new StartState());

    }

    public void NextState()
    {
        TurnStateMachine.Instance.GoNextState();
    }

    protected override void OnDestroy() {
        IsStarted = false;
        GameStartEvent.subscriber -= OnGameStart;
        base.OnDestroy();
    }
}
