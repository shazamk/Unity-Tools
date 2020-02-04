using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputReceiver : BaseInputReceiver
{

    public InputReceiver ChildReceiver;
    public override void Execute(string pKeyName)
    {
        if (_KeyNamesAndEvents.ContainsKey(pKeyName))
        {
            UnityEvent eventToExecute = _KeyNamesAndEvents[pKeyName];
            eventToExecute?.Invoke();
            ChildReceiver?.Execute(pKeyName);
        }
       
        
    }

    public override void Execute(string pKeyName, float pAxisValue)
    {
        if (_AxisNamesAndEvents.ContainsKey(pKeyName))
        {
            FloatArgUnityEvent eventToExecute = _AxisNamesAndEvents[pKeyName];
            eventToExecute?.Invoke(pAxisValue);
        }
    }


}
