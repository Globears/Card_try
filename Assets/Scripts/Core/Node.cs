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
    public const int MAXDAMAGE = 3;

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
        else {
            //this.Defense.Power += 1;
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

    public void ClearDefense() {
        //根据defense的power和心相获得影响
        if(Defense?.Power > 0) {
            if(!Defense.Suffix.Contains(MindPhase.Suffix.NOMINDPHASE)) {
                foreach(MindPhase.Suffix suffix in Defense.Suffix) {
                    Debug.Log($"{this.Position}节点获得了{suffix}影响{Defense.Power}个");
                    this.MindPhases[suffix] += Defense.Power;
                }
            }
        }
        this.Defense = null;
    }

    public void takeDamage(int damage)
    {
        if(Defense == null)
        {
            AddDamageAndDestroy(damage);
            return;
        }

        this.Defense.Power -= damage;
        if (this.Defense.Power <= 0)
        {
            AddDamageAndDestroy(-Defense.Power);
            this.Defense.Power = 0;
        }
    }

    public void AddDamageAndDestroy(int damageDealt) {
        //责任Responsibility节点：增加“被毁”层数时，有10*x%的概率，减少一层所增加的层数
        if (damageDealt > 0 && this.MindPhases[MindPhase.Suffix.Responsibility] > 0) {
            if(Random.Range(1,101) > this.MindPhases[MindPhase.Suffix.Responsibility]*10) {
                Debug.Log("责任生效 减少1层被毁");
                damageDealt --;
            }
        }
        if (damageDealt > 0) {
        this.damage = Mathf.Min(this.damage + damageDealt, MAXDAMAGE);
        MindPhases[MindPhase.Suffix.Destoryed] = Mathf.Min(MindPhases[MindPhase.Suffix.Destoryed] + damageDealt, MAXDAMAGE);
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