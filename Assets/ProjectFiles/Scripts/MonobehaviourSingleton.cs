using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonobehaviourSingleton<T> : MonoBehaviour where T:Component
{

    private static T instance;
    public static T Instance { get { return instance; } }
    public virtual void Awake()
    {
        if(instance==null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    
}
