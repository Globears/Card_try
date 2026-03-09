using System.Collections.Generic;

/// <summary>
/// 关卡的基类
/// </summary>
public class Level {
    /// <summary>
    /// 关卡编号
    /// </summary>
    public int levelNumber;
    /// <summary>
    /// 关卡包含的敌人列表
    /// </summary>
    public List<Enemy> enemies = new List<Enemy>();
    public int dangerLevel = 0;
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
}