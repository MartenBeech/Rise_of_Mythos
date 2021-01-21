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

    private void Start()
    {
        for (int i = 0; i < SIZE; i++)
        {
            Bfs[i] = GameObject.Find("Bf (" + i + ")");
        }
    }

    public void AddCard(Card card, int from, int to, Card.Alignment alignment)
    {
        Bf.occupied[to] = true;
        card.alignment = alignment;
        card.tile = to;

        AnimaCard animaCard = new AnimaCard();
        animaCard.MoveHandBf(card, from, to);
    }

    public void MarkPlayable()
    {
        for (int i = 0; i < 9; i++)
        {
            if (!occupied[i])
            {
                Bfs[i].GetComponentInChildren<Outline>().enabled = true;
            }
        }
    }

    public void UnmarkPlayable()
    {
        for (int i = 0; i < 9; i++)
        {
            Bfs[i].GetComponentInChildren<Outline>().enabled = false;
        }
    }

    public void BfClicked(int i)
    {
        selected = i;
        if (Bfs[i].GetComponentInChildren<Outline>().enabled == true)
        {
            AddCard(Hand.Cards[Hand.selected], Hand.selected, selected, Card.Alignment.Ally);

            Hand hand = new Hand();
            hand.RemoveCard(Hand.selected);
            hand.DeselectCard();
            UnmarkPlayable();
        }
    }
}
