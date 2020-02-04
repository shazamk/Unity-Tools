using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuButton : BaseMenuElement
{
    public UnityEvent TriggerEvent;
    public UnityEvent SelectEvent;
    public UnityEvent DeselectEvent;
    public Image ButtonImage;
  

    public Color HighLightColor;
    public Color DeactiveColor;
    private Color defaultColor =Color.white;

    public override void SetElementActive(bool pIsActive) {
        base.SetElementActive(pIsActive);

        if (_IsActive) {
            ButtonImage.color = (base._IsSelected) ? ButtonImage.color : defaultColor;

        }
        else if(!_IsActive)
        {
            ButtonImage.color = DeactiveColor;

        }
    }

    void Start() {
        if (ButtonImage!= null) {
            defaultColor = ButtonImage.color;
        }
       

    }
    void OnMouseDown()
    {
       Debug.Log("clickeed");
    }

    void OnMouseEnter()
    {
        Debug.Log("Over");
    }

    void OnMouseExit()
    {
        Debug.Log("Exit");
    }

    public override void Select()
    {
        _IsSelected = true;
        ButtonImage.color = HighLightColor;
        SelectEvent?.Invoke();
    }

    public override void Trigger()
    {
        if (GetIsActive)
        {
            TriggerEvent?.Invoke();
        }
    }

    public override void Deselect()
    {
        _IsSelected = false;
        
        DeselectEvent?.Invoke();
       
        ButtonImage.color = (base._IsActive)?defaultColor:DeactiveColor;
    }
}
