using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static volatile T instance = null;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("MonoSingletonGameObject").AddComponent<T>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this as T;
    }
}