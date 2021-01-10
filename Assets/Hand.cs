using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    public const int SIZE = 10;
    public static GameObject[] Hands = new GameObject[SIZE];
    public static Card[] Cards = new Card[SIZE];
    public static bool[] occupied = new bool[SIZE];
    public static int selected = SIZE;

    private void Start()
    {
        for (int i = 0; i < SIZE; i++)
        {
            Hands[i] = GameObject.Find("Hand (" + i + ")");
        }
    }

    public void AddCard(Card card)
    {
        int handSpace = GetHandSpace();
        if (handSpace < SIZE)
        {
            Cards[handSpace] = card;
            occupied[handSpace] = true;
            card.DisplayCard(Hands[handSpace], card);
        }
    }

    public void RemoveCard(int i)
    {
        if (occupied[i])
        {
            occupied[i] = false;
            Cards[i].DisplayNull(Hands[i]);
            Cards[i] = null;
        }
    }

    private int GetHandSpace()
    {
        for (int i = 0; i < SIZE; i++)
        {
            if (!occupied[i])
                return i;
        }
        return SIZE;
    }

    private void SelectCard(int i)
    {
        selected = i;
        Hands[i].GetComponentInChildren<Outline>().enabled = true;
    }

    private void DeselectCard(int i)
    {
        if (i < SIZE)
        {
            Hands[i].GetComponentInChildren<Outline>().enabled = false;
            selected = SIZE;
        }
    }

    public void HandClicked(int i)
    {
        if (selected == i)
        {
            DeselectCard(i);
        }
        else
        {
            DeselectCard(selected);
            SelectCard(i);
        }
    }
}