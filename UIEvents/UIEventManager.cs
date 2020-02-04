using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages UIEvents. UIEvents can be added to the manager, and will be run
/// sequentially.
/// </summary>
public class UIEventManager : Singleton<UIEventManager>
{
    /// <summary>
    /// The queue of events to be run one after another
    /// </summary>
    Queue<UIEvent> eventQueue;
    /// <summary>
    /// The event currently being run.
    /// </summary>
    public UIEvent activeEvent;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        eventQueue = new Queue<UIEvent>();
    }

    /// <summary>
    /// Add a UIEvent to the event queue
    /// </summary>
    /// <param name="e"></param>
    public void QueueUpUIEvent(UIEvent e){
        eventQueue.Enqueue(e);
        Debug.Log("Q event manager");
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update(){
        if(activeEvent == null && eventQueue.Count > 0)
        {
            activeEvent = eventQueue.Dequeue();
            activeEvent?.BeginEvent();
        }

        if (activeEvent != null && activeEvent.CurrentState == UIEventState.COMPLETED) {
            activeEvent = null;
        }
	}
}
