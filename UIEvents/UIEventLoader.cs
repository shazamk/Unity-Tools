using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventLoader : MonoBehaviour
{
    public List<UIEvent> UI_Events;
    public void LoadUIEvents()
    {
        foreach (UIEvent  e in UI_Events) {
            UIEventManager.Instance.QueueUpUIEvent(e);
        }
       
    }
}
