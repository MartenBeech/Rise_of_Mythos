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
    }

    public void NewTurn(Card.Alignment alignment)
    {
        turn = alignment;
        int iMin = 0;
        int iMax = Hand.SIZE;
        if (alignment == Card.Alignment.Enemy)
        {
            iMin = Hand.SIZE;
            iMax = Hand.SIZE * 2;
        }
        Hand hand = new Hand();

        for (int i = iMin; i < iMax; i++)
        {
            if (Hand.occupied[i])
            {
                hand.ReduceCD(i);
            }
        }

        Deck deck = new Deck();
        deck.DrawCard(turn);

        if (alignment == Card.Alignment.Enemy)
        {
            EnemyTurn enemyTurn = new EnemyTurn();
            EnemyTurn.cardRunThrough = Hand.SIZE;
            enemyTurn.PlayHand();
        }
        else
        {
            UI.EndTurn.GetComponentInChildren<Button>().enabled = true;
            UI.StartOver.GetComponentInChildren<Button>().enabled = true;
        }
            
    }

    public void EndTurnClicked()
    {
        UI.EndTurn.GetComponentInChildren<Button>().enabled = false;
        UI.StartOver.GetComponentInChildren<Button>().enabled = false;
        if (Game.level <= 0)
        {
            Tutorial tutorial = new Tutorial();
            tutorial.SetText(Game.level);
        }
        EndTurn();
    }
}