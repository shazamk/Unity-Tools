using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code Review: Dice value & card owner too limiting as parameters?
public abstract class BaseCardCondition : ScriptableObject
{
    public abstract bool CheckCondition(int diceValue, Player cardOwner);
}
