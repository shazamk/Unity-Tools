using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisInputMapper : InputMapper<string,string>
{
    public List<StringPair> InputsToLoad = new List<StringPair>();

    private void Start()
    {
        //Loads inputs dictionary
        foreach (StringPair axisNamepair in InputsToLoad)
        {
            _Inputs.Add(axisNamepair.stringA, axisNamepair.stringB);
        }
    }
}





