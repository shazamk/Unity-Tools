using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIEventRollDice : UIEvent
{
    protected override void Begin()
    {
        int playerNumberOfDice = TurnManager.instance.GetActivePlayer().DiceCount;
        Dice.Instance.OnDiceRollCompleted.AddListener(DiceRollCompleted);
        Dice.Instance.Roll(playerNumberOfDice);
    }

    protected override void UpdateEvent()
    {
        //No Update
    }

    public void DiceRollCompleted()
    {
        EndEvent();
    }

    public override void DoReset()
    {
        //No additional reset
    }
}
