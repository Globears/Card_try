using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// CardGameManager负责管理游戏卡牌对战环节内的流程
/// </summary>
public class CardGameManager : SingletonBehaviour<CardGameManager>
{
    protected bool IsStarted = false;
    protected override void Awake() {
        base.Awake();
        GameStartEvent.subscriber += OnGameStart;
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
        //处理目标

        //处理Deck

        //处理认知卡
        if(deck.cogCards != null) {
            foreach(CogCard cogCard in deck.cogCards) {
                //调用所有认知卡的效果的Cast函数 订阅对应的事件 效果在Effect里面触发后处理Trigger函数
                cogCard.ResloveAllEffects();
            }
        }

        //处理封底
        //TODO：这里需要考虑一下，有多个封底卡的问题
        if(deck.books != null) {
            foreach(Book book in deck.books) {
                foreach(Card finishCard in book.FinalCards) {
                    CoverLibrary.Instance.Add(finishCard);
                }
            }
        }

        //把插页洗入牌库
        Library.Instance.LoadDeck(deck);
        Library.Shuffle();

        Debug.Log("加载完毕");
        GameLoadEvent.Post.Publish(new GameLoadEvent.Post());
        //回合进入抓牌阶段
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
