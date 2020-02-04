using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventMoveToTarget : UIEvent

{
    public Transform GameObjectToMove;
    public Transform targetTransform;
    public float Speed;
    public float MinimumDistanceToTrigger= 0.1f;

    protected override void Begin()
    {
        
    }

    protected override void UpdateEvent()
    {
        GameObjectToMove.position = Vector3.MoveTowards(GameObjectToMove.position, targetTransform.position, Speed * Time.deltaTime);

        //if (transform.position == targetTransform.position)
        //{
        //    EndEvent();
        //}
        if ( Vector3.Distance(  GameObjectToMove.position,targetTransform.position) < MinimumDistanceToTrigger)
        {
            EndEvent();
        }

    }

    public override void DoReset()
    {
        GameObjectToMove = null;
        targetTransform = null;
        Speed = 0;
    }
}
