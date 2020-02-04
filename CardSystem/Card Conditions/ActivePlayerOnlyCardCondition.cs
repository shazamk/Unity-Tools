using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ActivePlayerOnlyCardCondition", menuName = "ActivePlayerOnlyCardCondition")]
public class ActivePlayerOnlyCardCondition : BaseCardCondition
{
    public override bool CheckCondition(int diceValue, Player cardOwner)
    {
        return (cardOwner == TurnManager.instance.GetActivePlayer());
    }
}
