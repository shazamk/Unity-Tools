using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// By Khalil Shazam
/// 07/09/2019
/// </summary>
public class KeyInputMapper : InputMapper<string,List<KeyCode>>
{
    /*--------------------------------------------------------------------------------------
                                           VARIABLES    
    --------------------------------------------------------------------------------------*/

    /// <summary>
    /// Input list from inspector.
    /// </summary>
    public List<NameKeycodePair> InputsToLoad = new List<NameKeycodePair>();

    /*--------------------------------------------------------------------------------------
                                     FUNCTIONS/METHODS    
    --------------------------------------------------------------------------------------*/

    private void Start()
    {
        //Loads inputs dictionary
        HashSet<string> tempHashNames = new HashSet<string>();
        

        foreach (NameKeycodePair pair in InputsToLoad)
        {
            
                tempHashNames.Add(pair.Name);
        }
        foreach (string name in tempHashNames)
        {
            Inputs.Add(name,new List<KeyCode>());
            foreach (NameKeycodePair pair in InputsToLoad)
            {
                if (pair.Name == name)
                {
                    (Inputs[name]).Add(pair.KeyCode);
                }
            }

        }


      
    }

    public enum ListOfInputs{




    }


}


