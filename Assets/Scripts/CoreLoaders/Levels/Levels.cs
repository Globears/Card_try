using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 加载关卡数据的类
/// </summary>
public static class Levels {
    public static MultiKeyDictionary<int,string,Level> LevelsPrototypes = new MultiKeyDictionary<int,string,Level>();
    public static string LevelDescriptionPath = "LevelsInfo/LevelsInfo.json";

    public static Level GetLevelWithId(int Key) {
        return LevelsPrototypes.GetByKey1(Key).Clone();
    }
    public static Level GetLevelWithName(string Key) {
        return LevelsPrototypes.GetByKey2(Key).Clone();
    }
    public static Level level1,level2,level3,level4,level5,level6;

    public static void AddLevels(Level level) {
        LevelsPrototypes.Add(level.levelId,level.levelName,level);
    }

    public static void LoadInfosFromJson() {
        
    }
    public static void Load() {
        level1 = new Level(1,(1,4,5),(2,4,5));
        level1.AddEnemies(("M01T01",2),("M01T02",2));
        AddLevels(level1);
    }
}