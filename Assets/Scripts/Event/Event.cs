using System;
using UnityEngine;

public class Event<T> where T : Event<T>
{
    public static event Action<T> subscriber;

    public static void Publish(T e)
    {
        subscriber?.Invoke(e);
    }

    private bool cancled;

    public bool IsCancled()
    {
        return cancled;
    }

    public void SetCancled()
    {
        cancled = true;
    }
}
