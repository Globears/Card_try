using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[System.Serializable]
public class LevelInfo {
    public int levelId;
    public string levelName;
    public string passiveEffectDescription;
    public string[] missonsDescription;
}

[System.Serializable]
public class RootLevelJsonData
{
    public LevelInfo[] levelsInfo;
}
/// <summary>
/// 加载关卡数据的类
/// </summary>
public static class Levels {
    public static MultiKeyDictionary<int,string,Level> LevelsPrototypes = new MultiKeyDictionary<int,string,Level>();
    public const string LEVELSINFOPATH = "LevelsInfo/LevelsInfo.json";

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

    public static void LoadInfosFromJson(string levelsInfoPath) {
        if (levelsInfoPath.EndsWith(".json"))
        {
            levelsInfoPath = levelsInfoPath.Replace(".json", "");
        }

        TextAsset textAsset = Resources.Load<TextAsset>(levelsInfoPath);
        if (textAsset == null)
        {
            Debug.LogError("Failed to load JSON file from Resources: " + levelsInfoPath);
            return;
        }

        string jsonString = textAsset.text;
        //加载Json
        RootLevelJsonData rootData = JsonUtility.FromJson<RootLevelJsonData>(jsonString);

        foreach (var levelInfo in rootData.levelsInfo) {
            if(LevelsPrototypes.GetByKey1(levelInfo.levelId) != null) {
                LevelsPrototypes.GetByKey1(levelInfo.levelId).AddLevelInfo(levelInfo);
                Debug.Log($"{levelInfo.levelName}的info被添加");
                continue;
            }
            Debug.LogWarning($"{levelInfo.levelName}未找到对应的加载对象");
        }

    }
    public static void Load() {
        level1 = new Level(1,"level1",(1,4,5),(2,4,5));
        level1.AddEnemies(("M01T01",2),("M01T02",2));
        AddLevels(level1);
        LoadInfosFromJson(LEVELSINFOPATH);
    }
}