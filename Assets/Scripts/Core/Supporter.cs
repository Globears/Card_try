
using System.Collections.Generic;


/// <summary>
/// 协助者的基类
/// </summary>
public class Supporter {
    /// <summary>
    /// 协助者的名字
    /// </summary>
    public string Name;
    /// <summary>
    /// 协助者的前缀（影响公共认知卡的范围）
    /// </summary>
    public MindPhase.Prefix Prefix;
    /// <summary>
    /// 协助者的认知等级范围
    /// </summary>
    public int CogMinLevel, CogMaxLevel;
    /// <summary>
    /// 协助者的升级任务描述
    /// </summary>
    public string upgradeMissonDescription;
    /// <summary>
    /// 协助者的独立认知卡列表
    /// </summary>
    public List<CogCard> privateCogCards = new List<CogCard>();
    /// <summary>
    /// 协助者的公共认知卡列表
    /// </summary>
    public List<CogCard> publicCogCards = new List<CogCard>();
}