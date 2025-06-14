using UnityEngine;
using System.Collections.Generic;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{

    protected static T _instance = null;
    public static T GetInstance()
    {

        if (_instance == null)
        {
            _instance = GameObject.FindObjectOfType(typeof(T)) as T;

            if (_instance == null)
                _instance = new GameObject(typeof(T).ToString()).AddComponent<T>();

            DontDestroyOnLoad(_instance);
        }
        return _instance;
    }
}