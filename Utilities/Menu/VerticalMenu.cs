using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMenu : BaseMenu
{
    public float VerticalSpacing = 1.36f;

    /// <summary>
    /// Arrange all menu elements vertically with VerticalSpacing spacing.
    /// </summary>
    protected override void ArrangeMenuElements()
    {
        for (int i = 0; i< MenuElements.Count; i++) {

            GameObject go = MenuElements[i].gameObject;

            go.transform.parent = gameObject.transform;
            Vector3 pos = go.transform.localPosition;
            pos.y = pos.y + VerticalSpacing * i;
            go.transform.localPosition = pos;
        }
    }
}
