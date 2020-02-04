using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventMoveCamera : UIEvent
{
    public Transform startMarker;
    public Transform endMarker;

    // Movement speed in units per second.
    public float speed = 5.0F;

    public float MinimumDistanceToTrigger = 0.1f;

    // Start is called before the first frame update
    protected override void Begin()
    {
        startMarker = Camera.main.transform;
    }

    // Update is called once per frame
    protected override void UpdateEvent()
    {
        // Set our position as a fraction of the distance between the markers.
        Camera.main.transform.position = Vector3.Lerp(startMarker.localPosition, endMarker.transform.position, speed * Time.deltaTime);
        Camera.main.transform.rotation = Quaternion.Lerp(startMarker.rotation, endMarker.rotation, speed * Time.deltaTime);
        if (Vector3.Distance(Camera.main.transform.position, endMarker.transform.position) < MinimumDistanceToTrigger)
            EndEvent();
    }

    public override void DoReset()
    {
        startMarker = null;
        endMarker = null;
    }
}
