using UnityEngine;

/// <summary>
/// 单例 Behaviour
/// 注意：该基类未在Awake定义DontDestroyOnLoad
/// </summary>
public abstract class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
{
    public static T Instance { get; private set; }

    public static bool TryGetInstance(out T instance)
    {
        instance = Instance;
        return instance != null;
    }

    protected virtual void Awake()
    {
        if (Instance == this) return;
        if (Instance != null) {
            Debug.Log($"[{GetType().Name}] Instance already exists");
            Destroy(gameObject);
            return;
        }

        Instance = (T)this;
    }

    protected virtual void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}