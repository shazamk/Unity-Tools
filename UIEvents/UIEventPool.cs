using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventPool<T> where T : UIEvent
{
    private List<T> eventPool;

    // Start is called before the first frame update
    public UIEventPool()
    {
        eventPool = new List<T>();
    }

    public T GetEvent(GameObject targetGameObject)
    {
        //If a state in the pool is NOT_STARTED (available for use), return that state
        foreach (T e in eventPool)
        {
            if (e.CurrentState == UIEventState.COMPLETED)
            {
                e.ResetEvent();
                return e;
            }
        }


        //Otherwise, create a new event and add it to the pool
        T newEvent = targetGameObject.AddComponent<T>();
        eventPool.Add(newEvent);
        return newEvent;
    }

}
