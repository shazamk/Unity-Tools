using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CardAbilityGiveMoney", menuName = "CardAbilityGiveMoney")]
public class CardAbilityGiveMoney : BaseCardAbility
{
    public int moneyToGive;
    public CardClass multiplierClass;

    public override void ActivateAbility(int diceValue, Player cardOwner)
    {
        int multiplierCount = 1;

        //TODO: For each card in hand with multiplierClass, increment multiplierCount
        cardOwner.AddToScore(moneyToGive * multiplierCount);
    }
}
