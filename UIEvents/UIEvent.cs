using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Used to contain logic for any UI event that can occur.
/// Used with UIEventManager.
/// </summary>
public abstract class UIEvent : MonoBehaviour
{
    /// <summary>
    /// The current state of the UIEvent
    /// </summary>
    public UIEventState CurrentState = UIEventState.NOT_STARTED;

    public UnityEvent OnBeginEvent;
    public UnityEvent OnEndEvent;

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    void Update()
    {
        if (CurrentState == UIEventState.IN_PROGRESS)
        {
            UpdateEvent();
        }
    }

    /// <summary>
    /// Start is called after object creation
    /// </summary>
    void Awake()
    {
        if(OnBeginEvent == null)
        {
            OnBeginEvent = new UnityEvent();
        }
        if(OnEndEvent == null)
        {
            OnEndEvent = new UnityEvent();
        }
    }


    /// <summary>
    /// Called to start the event. Once this function has been called, UpdateEvent()
    /// will begin to fire every frame.
    /// </summary>
    public virtual void BeginEvent()
    {
        CurrentState = UIEventState.IN_PROGRESS;
        OnBeginEvent.Invoke();
        Begin();
    }

    /// <summary>
    /// Override for a place to put initialization code. Use similar to MonoBehaviour's Start()
    /// </summary>
    protected abstract void Begin();

    /// <summary>
    /// Called every frame once event has begun. Use similar to MonoBehaviour's Update()
    /// </summary>
    protected abstract void UpdateEvent();

    /// <summary>
    /// Call to finish the event. Once called, UpdateEvent() will no longer be called
    /// </summary>
    public virtual void EndEvent()
    {
        CurrentState = UIEventState.COMPLETED;
        if (OnEndEvent != null) {
            OnEndEvent.Invoke();
        }
      
    }

    public void ResetEvent()
    {
        CurrentState = UIEventState.NOT_STARTED;
        DoReset();
    }

    public abstract void DoReset();

}