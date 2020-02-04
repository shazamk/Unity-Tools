using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMenu : BaseMenu
{
    public float HorizontalSpacing = 1.36f;

    /// <summary>
    /// Arrange all menu elements vertically with VerticalSpacing spacing.
    /// </summary>
    protected override void ArrangeMenuElements()
    {
        for (int i = 0; i< MenuElements.Count; i++) {

            GameObject go = MenuElements[i].gameObject;

            go.transform.SetParent(gameObject.transform);
            Vector3 pos = new Vector3(0,0,0);
            pos.x = pos.x + HorizontalSpacing * i;
            go.transform.localPosition = pos;
            go.transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
    }

}
