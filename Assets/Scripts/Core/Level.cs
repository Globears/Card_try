using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;

/// <summary>
/// 关卡的基类
/// </summary>
public class Level {
    /// <summary>
    /// 关卡编号
    /// </summary>
    public int levelId;
    /// <summary>
    /// 关卡名称
    /// </summary>
    public string levelName;
    /// <summary>
    /// 关卡的被动效果描述
    /// </summary>
    public string passiveEffectDescription;
    /// <summary>
    /// 关卡包含的敌人列表
    /// </summary>
    public Dictionary<int,EnemyDangerPairs> enemies = new Dictionary<int, EnemyDangerPairs>();
    /// <summary>
    /// 关卡的轮次数
    /// </summary>
    public int roundCount = 0;
    /// <summary>
    /// 关卡的轮次数对应其的危险等级，用于随机出怪
    /// </summary>
    public Dictionary<int , WaveConfig> roundDangerLevels = new Dictionary<int , WaveConfig>();
    /// <summary>
    /// 关卡的目标
    /// </summary>
    public Dictionary<int , string> roundMissons = new Dictionary<int , string>();
    /// <summary>
    /// 目标效果
    /// </summary>
    public List<Effect> effects = new List<Effect>();

    public Level(int levelId,string levelName,params (int TurnNum, int MinDanger, int MaxDanger)[] triples) {
        this.levelId = levelId;
        this.levelName = levelName;
        AddWave(triples);
    }

    public void AddWave(params (int TurnNum, int MinDanger, int MaxDanger)[] triples) {
        foreach(var triple in triples) {
            roundDangerLevels.Add(triple.TurnNum,new WaveConfig(triple.MinDanger,triple.MaxDanger));
        }
    }

    public void AddEnemies(params (string Id,int Danger)[] enemyIds) {
        foreach(var enemyId in enemyIds) {
            Enemy enemy = Enemies.EnemyPrototypes.GetByKey1(enemyId.Id);
            enemies.Add(enemies.Count,new EnemyDangerPairs(enemy,enemyId.Danger));
        }
    }

    public int GetMinDangerLevel() {
        int result = 999;
        if(enemies.Count == 0) UnityEngine.Debug.LogError("enemies.Count == 0");
        foreach(var e in enemies.Values) {
            if(e.dangerLevel < result) {
                result = e.dangerLevel;
            }
        }
        return result;
    }

    public void AddLevelInfo(LevelInfo levelInfo) {
        this.levelName = levelInfo.levelName;
        this.passiveEffectDescription = levelInfo.passiveEffectDescription;
        foreach(var description in levelInfo.missonsDescription) {
            this.roundMissons.Add(roundMissons.Count,description);
        }
    }

    public virtual Level Clone()
    {
        //这里是浅拷贝，但是应该没什么问题，因为不会修改Level里的内容
        Level clone = (Level)this.MemberwiseClone();
        return clone;
    }
}

/// <summary>
/// 关卡出怪配置
/// </summary>
public class WaveConfig
{
    /// <summary>
    /// 最小危险等级
    /// </summary>
    public int MinDangerLevel { get; set; }
    
    /// <summary>
    /// 最大危险等级
    /// </summary>
    public int MaxDangerLevel { get; set; }

    public WaveConfig(int MinD,int MaxD) {
        this.MinDangerLevel = MinD;
        this.MaxDangerLevel = MaxD;
    }
}

public class EnemyDangerPairs {
    public Enemy enemy;
    public int dangerLevel;
    public EnemyDangerPairs(Enemy enemy,int danger) {
        this.enemy = enemy;
        this.dangerLevel = danger;
    }
}