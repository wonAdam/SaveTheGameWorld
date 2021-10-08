using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSingletonBehaviour<T> : MonoBehaviour where T : SimpleSingletonBehaviour<T>
{
    public static T Instance;

    private void Awake()
    {
        Instance = (T)this;
    }
}
