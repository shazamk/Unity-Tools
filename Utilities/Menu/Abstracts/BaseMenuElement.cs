using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
//An Object that can be added to a Menu.
/// By Khalil Shazam
/// 07/09/2019
/// </summary>
public abstract class BaseMenuElement : MonoBehaviour
{
   public bool _IsActive =true;
   public bool GetIsActive {
        get {
            return _IsActive;
        }
    }
    public bool _IsSelected = false;


   public abstract void Trigger();
   public abstract void Select();
   public abstract void Deselect();
   
   public virtual void  SetElementActive(bool pIsActive) {
        _IsActive = pIsActive;

    }
   


}
