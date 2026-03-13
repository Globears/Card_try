
/// <summary>
/// 认知卡的基类
/// 认知卡不会加入牌库，而是更类似组建卡组时就启用的被动效果
/// </summary>
public class CogCard {
    /// <summary>
    /// 认知卡的Id
    /// </summary>
    public int ID;
    /// <summary>
    /// 认知卡的名字
    /// </summary>
    public string Name;
    /// <summary>
    /// 消耗的认知等级
    /// </summary>
    public int CogLevel;
    /// <summary>
    /// 认知卡的效果描述
    /// </summary>
    public string Description;
}