using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    public static GameObject Decks;
    public static List<Card> deck = new List<Card>();

    private void Start()
    {
        Decks = GameObject.Find("Deck");

        CardStat cardStat = new CardStat();
        deck.Add(cardStat.SetStats(Card.Title.Paladin, Card.Alignment.Ally));
        deck.Add(cardStat.SetStats(Card.Title.Paladin, Card.Alignment.Ally));
        deck.Add(cardStat.SetStats(Card.Title.Paladin, Card.Alignment.Ally));
        deck.Add(cardStat.SetStats(Card.Title.Paladin, Card.Alignment.Ally));
        deck.Add(cardStat.SetStats(Card.Title.Paladin, Card.Alignment.Ally));
        deck.Add(cardStat.SetStats(Card.Title.Captain, Card.Alignment.Enemy));
        deck.Add(cardStat.SetStats(Card.Title.Captain, Card.Alignment.Enemy));
        deck.Add(cardStat.SetStats(Card.Title.Captain, Card.Alignment.Enemy));
        deck.Add(cardStat.SetStats(Card.Title.Captain, Card.Alignment.Enemy));
        deck.Add(cardStat.SetStats(Card.Title.ZombieSwordsman, Card.Alignment.Ally));

        DisplayDeck();
    }
    public void DrawCard()
    {
        for (int i = 0; i < Hand.SIZE; i++)
        {
            if (deck.Count > 0)
            {
                Rng rng = new Rng();
                int rnd = rng.Range(0, deck.Count);
                Hand hand = new Hand();
                hand.AddCardFromDeck(deck[rnd], rnd);
            }
        }
    }

    public void AddCard(Card.Title title)
    {
        CardStat cardStat = new CardStat();
        Card card = cardStat.SetStats(title, Card.Alignment.Ally);
        card.alignment = Card.Alignment.Ally;
        deck.Add(card);
        DisplayDeck();
    }

    public void RemoveCard(int i)
    {
        deck.RemoveAt(i);
        DisplayDeck();
    }

    public void DisplayDeck()
    {
        Decks.GetComponentInChildren<Text>().text = "Deck" + "\n" + deck.Count;
    }
}
