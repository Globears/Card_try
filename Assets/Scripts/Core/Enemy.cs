using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人基类
/// </summary>
public class Enemy
{
    public String Id;

    /// <summary>
    /// 危险等级，用于随机出怪
    /// </summary>
    public int dangerLevel = 0;

    //索引表示轮次
    public List<String> attackSequences = new List<String>();
    //每个轮次的攻击用字符串可以表示为
    //"1:2589"  "2:3698"  "1:145+2:69"  冒号前的数字表示攻击力度，冒号后的数字表示攻击目标
    //加号用来连接两段攻击，这样可以实现同一轮次的攻击中有力度的变化
    

    public Enemy(String id, int dangerLevel)
    {
        this.Id = id;
        this.dangerLevel = dangerLevel;
    }

    public Enemy Clone(){
        return new Enemy(this.Id, this.dangerLevel)
        {
            attackSequences = new List<string>(this.attackSequences)
        };
    }

    public int GetRounds()
    {
        return attackSequences.Count;
    }

    public void Attack(int round)
    {
        if (attackSequences == null || attackSequences.Count == 0)
        {
            return;
        }

        string seq = null;

        seq = attackSequences[round];
        

        if (string.IsNullOrEmpty(seq))
        {
            return;
        }

        // 攻击序列可能包含用+连接的多段，例如 "1:145+2:69"
        string[] parts = seq.Split('+');
        foreach (string part in parts)
        {
            if (string.IsNullOrWhiteSpace(part)) continue;
            string[] pieces = part.Split(':');
            if (pieces.Length != 2) continue;

            int power = 0;
            if (!int.TryParse(pieces[0], out power)) continue;

            string targets = pieces[1];
            foreach (char c in targets)
            {
                if (!char.IsDigit(c)) continue;
                int idx = (int)char.GetNumericValue(c);
                try
                {
                    Node node = GridManager.Instance.GetNodeByIndex(idx);
                    if (node != null)
                    {
                        Debug.Log("Enemy attacking node at index " + idx);
                        node.takeDamage(power);
                        if (!node.isDefeated())
                        {
                            //break;
                        }
                    }
                }
                catch
                {
                    // ignore invalid indices
                }
            }
        }
    }
}
