using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NonActivePlayerCardCondition", menuName = "NonActivePlayerCardCondition")]
public class NonActivePlayerCardCondition : BaseCardCondition
{
    public override bool CheckCondition(int diceValue, Player cardOwner)
    {
        return (cardOwner != TurnManager.instance.GetActivePlayer());
    }
}
