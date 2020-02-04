using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class that handles sending input an BaseInputReceiver. 
/// By Khalil Shazam
/// 07/09/2019
/// </summary>
public class FocusManager : Singleton<FocusManager>
{
    /*--------------------------------------------------------------------------------------
                                           VARIABLES    
    --------------------------------------------------------------------------------------*/
    /// <summary>
    /// What value the axis should be over to be considered a value input.
    /// </summary>
    public float AxisThreshold = 0.2f;



    /// <summary>
    /// Dictionary of keycodes and Key names.
    /// </summary>
    private Dictionary<string, List<KeyCode>> keyInputs;
   
    //private Map<string, KeyCode> keyInputs;

    /// <summary>
    /// Dictionary of axis and axis names.
    /// </summary>
   // private Dictionary<string, string> axisInputs;

    /// <summary>
    /// List of input receivers.
    /// </summary>
    private List<BaseInputReceiver> receiverList = new List<BaseInputReceiver>();

    /// <summary>
    /// The current input receiver in focus.
    /// </summary>
    public BaseInputReceiver receiverInFocus;

    /// <summary>
    /// Reference to KeyInputMapper
    /// </summary>

   public KeyInputMapper Key_InputMapper;

    /// <summary>
    /// Reference Player 1 inputs
    /// </summary>

    public List<KeyInputMapper> Key_InputMapperPlayers;
  



    /// <summary>
    /// Reference to KeyInputMapper
    /// </summary>

    // public AxisInputMapper Axis_InputMapper; 

    /*--------------------------------------------------------------------------------------
                                     FUNCTIONS/METHODS    
    --------------------------------------------------------------------------------------*/

    private void Start()
    {
        //Loads inputs dictionary
        if (Key_InputMapper != null)
        {
            keyInputs = Key_InputMapper.Inputs;
        }
        else {
            Debug.Log("No KeyInputMapper hooked up to FocusManager.  ");
        }

       
        if (receiverInFocus != null) {
            receiverList.Add(receiverInFocus);
        }


    }



    /// <summary>
    /// pReceiver gains focus and previous focus object goes on a stack.
    /// </summary>
    /// <param name="pReceiver"></param>
    public void Push(BaseInputReceiver pReceiver)
    {


        receiverInFocus.SetIsFocus(false);
        pReceiver.SetIsFocus(true);
        receiverInFocus = pReceiver;

        receiverList.Add(receiverInFocus);


    }
    /// <summary>
    /// Current focus object is removed and the new current focus object is 
    /// </summary>
    public void Pop(BaseInputReceiver pReceiver)
    //public void Pop()
    {
        int lastIndex = receiverList.Count - 1;

        if (!(receiverList[lastIndex] == pReceiver)) {

            return;
        }
        Pop();
      

    }
    public void Pop() {

        int lastIndex = receiverList.Count - 1;
       
        //Remove from list
        receiverInFocus.SetIsFocus(false);
        receiverList.RemoveAt(lastIndex);

        //Set last receiver in list as current. If the list is now empty then the receiverInFocus becomes null.
        if (receiverList.Count > lastIndex - 1)
        {
            receiverInFocus = receiverList[lastIndex - 1];
            receiverInFocus.SetIsFocus(true);
        }
        else
        {
            receiverInFocus = null;

        }

    }


    void Update()
    {

        if (receiverInFocus != null)
        {

            //Checks to see if a keycode that is relevant to receiverInFocus is being held down
            foreach (string name in receiverInFocus.KeyNamesAndEvents.Keys)
            {

                //Checks key inputs for debu
                if (keyInputs.ContainsKey(name))
                {
                    foreach (KeyCode key in keyInputs[name]) {
                        KeyCode keyCode = key;
                 
                        if (Input.GetKeyDown(keyCode))
                        {
                            receiverInFocus.Execute(name);
                        }
                    }
                   
                }

                //This is a hack. This file shouldnt know about the turn manager

                int activePlayerIndex = TurnManager.instance.GetActivePlayerIndex();

                //Checks key inputs for debu

                if (Key_InputMapperPlayers.Count > activePlayerIndex)
                {
                    Dictionary<string, List<KeyCode>> activePlayerKeys =
                     Key_InputMapperPlayers[activePlayerIndex].Inputs;

                    if (activePlayerKeys.ContainsKey(name))
                    {
                        foreach (KeyCode key in activePlayerKeys[name])
                        {
                            KeyCode keyCode = key;

                            if (Input.GetKeyDown(keyCode))
                            {
                                receiverInFocus.Execute(name);
                            }
                        }
                    }
                }


                //Checks axis inputs for active player
                //if (axisInputs.ContainsKey(name))
                //{
                //    string axis = axisInputs[name];
                //    float axisValue = Input.GetAxis(axis);
                //    if (axisValue > AxisThreshold)
                //    {
                //        receiverInFocus.Execute(name, axisValue);

                //    }

                //}
            }

        }


    }


}


