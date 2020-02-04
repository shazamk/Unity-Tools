using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A unity event wrapped in a UIEvent
/// </summary>

public class UIEventTimed : UIEvent
{
    public float length;
    private float counter;
    public string name;//used for debug


    protected override void Begin()
    {
        counter = 0;
        Debug.Log("Timed event"+ name);
      
    }

    protected override void UpdateEvent()
    {
        counter += Time.deltaTime;
        if (counter >= length) {
            EndEvent();
        }
       
    }

    public override void DoReset()
    {
        counter = 0;
    }
}
