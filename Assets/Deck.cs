using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    public GameObject Decks;
    public List<Card> deck = new List<Card>();

    private void Start()
    {
        Decks = GameObject.Find("Deck");
        DisplayDeck();
    }
    public void DrawCard()
    {
        if (deck.Count > 0)
        {
            Rng rng = new Rng();
            int rnd = rng.Range(0, deck.Count);
            Hand hand = new Hand();
            hand.AddCard(deck[rnd]);
            RemoveCard(rnd);
        }
    }

    public void AddCard(Card card)
    {
        deck.Add(card);
        DisplayDeck();
    }

    public void AddCard()
    {
        Card card = new Card();
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
