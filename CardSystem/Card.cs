using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
   
    [TextArea]
    public string AbilityDescription;
    public string Cost;
    public Sprite Sprite;
    public int[] activationValues;
    public List<BaseCardCondition> cardActivationConditions;
    public List<BaseCardAbility> cardAbilities;
    public delegate void DelOnCardActivate();
    public DelOnCardActivate OnCardActivate;


    public CardClass cardClass;

    /// <summary>
    /// Activates the card, if all conditions are met
    /// </summary>
    /// <param name="diceValue">The dice value rolled this turn</param>
    /// <param name="cardOwner">The player who has the card it his owned cards list</param>
    public bool Evaluate(int diceValue, Player cardOwner)
    {
        if(CheckActivationConditions(diceValue, cardOwner))
        {
            Debug.Log("Activating Ability for " + cardOwner.Name);
            activateAbilities(diceValue, cardOwner);
            return true;
           
        }
        return false;
    }
    public void SetActivateAction() {

    }

    /// <summary>
    /// Checks whether the cards' activation conditions have been met, including activation values
    /// </summary>
    /// <param name="diceValue">The dice value rolled this turn</param>
    /// <param name="cardOwner">The player who has the card it his owned cards list</param>
    /// <returns>A bool indicating whether the checks failed or succeeded</returns>
    public bool CheckActivationConditions(int diceValue, Player cardOwner)
    {
        if (!CheckDiceValueMatchesActivationValues(diceValue))
        {
            return false;
        }
        //Check all other conditions
        foreach(BaseCardCondition condition in cardActivationConditions)
        {
            if (!condition.CheckCondition(diceValue, cardOwner))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Checks whether the cards' activation values have been met
    /// </summary>
    /// <param name="diceValue">The dice value rolled this turn</param>
    /// <returns>A bool indicating whether the checks failed or succeeded</returns>
    private bool CheckDiceValueMatchesActivationValues(int diceValue)
    {
        foreach (int activationValue in activationValues)
        {
            if (diceValue == activationValue)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Activates all abilities on the card
    /// </summary>
    /// <param name="diceValue">The dice value rolled this turn</param>
    /// <param name="cardOwner">The player who has the card it his owned cards list</param>
    protected void activateAbilities(int diceValue, Player cardOwner)
    {
        foreach(BaseCardAbility ability in cardAbilities)
        {
            ability.ActivateAbility(diceValue, cardOwner);
        }
    }

}

/// <summary>
/// The "class" of card, indicated by the icon on the card.
/// </summary>
public enum CardClass
{
    NONE,
    SHOP,
    WHEAT,
    COW,
    GEAR,
    FACTORY,
    APPLE,
    CUP,
    TRAIN_STATION,
    AMUSEMENT_PARK,
    SHOPPING_MALL,
    RADIO_TOWER
}