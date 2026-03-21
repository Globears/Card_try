using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Defense
{
    public Defense(Act owner, MindPhase.Prefix prefix, MindPhase.Suffix suffix)
    {
        this.owner = owner;
        this.Prefix.Add(prefix);
        this.Suffix.Add(suffix);
    }
    
    public int Power = 0;   //防守的力度

    public Act owner;   // 防守来自哪个动作

    //心相
    public List<MindPhase.Prefix> Prefix;
    public List<MindPhase.Suffix> Suffix;

    
    public Vector2Int Position; //设防位置
}

public class DefenseSequence
{
    public List<Defense> Sequence = new List<Defense>();

    public Defense Begin
    {
        get
        {
            if (Sequence.Count > 0)
            {
                return Sequence[0];
            }
            return null;
        }
    }

    public void Apply()
    {
        foreach(Defense def in Sequence)
            {
                Beacon.Instance.MoveTo(def.Position);
                Node node = GridManager.Instance.GetNodeAt(def.Position);
                node.ApplyDefense(def);
            }
    }

    public bool IsDefenseSequenceContainPosition(Vector2Int vector2Int) {
        foreach(Defense def in Sequence) {
            if(def.Position == vector2Int) return true;
        }
        return false;
    }

    /// <summary>
    /// 从给定的位置 切割防御序列
    /// </summary>
    /// <param name="vector2Int">提供一个节点内的位置</param>
    /// <returns>返回被切割后的位置（含提供的位置） 如 12345 提供3 切割为345</returns>
    public DefenseSequence CutDefenseSequenceWithPosition(Vector2Int pos) {
        int idx = Sequence.FindIndex(d => d.Position == pos);
        if (idx < 0) return new DefenseSequence(new List<Defense>());
        var sub = Sequence.GetRange(idx, Sequence.Count - idx);
        return new DefenseSequence(sub);
    }

    public DefenseSequence(List<Defense> defenses) {
        this.Sequence = defenses;
    }
    public DefenseSequence() {
    }
    public static List<DefenseSequence> CreateDefenseSequences(
        string config, 
        Act owner, 
        MindPhase.Prefix prefix, 
        MindPhase.Suffix suffix
    )
    {
        // 支持的字符串格式示例：
        // "3:258" -> 一个防守序列，位置 2,5,8，力度都是 3
        // "2:687, 2:489" -> 两个防守序列
        // "2:687, 1:78-2:9" -> 两个防守序列；第二个序列中 7,8 的力度为 1，9 的力度为 2
        // 语法：序列由逗号分隔，每个序列内部可由 '-' 分隔多个 "power:positions" 段，positions 为连续的数字字符（1-9）

        var result = new List<DefenseSequence>();
        if (string.IsNullOrWhiteSpace(config)) return result;

        var sequences = config.Split(',');
        foreach (var seqRaw in sequences)
        {
            var seqTrim = seqRaw.Trim();
            if (string.IsNullOrEmpty(seqTrim)) continue;

            var defSeq = new DefenseSequence();

            // 每个序列可以包含多个 "power:positions" 段，用 '-' 分隔
            var segments = seqTrim.Split('-');
            foreach (var segRaw in segments)
            {
                var seg = segRaw.Trim();
                if (string.IsNullOrEmpty(seg)) continue;

                var colonIndex = seg.IndexOf(':');
                if (colonIndex <= 0) continue;

                var powerPart = seg.Substring(0, colonIndex).Trim();
                var posPart = seg.Substring(colonIndex + 1).Trim();

                if (!int.TryParse(powerPart, out var power)) continue;
                if (string.IsNullOrEmpty(posPart)) continue;

                foreach (var ch in posPart)
                {
                    if (char.IsWhiteSpace(ch)) continue;
                    if (ch < '1' || ch > '9') continue; // 只接受 1-9

                    var pos = NumToPosition(ch);
                    var d = new Defense(owner, prefix, suffix)
                    {
                        Power = power,
                        Position = pos
                    };
                    defSeq.Sequence.Add(d);
                }
            }

            if (defSeq.Sequence.Count > 0) result.Add(defSeq);
        }

        return result;
    }

    public static Vector2Int NumToPosition(char d)
    {
        // 布局（视觉化）：
        // 1 2 3
        // 4 5 6
        // 7 8 9
        // 5为0，0 向右 x+，向上 y+
        switch (d)
        {
            case '1': return new Vector2Int(-1, 1);
            case '2': return new Vector2Int(0, 1);
            case '3': return new Vector2Int(1, 1);
            case '4': return new Vector2Int(-1, 0);
            case '5': return new Vector2Int(0, 0);
            case '6': return new Vector2Int(1, 0);
            case '7': return new Vector2Int(-1, -1);
            case '8': return new Vector2Int(0, -1);
            case '9': return new Vector2Int(1, -1);
            default: return new Vector2Int(0, 0);
        }
    }
}
