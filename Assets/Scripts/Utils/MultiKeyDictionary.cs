
using System;
using System.Diagnostics;

public class MultiKeyDictionary<TKey1, TKey2, TValue>
{
    private System.Collections.Generic.Dictionary<TKey1, TValue> dict1 = new();
    private System.Collections.Generic.Dictionary<TKey2, TKey1> keyMapping = new();
    
    public void Add(TKey1 key1, TKey2 key2, TValue value) {
        if (key1 == null) throw new ArgumentNullException(nameof(key1));
        if (key2 == null) throw new ArgumentNullException(nameof(key2));
        
        dict1[key1] = value;
        keyMapping[key2] = key1;
    }

    public TValue GetByKey1(TKey1 key) {
        try {
            if(dict1[key] != null) return dict1[key];
            UnityEngine.Debug.LogWarning("未找到Key1: " + key);
            return default;
        } catch (Exception e) {
            UnityEngine.Debug.LogError(e);
            return default;
        }
    }
    public TValue GetByKey2(TKey2 key) {
        try {
            if(dict1[keyMapping[key]] != null) return dict1[keyMapping[key]];
            UnityEngine.Debug.LogWarning("未找到Key2: " + key);
            return default;
        } catch (Exception e) {
            UnityEngine.Debug.LogError(e);
            return default;
        }
    }
}