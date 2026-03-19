using UnityEngine;
using System.Collections.Generic;
public class EnemySpawnState : TurnState
{

    public EnemySpawnState()
    {
        title = "Enemy Spawn State";
    }

    public override void Enter()
    {
        Debug.Log("Entering Enemy Spawn State");
        EnemySpawn();
    }

    public override void Exit()
    {
        
    }

    public override TurnState NextState()
    {
        PlayState playState = new PlayState();
        return playState;
    }

    public override void Update() {
        
    }

    public void EnemySpawn() {
        //这里需要随机抽取敌人
        //在剩余危险等级内的范围内随机取敌人，重复直到剩余等级小于所有可能刷的敌人的危险等级

        List<Enemy> enemiesToSpawn = new List<Enemy>();
        //拿到当前关卡
        Level level = CardGameManager.currentLevel;
        //拿到波次配置
        WaveConfig waveConfig = level.roundDangerLevels[CardGameManager.currentTurn];
        //总危险等级
        int totalDangerLevel = Random.Range(waveConfig.MinDangerLevel, waveConfig.MaxDangerLevel+1);
        //拿到敌人列表
        int remainDangerLevel = totalDangerLevel;
        //拿到序列对敌人和危险等级的字典
        Dictionary<int,EnemyDangerPairs> enemiesDict = level.enemies;
        //拿到最小危险等级
        int minDangerWithinEnemies = level.GetMinDangerLevel();
        while (remainDangerLevel >= minDangerWithinEnemies){
            //拿到所有合法的敌人
            var eligibleKeys = new List<int>();
            foreach (var kv in enemiesDict) {
                if (kv.Value.dangerLevel <= remainDangerLevel) eligibleKeys.Add(kv.Key);
            }
            //如果没有合法的敌人就break
            if (eligibleKeys.Count == 0) break;
            //在合法的敌人中选一个
            int randIndex = UnityEngine.Random.Range(0, eligibleKeys.Count);
            int chosenKey = eligibleKeys[randIndex];
            var pair = enemiesDict[chosenKey];
            //加入队列
            enemiesToSpawn.Add(pair.enemy);
            remainDangerLevel -= pair.dangerLevel;
        }
        //创建敌人
        foreach(Enemy enemy in enemiesToSpawn) {
            EnemyManager.Instance.CreateEnemy(enemy);
        }
    }
}
