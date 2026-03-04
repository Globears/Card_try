using UnityEngine;

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
        //这里从Enemies的注册表里随机抽取敌人
        
        int randomIndex = Random.Range(0, Enemies.AllEnemies.Count);
        Enemy newEnemy = EnemyManager.Instance.CreateEnemy(Enemies.AllEnemies[randomIndex]);
        
    }
}
