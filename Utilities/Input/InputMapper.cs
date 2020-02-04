using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to map some sort of input (keyboard input or axis) to a name.
/// By Khalil Shazam
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class InputMapper<T,K> : MonoBehaviour
{
    /// <summary>
    /// Input list.
    /// </summary>
    protected Dictionary<T,K> _Inputs = new Dictionary<T,K>();
    //protected List<(T, T)> _Inputs = new Dictionary<string, T>();

    public Dictionary<T, K> Inputs
    {
        get { return _Inputs; }
    }

}
