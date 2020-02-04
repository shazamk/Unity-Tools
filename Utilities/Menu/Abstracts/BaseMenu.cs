using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A Class to build a menu out of menu elements.
/// By Khalil Shazam
/// 07/09/2019
/// </summary>
public abstract class BaseMenu : MonoBehaviour
{

    /*--------------------------------------------------------------------------------------
                                          VARIABLES    
   --------------------------------------------------------------------------------------*/
    /// <summary>
    /// List of menu elements.
    /// </summary>
    public List<BaseMenuElement> MenuElements = new List<BaseMenuElement>();

    /// <summary>
    /// The index of the currently selected menu element.
    /// </summary>
    protected int currentIndex = 0;
    protected int prevIndex = 0;

    public UnityEvent OnOpen;
    public UnityEvent OnStart;
    public UnityEvent OnClose;


    /*--------------------------------------------------------------------------------------
                                       FUNCTIONS/METHODS    
    --------------------------------------------------------------------------------------*/

    /// <summary>
    /// Arrange the elment's gameobjects in some way
    /// </summary>
    protected abstract void ArrangeMenuElements();

    protected virtual void Start()
    {
        Init();
    }
    public void Init()
    {
        DeselectAll();
        OnStart?.Invoke();
        currentIndex = 0;
        if (MenuElements.Count > 0)
        {
            SelectAnElement(currentIndex);
        }
        ArrangeMenuElements();

    }

    #region Selection Related
    /// <summary>
    /// Selects the first Active element.
    /// </summary>
    public void SelectFirstActiveIndex()
    {
        DeselectAll();
        for (int i = 0; i < MenuElements.Count; i++)
        {
            if (MenuElements[i].GetIsActive)
            {
                currentIndex = i;
                SelectAnElement(i);
                break;
            }
        }
    }

    /// <summary>
    /// Selects element at pIndex
    /// </summary>
    /// <param name="pIndex"></param>
    protected virtual void SelectAnElement(int pIndex)
    {
        //if list is empty
        if (pIndex > MenuElements.Count - 1) return;
        MenuElements[prevIndex].Deselect();
        MenuElements[pIndex].Select();

    }

    /// <summary>
    /// Selects the next element. Public call
    /// </summary>
    public virtual void SelectNextElement()
    {
        prevIndex = currentIndex;
        _SelectNextElement();
    }
    /// <summary>
    /// Calls OnSelect on next menu elment.
    /// </summary>
    protected virtual void _SelectNextElement()
    {
        int maxIndex = MenuElements.Count - 1;

        //if list is empty
        if (maxIndex < 0) return;

        currentIndex++;
        currentIndex = (currentIndex > maxIndex) ? _HandleExceededIndex(currentIndex) : currentIndex;
        if (currentIndex < 0) return;//
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

    /// <summary>
    /// Selects previous element.
    /// </summary>
    public virtual void SelectPreviousElement()
    {
        prevIndex = currentIndex;
        _SelectPreviousElement();
    }

    /// <summary>
    /// Calls OnSelect on previous menu elment.
    /// </summary>
    protected virtual void _SelectPreviousElement()
    {
        int maxIndex = MenuElements.Count - 1;

        //if list is empty
        if (maxIndex < 0) return;

        currentIndex--;
        currentIndex = (currentIndex < 0) ? _HandleExceededIndex(currentIndex) : currentIndex;

        if (MenuElements[currentIndex].GetIsActive)
        {
            SelectAnElement(currentIndex);
        }
        else
        {
            if (!AreAllElementsDeactive())
            {
                _SelectPreviousElement();
            }

        }

    }

    /// <summary>
    /// Deselects All elements.
    /// </summary>
    public void DeselectAll()
    {
        foreach (BaseMenuElement ele in MenuElements)
        {
            ele.Deselect();

        }
        currentIndex = 0;

    }
    #endregion



    /// <summary>
    /// Triggers the currently selected menu elment
    /// </summary>
    public virtual void TriggerCurrentElement()
    {
        MenuElements[currentIndex].Trigger();
    }

    /// <summary>
    /// Triggers a menu element
    /// </summary>
    /// <param name="pIndex"> The menu element index.</param>
    public virtual void TriggerAnElement(int pIndex)
    {
        if (pIndex > 0 && pIndex < MenuElements.Count - 1)
        {
            MenuElements[pIndex].Trigger();
        }
    }

    /// <summary>
    /// Calls an event on close
    /// </summary>
    public virtual void Close()
    {
        DeselectAll();
        OnClose?.Invoke();

    }


    /// <summary>
    ///  Calls an event on open
    /// </summary>
    public virtual void Open()
    {
        OnOpen?.Invoke();
    }

    /// <summary>
    ///  Deselect Menu
    /// </summary>
    public virtual void Deselect()
    {
        foreach (BaseMenuElement element in MenuElements)
        {
            element.Deselect();
        }
    }

    /// <summary>
    /// Adds an element to the elment list.
    /// </summary>
    public virtual void AddElement(BaseMenuElement element)
    {
        MenuElements.Add(element);
        ArrangeMenuElements();
    }

    public virtual void RemoveElement(BaseMenuElement element)
    {
        MenuElements.Remove(element);
        //DeselectAll();
        //  SelectFirstActiveIndex();
        ArrangeMenuElements();

    }


    protected bool AreAllElementsDeactive()
    {

        foreach (BaseMenuElement ele in MenuElements)
        {
            if (ele.GetIsActive)
            {
                return false;
            }
        }
        return true;
    }
    /// <summary>
    /// Return a negative value if you want to exit.
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    protected virtual int _HandleExceededIndex(int i) {

        int maxIndex = MenuElements.Count - 1;

        if (i > maxIndex)
        {
            return 0;
        }
        else
            return maxIndex;
    }

}
