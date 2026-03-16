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
        //从套牌json读取套牌到内存中
        Deck deck = DeckLoader.LoadDeckFromResources("Decks/deck");
        Library.Instance.LoadDeck(deck);
        Library.Shuffle();

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
