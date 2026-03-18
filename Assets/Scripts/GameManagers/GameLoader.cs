using System;
using UnityEngine;

/// <summary>
/// 游戏加载器
/// 负责在游戏软件打开后加载所有资源
/// </summary>
public class GameLoader : SingletonBehaviour<GameLoader>
{
    public bool isLoaded = false;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        LoadInfo();
    }

    private void LoadInfo() {
        if(isLoaded) {
            Debug.LogError("isLoaded为真，不要重复调用LoadInfo()");
            return;
        }
        Debug.Log("GameLoader: 开始加载游戏");
        //初始化所有卡牌
        Cards.Load();
        //从json加载卡牌的描述信息
        CardsInfo.Load();
        //初始化所有敌人
        Enemies.Load();
        //敌人还没有什么描述信息
        
        //加载书籍数据
        Books.Load();
        //加载书籍描述数据

        //加载认知卡
        CogCards.Load();

        //加载协助者
        Supporters.Load();
        //加载关卡数据
        Levels.Load();

        //初始化日志
        Logger.Init();

        Debug.Log("GameLoader: 游戏加载完成");
        isLoaded = true;
    }
}
