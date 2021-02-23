using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bf : MonoBehaviour
{
    public const int SIZE = 30;
    public static GameObject[] Bfs = new GameObject[SIZE];
    public static Card[] Cards = new Card[SIZE];
    public static bool[] occupied = new bool[SIZE];
    public static bool[] actionUsed = new bool[SIZE];
    public static int selected = SIZE;

    public enum Column
    {
        Back, Middle, Front, Wall, MiddleRow, Random
    }
    private void Start()
    {
        for (int i = 0; i < SIZE; i++)
        {
            Bfs[i] = GameObject.Find("Bf (" + i + ")");
        }
    }

    public void AddCardFromHand(Card card, int from, int to)
    {
        AnimaCard animaCard = new AnimaCard();
        animaCard.MoveHandBf(card, from, to);
    }

    public void RemoveCard(int i)
    {
        if (occupied[i])
        {
            occupied[i] = false;
            Cards[i].DisplayNull(Bfs[i]);
            Cards[i] = null;
        }
    }

    public void MarkPlayable()
    {
        if (Game.level == -2)
        {
            for (int i = 6; i < 9; i++)
                if (!occupied[i])
                    Bfs[i].GetComponentInChildren<Outline>().enabled = true;
        }
        else if (Game.level == -1)
        {
            for (int i = 0; i < 3; i++)
                if (!occupied[i])
                    Bfs[i].GetComponentInChildren<Outline>().enabled = true;
        }
        else if (Game.level == 0)
        {
            for (int i = 3; i < 6; i++)
                if (!occupied[i])
                    Bfs[i].GetComponentInChildren<Outline>().enabled = true;
        }
        else
        {
            for (int i = 0; i < 9; i++)
            {
                if (!occupied[i])
                {
                    Bfs[i].GetComponentInChildren<Outline>().enabled = true;
                }
            }
        }
    }

    public void UnmarkPlayable()
    {
        for (int i = 0; i < 30; i++)
        {
            Bfs[i].GetComponentInChildren<Outline>().enabled = false;
        }
    }

    public void BfClicked(int i)
    {
        selected = i;
        
        if (Bfs[i].GetComponentInChildren<Outline>().enabled == true)
        {
            AddCardFromHand(Hand.Cards[Hand.selected], Hand.selected, selected);

            Hand hand = new Hand();
            hand.RemoveCard(Hand.selected);
            hand.DeselectCard();
            UnmarkPlayable();
        }
    }
}
