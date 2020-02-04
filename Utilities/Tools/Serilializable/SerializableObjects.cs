using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// These are some useful serializable classes
/// </summary>
[System.Serializable]
public class NameEventPair
{
    public string Name;
    public UnityEvent Event;
}

[System.Serializable]
public class NameFloatEventPair
{
    public string Name;
    public FloatArgUnityEvent Event;
}

[System.Serializable]
public class NameKeycodePair
{
    public string Name;
    public KeyCode KeyCode;
}

[System.Serializable]
public class StringPair
{
    public string stringA;
    public string stringB;
}

[System.Serializable]
public class FloatArgUnityEvent : UnityEvent<float>
{
}
