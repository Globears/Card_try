using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 负责加载所有敌人数据的静态类
/// </summary>
public static class Enemies {
    //所有敌人原型的注册表
    public static MultiKeyDictionary<string,string,Enemy> EnemyPrototypes = new MultiKeyDictionary<string,string, Enemy>();

    public static Enemy GetEnemy(string Key) {
        Enemy result;
        try {
            result = EnemyPrototypes.GetByKey1(Key);
        } catch{
            try {
                result = EnemyPrototypes.GetByKey2(Key);
            } catch {
                Debug.LogError($"{Key}未找到");
                return null;
            }
        }
        return result;
    }

    public static void AddEnemy(Enemy enemy) {
        EnemyPrototypes.Add(enemy.Id,enemy.name,enemy);
    }

    //创建敌人
    public static Enemy ArtThief1, ArtThief2, PlaygroundBandit, StaggeringBeggar, IlliterateMob1, IlliterateMob2, CafeteriaThief;
    public static Enemy LostBeggar1,LostBeggar2,LostBeggar3;

    public static void Load() {
        LoadPart0();
        LoadPart1();
    }

    public static void LoadPart0() {
        //艺术窃贼1 2 1力614
        ArtThief1 = new Enemy("M01T01","ArtThief1","1:614");
        AddEnemy(ArtThief1);
        //艺术窃贼2 2 1力354
        ArtThief2 = new Enemy("M01T02","ArtThief2","1:354");
        AddEnemy(ArtThief2);
        //操场流寇：2力2-1力789
        PlaygroundBandit = new Enemy("M02T01","PlaygroundBandit","2:2+1:789");
        AddEnemy(PlaygroundBandit);
        //蹒跚乞丐：3力：75
        StaggeringBeggar  = new Enemy("M03T01","StaggeringBeggar","3:75");
        AddEnemy(StaggeringBeggar);
    }

    public static void LoadPart1() {
        //暴动文盲1 2力：1+3力：2+4力9
        IlliterateMob1 = new Enemy("M04T01","IlliterateMob1","2:1+3:2+4:9");
        AddEnemy(IlliterateMob1);
        //暴动文盲2：2力：1+3力：8+4力5
        IlliterateMob2 = new Enemy("M04T02","IlliterateMob2","2:1+3:8+4:5");
        AddEnemy(IlliterateMob2);
        //食堂窃贼：2力：437
        CafeteriaThief = new Enemy("M05T01","CafeteriaThief","2:437");
        AddEnemy(CafeteriaThief);
        //迷途乞丐1： 3力：56
        LostBeggar1 = new Enemy("M06T01","LostBeggar1","3:56");
        AddEnemy(LostBeggar1);
        //迷途乞丐2：3力：96
        LostBeggar2 = new Enemy("M06T02","LostBeggar2","3:96");
        AddEnemy(LostBeggar2);
        //迷途乞丐3：3力：87
        LostBeggar3 = new Enemy("M06T03","LostBeggar3","3:87");
        AddEnemy(LostBeggar3);
    }
}
