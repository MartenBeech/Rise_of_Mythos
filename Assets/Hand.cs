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

    public void AddCardFromDeck(Card card, int i)
    {
        int handSpace = GetHandSpace();
        if (handSpace < SIZE)
        {
            AnimaCard animaCard = new AnimaCard();
            animaCard.MoveDeckHand(card, i, handSpace);
            Cards[handSpace] = card;
            occupied[handSpace] = true;
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
        Bf bf = new Bf();
        if (Cards[i].cd == 0)
        {
            bf.MarkPlayable();
        }
        else
        {
            bf.UnmarkPlayable();
        }
    }

    public void DeselectCard()
    {
        if (selected < SIZE)
        {
            Hands[selected].GetComponentInChildren<Outline>().enabled = false;
            selected = SIZE;
            Bf bf = new Bf();
            bf.UnmarkPlayable();
        }
    }

    public void HandClicked(int i)
    {
        if (occupied[i])
        {
            if (selected == i)
            {
                DeselectCard();
            }
            else
            {
                DeselectCard();
                SelectCard(i);
            }
        }
    }
}