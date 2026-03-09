using System.Collections.Generic;
using UnityEngine;


public class Node
{
    // 节点具有位置、当前持有的心相及层数、以及挂载的防御
    public Vector2Int Position;

    /// <summary>
    /// 节点持有的心相及层数
    /// </summary>
    public Dictionary<MindPhase.Suffix, int> MindPhases = new Dictionary<MindPhase.Suffix, int>();
    
    /// <summary>
    /// 节点挂载的防御
    /// </summary>
    public Defense Defense;

    public int damage = 0;

    /// <summary>
    /// 初始化节点的心相状态，默认为0
    /// </summary>
    public void InitializeMindPhases()
    {
        foreach (MindPhase.Suffix suffix in System.Enum.GetValues(typeof(MindPhase.Suffix)))
        {
            MindPhases[suffix] = 0;
        }
    }

    public void ApplyDefense(Defense defense)
    {
        if(this.Defense == null)
        {
            this.Defense = defense;
            //实现坚定的特殊效果：行动时，有5x%的概率加1力度
            if (Random.Range(0, 100) < 5 * MindPhases[MindPhase.Suffix.Firmness])
            {
                this.Defense.Power += 1;
            }
        }
        else
        {
            //如果附赠和动作重合，则使它+1力
            this.Defense.Power += 1;
        }
    }

    public Node(Vector2Int position)
    {
        this.Position = position;
    }

    public Node(int x, int y)
    {
        this.Position = new Vector2Int(x, y);
    }

    public void ClearDefense()
    {
        this.Defense = null;
    }

    public void takeDamage(int damage)
    {

        if(Defense == null)
        {
            this.damage += damage;
            return;
        }

        this.Defense.Power -= damage;
        if (this.Defense.Power <= 0)
        {
            damage = -Defense.Power;
            this.Defense.Power = 0;
        }

    }

    public bool isDefeated()
    {
        if (this.Defense == null || this.Defense.Power <= 0)
        {
            return true;
        }
        return false;
    }
}