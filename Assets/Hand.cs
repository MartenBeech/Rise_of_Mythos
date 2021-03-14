using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    public const int SIZE = 10;
    public static GameObject[] Hands = new GameObject[SIZE];
    public static GameObject[] Hourglasses = new GameObject[SIZE];
    public static Card[] Cards = new Card[SIZE * 2];
    public static bool[] occupied = new bool[SIZE * 2];
    public static int selected = SIZE;

    private void Start()
    {
        for (int i = 0; i < SIZE; i++)
        {
            Hands[i] = GameObject.Find("Hand (" + i + ")");
            Hourglasses[i] = GameObject.Find("Hourglass (" + i + ")");
        }
    }

    public void AddCardFromDeck(Card card, Card.Alignment alignment)
    {
        int handSpace = GetHandSpace(alignment);
        if (handSpace != -1)
        {
            if (handSpace < SIZE)
            {
                AnimaCard animaCard = new AnimaCard();
                animaCard.MoveDeckHand(card, handSpace);
            }
            Cards[handSpace] = card;
            occupied[handSpace] = true;
            card.tile = handSpace;

            Deck deck = new Deck();
            deck.DisplayDeck();
        }
    }

    public void AddCardFromBf(Card card, int i, Card.Alignment alignment)
    {
        int handSpace = GetHandSpace(alignment);
        if (handSpace != -1)
        {
            AnimaCard animaCard = new AnimaCard();
            if (handSpace < SIZE)
                animaCard.MoveBfHand(card, i, handSpace);
            else
                animaCard.MoveBfEnemy(card, i);

            Cards[handSpace] = card;
            occupied[handSpace] = true;

            Deck deck = new Deck();
            deck.DisplayDeck();
        }
    }

    public void AddCardFromNowhere(Card card)
    {
        int handSpace = GetHandSpace(card.alignment);
        if (handSpace != -1)
        {
            if (handSpace < SIZE)
            {
                AnimaCard animaCard = new AnimaCard();
                animaCard.MoveDeckHand(card, handSpace);
            }
            Cards[handSpace] = card;
            occupied[handSpace] = true;

            Deck deck = new Deck();
            deck.DisplayDeck();
        }
    }

    public void RemoveCard(int i)
    {
        if (occupied[i])
        {
            occupied[i] = false;
            if (i < SIZE)
            {
                Cards[i].DisplayNull(Hands[i]);
                Hourglasses[i].GetComponentInChildren<Image>().enabled = false;
                Hourglasses[i].GetComponentInChildren<Text>().text = null;
            }
                
            Cards[i] = null;

            Deck deck = new Deck();
            deck.DisplayDeck();
        }
        if (i < SIZE)
            Hands[i].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("UI/CardBack");
    }

    private int GetHandSpace(Card.Alignment alignment)
    {
        if (alignment == Card.Alignment.Ally)
        {
            for (int i = 0; i < SIZE; i++)
            {
                if (!occupied[i])
                    return i;
            }
        }
        else
        {
            for (int i = SIZE; i < SIZE * 2; i++)
            {
                if (!occupied[i])
                    return i;
            }
        }
        return -1;
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

    public void ReduceCD(int i)
    {
        Cards[i].cd = (Cards[i].cd > 0 ? Cards[i].cd - 1 : 0);
        if (i < SIZE)
        {
            Card card = new Card();
            card.DisplayCard(Hands[i], Cards[i]);
        }
    }
}