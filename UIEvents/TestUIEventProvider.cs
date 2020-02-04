using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUIEventProvider : MonoBehaviour
{
    private UIEventPool<UIEventMoveToTarget> eventPool;
    public GameObject CubeToMove;

    // Start is called before the first frame update
    void Start()
    {
        eventPool = new UIEventPool<UIEventMoveToTarget>();
    }

    public void GetEvent(Transform target)
    {
        UIEventMoveToTarget newMoveEvent = eventPool.GetEvent(gameObject);
        newMoveEvent.GameObjectToMove = CubeToMove.transform;
        newMoveEvent.targetTransform = target;
        newMoveEvent.Speed = 1;
        UIEventManager.Instance.QueueUpUIEvent(newMoveEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
