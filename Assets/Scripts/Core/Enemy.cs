using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人基类
/// </summary>
public class Enemy
{
    public string Id;
    public string name;

    //索引表示轮次
    public List<string> attackSequences = new List<string>();
    //每个轮次的攻击用字符串可以表示为
    //"1:2589"  "2:3698"  "1:145+2:69"  冒号前的数字表示攻击力度，冒号后的数字表示攻击目标
    //加号用来连接两段攻击，这样可以实现同一轮次的攻击中有力度的变化
    

    public Enemy(string id,string name)
    {
        this.Id = id;
        this.name = name;
    }
    
    public Enemy(string id,string name, string attackSequences)
    {
        this.Id = id;
        this.name = name;
        this.attackSequences = new List<string> { attackSequences };
    }

    public Enemy Clone(){
        return new Enemy(this.Id,this.name)
        {
            attackSequences = new List<string>(this.attackSequences)
        };
    }

    public int GetRounds()
    {
        Debug.Log($"{name}的GetRounds()返回值是{attackSequences.Count}");
        return attackSequences.Count;
    }

    public void Attack(int round)
    {
        if (attackSequences == null || attackSequences.Count == 0)
        {
            return;
        }

        string seq = null;

        seq = attackSequences[0];
        

        if (string.IsNullOrEmpty(seq))
        {
            return;
        }

        // 攻击序列可能包含用+连接的多段，例如 "1:145+2:69"
        string[] parts = seq.Split('+');
        Debug.Log($"{name}的seq如下:{seq}");
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
                        Debug.Log($"{name}以{power}力度攻击{idx}");
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
