using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GridManager负责管理节点（Node）的状态，包括心相和防御。
/// 它提供了接口来应用防御序列和清除防御。
/// </summary>
public class GridManager
{
    private static GridManager instance;

    public static GridManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new GridManager();
                
            }
            return instance;
        }

    }

    /// <summary>
    /// GridManager的构造函数，初始化一个3x3的节点网格，坐标范围从(-1, -1)到(1, 1)，
    /// 并初始化每个节点的心相状态。
    /// </summary>
    private GridManager()
    {
        for (int x = -1 ; x < 2 ; x++)
        {
            for (int y = -1 ; y < 2 ; y++)
            {
                nodes[new Vector2Int(x, y)] = new Node(x,y);
                nodes[new Vector2Int(x, y)].Position = new Vector2Int(x, y);

                //初始化节点的心相状态
                nodes[new Vector2Int(x, y)].InitializeMindPhases();
            }
        }
    }

    private Dictionary<Vector2Int, Node> nodes = new Dictionary<Vector2Int, Node>();

    public List<Node> Nodes => new List<Node>(nodes.Values);

    public void ApplyDefenseSequence(DefenseSequence defenseSequence, Card card)
    {
        
    }

    /// <summary>
    /// 清除所有Node上的防御
    /// </summary>
    public void ClearDefenses()
    {
        foreach (Node node in nodes.Values)
        {
            node.ClearDefense();
        }
    }

    internal Node GetNodeAt(Vector2Int vector2Int)
    {
        return nodes[vector2Int];
    }

    public Node GetNodeByIndex(int index)
    {
        //将单一的数字映射到2维的坐标，方法是按照
        //1 2 3
        //4 5 6
        //7 8 9
        int x = ((index - 1) % 3) - 1;      // -1,0,1
        int y = 1 - ((index - 1) / 3);      // 1,0,-1
        return nodes[new Vector2Int(x, y)];
    }
}
