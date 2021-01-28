using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn : MonoBehaviour
{
    public static Card.Alignment turn = Card.Alignment.Ally;

    public void EndTurn()
    {
        UnitAction unitAction = new UnitAction();
        unitAction.TakeAction(turn);

        if (turn == Card.Alignment.Ally)
        {
            turn = Card.Alignment.Enemy;
        }
        else
        {
            turn = Card.Alignment.Ally;
        }
    }
}
