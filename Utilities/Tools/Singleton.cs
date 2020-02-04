using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton pattern.
/// By Khalil Shazam. Based on Singleton.cs by Unity.
/// 07/09/2019
/// </summary>

public class Singleton <T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _Instance;

    public static T Instance {
        get {
             _Instance = (T)FindObjectOfType(typeof(T));
            if (_Instance == null) {

                GameObject singletonObject = new GameObject();
                _Instance = singletonObject.AddComponent<T>();

            }

            return _Instance;
        }
    } 
}
