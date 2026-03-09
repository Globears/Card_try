using System;
using System.Collections.Generic;
using UnityEngine;

public static class Enemies
{
    //所有敌人原型的注册表
    public static Dictionary<String, Enemy> EnemyPrototypes = new Dictionary<string, Enemy>();

    public static List<Enemy> AllEnemies
    {
        get
        {
            //返回字典的值
            return new List<Enemy>(EnemyPrototypes.Values);
        }
    }

    //创建敌人
    public static Enemy Gluttony, Greed, Lazy, Lust, Arrogance, Jealous, Anger;

    public static void Load()
    {
        //暴食
        Gluttony = new Enemy("gluttony", 4)
        {
            attackSequences = new List<String> { "1:2589" }
        };
        EnemyPrototypes[Gluttony.Id] = Gluttony;

        //贪欲
        Greed = new Enemy("greed", 5)
        {
            attackSequences = new List<String> { "2:145+3:698" }
        };
        EnemyPrototypes[Greed.Id] = Greed;

        //懒惰
        Lazy = new Enemy("lazy", 3)
        {
            attackSequences = new List<String> { "1:145+2:698" }
        };
        EnemyPrototypes[Lazy.Id] = Lazy;

        //色欲
        Lust = new Enemy("lust", 7)
        {
            attackSequences = new List<String> { "1:2589+2:145+3:698" }
        };
        EnemyPrototypes[Lust.Id] = Lust;

        //傲慢
        Arrogance = new Enemy("arrogance", 6)
        {
            attackSequences = new List<String> { "1:2589+2:145+3:698" }
        };
        EnemyPrototypes[Arrogance.Id] = Arrogance;

        //嫉妒
        Jealous = new Enemy("jealous", 8)
        {
            attackSequences = new List<String> { "1:2589+2:145+3:698" }
        };
        EnemyPrototypes[Jealous.Id] = Jealous;

        //愤怒
        Anger = new Enemy("anger", 9)
        {
            attackSequences = new List<String> { "1:2589+2:145+3:698" }
        };
        EnemyPrototypes[Anger.Id] = Anger;


    }
}
