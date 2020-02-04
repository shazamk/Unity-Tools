using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
//An Object that receives input from MasterInput
/// By Khalil Shazam
/// 07/09/2019
/// </summary>

public abstract class BaseInputReceiver : MonoBehaviour
{
    /*--------------------------------------------------------------------------------------
                                           VARIABLES    
    --------------------------------------------------------------------------------------*/

    /// <summary>
    /// If this object is in focus.
    /// </summary>
    protected bool _isInFocus = false;

    /// <summary>
    /// A list of the names of the key name inputs and actions this receiver will receiver.
    /// </summary>
    public List<NameEventPair> KeyNamesAndActionsToLoad;

    /// <summary>
    /// A list of the names of the axis name inputs and actions this receiver will receiver.
    /// </summary>
    public List<NameFloatEventPair> AxisNamesAndActionsToLoad;


    /// <summary>
    /// A dictionary of events linked to keynames
    /// </summary>
    protected Dictionary<string, UnityEvent> _KeyNamesAndEvents = new Dictionary<string, UnityEvent>();

    /// <summary>
    /// A dictionary of float arguement events linked to axis names
    /// </summary>
    protected Dictionary<string, FloatArgUnityEvent> _AxisNamesAndEvents = new Dictionary<string, FloatArgUnityEvent>();


    /*--------------------------------------------------------------------------------------
                                       FUNCTIONS/METHODS    
    --------------------------------------------------------------------------------------*/

    public Dictionary<string, UnityEvent> KeyNamesAndEvents {
        get { return _KeyNamesAndEvents; }
    }

    /// <summary>
    /// Returns whether this object is in focus.
    /// </summary>
    public bool IsInFocus
    {
        get { return _isInFocus; }
        // set { _isInFocus = value;}
    }

    /// <summary>
    /// Handles key inputs
    /// </summary>
    /// <param name="pKeyName">A String associated with a keycode.</param>
    public abstract void Execute(string pKeyName);

    /// <summary>
    /// Handles Axis inputs
    /// </summary>
    /// <param name="pKeyName"></param>
    /// <param name="pAxisValue"></param>
    public abstract void Execute(string pKeyName, float pAxisValue);

    /// <summary>
    /// What happens when this is in focus.
    /// </summary>
    public virtual void OnFocusEnter() { }

    /// <summary>
    /// What happens when this is leaves focus.
    /// </summary>
    public virtual void OnFocusExit() { }

    /// <summary>
    /// Set the focus of this object
    /// </summary>
    /// <param name="pState"> True for focus, false for removing focus</param>
    public void SetIsFocus(bool pState) {

        _isInFocus = pState;

        if (_isInFocus) OnFocusEnter(); else OnFocusExit();

    }

    public void RequestFocus() {

        if (!IsInFocus) {
            FocusManager.Instance.Push(this);
        }

    }
    public void PopFocus()
    {

        if (IsInFocus)
        {
            FocusManager.Instance.Pop(this);
        }

    }



    void Start() {
        //Loads inputs dictionary
        foreach (NameEventPair pair in KeyNamesAndActionsToLoad)
        {
            _KeyNamesAndEvents.Add(pair.Name, pair.Event);

        }
    }



 
}
