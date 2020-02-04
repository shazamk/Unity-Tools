using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CardAbilityTakeMoney", menuName = "CardAbilityTakeMoney")]
public class CardAbilityTakeMoney : BaseCardAbility
{
    public int moneyToTake;
    public CardClass multiplierClass;

    public override void ActivateAbility(int diceValue, Player cardOwner)
    {
        int multiplierCount = 1;

        Player diceOwner = TurnManager.instance.GetActivePlayer();

        //TODO: For each card in hand with multiplierClass, increment multiplierCount
        int moneyToGive = diceOwner.SubtractToScore(moneyToTake * multiplierCount);

        cardOwner.AddToScore(moneyToGive * multiplierCount);
    }
}
