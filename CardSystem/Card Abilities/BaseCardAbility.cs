using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCardAbility : ScriptableObject
{
    public abstract void ActivateAbility(int diceValue, Player cardOwner);
}
