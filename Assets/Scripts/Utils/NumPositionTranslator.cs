using UnityEngine;

public static class NumPositionTranslator {
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

    public static int PositionToNum(Vector2Int vector2Int) {
        int x = Mathf.Clamp(Mathf.RoundToInt(vector2Int.x), -1, 1);
        int y = Mathf.Clamp(Mathf.RoundToInt(vector2Int.y), -1, 1);
        // row = 0..2 从上到下，col = 0..2 从左到右
        int row = 1 - y;
        int col = x + 1;
        return row * 3 + col + 1;
    }
}