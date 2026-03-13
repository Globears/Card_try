public class MultiKeyDictionary<TKey1, TKey2, TValue>
{
    private System.Collections.Generic.Dictionary<TKey1, TValue> dict1 = new();
    private System.Collections.Generic.Dictionary<TKey2, TKey1> keyMapping = new();
    
    public void Add(TKey1 key1, TKey2 key2, TValue value)
    {
        dict1[key1] = value;
        keyMapping[key2] = key1;
    }
    
    public TValue GetByKey1(TKey1 key) => dict1[key];
    
    public TValue GetByKey2(TKey2 key) => dict1[keyMapping[key]];
}