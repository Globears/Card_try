
using System.Diagnostics;

public class MultiKeyDictionary<TKey1, TKey2, TValue>
{
    private System.Collections.Generic.Dictionary<TKey1, TValue> dict1 = new();
    private System.Collections.Generic.Dictionary<TKey2, TKey1> keyMapping = new();
    
    public void Add(TKey1 key1, TKey2 key2, TValue value)
    {
        dict1[key1] = value;
        keyMapping[key2] = key1;
    }
    
    public TValue GetByKey1(TKey1 key) {
        if(dict1[key] != null) return dict1[key];
        UnityEngine.Debug.LogWarning("未找到Key1: " + key);
        return default;
    }
    public TValue GetByKey2(TKey2 key) {
        if(dict1[keyMapping[key]] != null) return dict1[keyMapping[key]];
        UnityEngine.Debug.LogWarning("未找到Key2: " + key);
        return default;
    }
}