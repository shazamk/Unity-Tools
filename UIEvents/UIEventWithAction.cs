using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A unity event wrapped in a UIEvent
/// </summary>
public class UIEventWithAction : UIEvent
{
    public UnityAction Action;

    protected override void Begin()
    {
       
        Action?.Invoke();
        EndEvent();
    }

    protected override void UpdateEvent()
    {
    }

    public override void DoReset()
    {
        //No additional reset
    }
}
