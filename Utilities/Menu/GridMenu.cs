using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GridMenu : BaseMenu
{
   
    public float HorizontalSpacing = 1.36f;
    public float VerticalSpacing = 1.36f;
    public int MaximumRowsPerRow = 5;
    public UnityEvent OnIndexExceeded;


    /// <summary>
    /// Arrange all menu elements vertically with VerticalSpacing spacing.
    /// </summary>
    protected override void ArrangeMenuElements()
    {
        int row = 0;
        int column = 0;

        for (int i = 0; i < MenuElements.Count; i++)
        {
            GameObject go = MenuElements[i].gameObject;
            go.transform.SetParent(gameObject.transform);

            column = (i%MaximumRowsPerRow==0)?0:column;
            Vector3 pos = new Vector3(0, 0, 0);

            pos.x = pos.x + HorizontalSpacing * column;

            row = i / MaximumRowsPerRow;
            pos.y = (-1)*HorizontalSpacing * row;

            go.transform.localPosition = pos;
            go.transform.localScale = gameObject.transform.localScale;
            go.transform.localRotation = Quaternion.Euler(0, 0, 0);



            column++;
        }
    }
    /// <summary>
    /// Selects element up. Public call
    /// </summary>
    public virtual void SelectUp()
    {
        prevIndex = currentIndex;
        _SelectUp();
    }
    /// <summary>
    /// Calls OnSelect on up menu elment.
    /// </summary>
    protected virtual void _SelectUp()
    {
        int maxIndex = MenuElements.Count - 1;

        //if list is empty
        if (maxIndex < 0) return;

        currentIndex+= MaximumRowsPerRow;
        currentIndex = (currentIndex > maxIndex) ? 0 : currentIndex;

        if (MenuElements[currentIndex].GetIsActive)
        {
            SelectAnElement(currentIndex);
        }
        else
        {
            if (!AreAllElementsDeactive())
            {
                _SelectNextElement();
            }

        }
    }

   
}
