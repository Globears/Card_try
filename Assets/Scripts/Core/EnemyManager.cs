using System.Collections.Generic;
using UnityEngine;

public class EnemyManager
{
    private static EnemyManager instance;

    public static EnemyManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new EnemyManager();
                
            }
            return instance;
        }

    }

    private EnemyManager()
    {
        
    }

    //当前已生成的敌人的列表
    public List<Enemy> enemies = new List<Enemy>();


    public Enemy CreateEnemy(Enemy enemyPrototype)
    {
        Enemy newEnemy = enemyPrototype.Clone();

        // if (!enemies.Contains(newEnemy))
        // {
        //这里应该是会重复生成的吧
        enemies.Add(newEnemy);
        // }
        
        return newEnemy;
    }

    public List<Enemy> GetEnemies()
    {
        return enemies;
    }

    public void Remove(Enemy enemy)
    {
        enemies.Remove(enemy);
    }

    public void ClearEnemies()
    {
        enemies.Clear();
    }
}
