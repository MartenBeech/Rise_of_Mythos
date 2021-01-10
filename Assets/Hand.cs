using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    public const int HANDSIZE = 10;
    public static GameObject[] Hands = new GameObject[HANDSIZE];
    public static Card[] Cards = new Card[HANDSIZE];
    private static bool[] occupied = new bool[HANDSIZE];

    public bool[] Occupied { get => occupied; set => occupied = value; }

    private void Start()
    {
        for (int i = 0; i < HANDSIZE; i++)
        {
            Hands[i] = GameObject.Find("Hand (" + i + ")");
        }
    }

    public void AddCard(Card card)
    {
        int handSpace = GetHandSpace();
        if (handSpace < HANDSIZE)
        {
            Cards[handSpace] = card;
            Occupied[handSpace] = true;
            card.DisplayCard(Hands[handSpace], card);
        }
    }

    public void RemoveCard(int i)
    {
        if (Occupied[i])
        {
            Occupied[i] = false;
            Cards[i].DisplayNull(Hands[i]);
            Cards[i] = null;
        }
    }

    private int GetHandSpace()
    {
        for (int i = 0; i < HANDSIZE; i++)
        {
            if (!Occupied[i])
                return i;
        }
        return HANDSIZE;
    }

    public void HandClicked(int i)
    {

    }
}