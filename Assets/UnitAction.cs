using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitAction : MonoBehaviour
{
    public static List<Card> units = new List<Card>();
    public static float counter;
    private static bool readyToMove, readyToAttack;


    private void Update()
    {
        if (counter > 0)
        {
            counter -= Time.deltaTime;

            if (counter <= UI.TIMER * 2.04f && readyToMove)
            {
                readyToMove = false;
                UnitMove unitMove = new UnitMove();
                unitMove.Move(units[0]);
            }

            if (counter <= UI.TIMER * 1.02f && readyToAttack)
            {
                readyToAttack = false;
                UnitAttack unitAttack = new UnitAttack();
                unitAttack.Attack(units[0]);

                units[0].attack += units[0].heroicThisTurn;
                if (Bf.occupied[units[0].tile])
                {
                    Card card = new Card();
                    card.DisplayCard(Bf.Bfs[units[0].tile], units[0]);
                }
            }

            if (counter <= 0)
            {
                units.RemoveAt(0);
                NextUnitTurn();
            }
        }
    }

    public void TakeAction(Card.Alignment alignment)
    {
        units.Clear();
        if (alignment == Card.Alignment.Ally)
        {
            for (int i = Bf.SIZE - 1; i >= 0; i--)
            {
                if (Bf.occupied[i])
                {
                    if (Bf.Cards[i].alignment == alignment)
                    {
                        units.Add(Bf.Cards[i]);
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < Bf.SIZE; i++)
            {
                if (Bf.occupied[i])
                {
                    if (Bf.Cards[i].alignment == alignment)
                    {
                        units.Add(Bf.Cards[i]);
                    }
                }
            }
        }

        NextUnitTurn();
    }

    public void NextUnitTurn()
    {
        if (units.Count > 0)
        {
            units[0].bonusAttackNextTurn = 0;
            units[0].heroicThisTurn = 0;
            readyToMove = true;
            readyToAttack = true;
            counter = UI.TIMER * 2.04f;
        }

        else
        {
            if (Turn.turn == Card.Alignment.Ally)
            {
                Turn.turn = Card.Alignment.Enemy;
            }
            else
            {
                Turn.turn = Card.Alignment.Ally;
            }
        }
    }
}
