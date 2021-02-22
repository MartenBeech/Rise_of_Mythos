using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    public static GameObject Decks;
    public static List<Card> deckAlly = new List<Card>();
    public static List<Card> deckAllyDefault = new List<Card>();
    public static List<Card> deckEnemy = new List<Card>();
    public static List<Card> deckEnemyDefault = new List<Card>();

    private void Start()
    {
        Decks = GameObject.Find("Deck");

        AddCard(Card.Title.Null, Card.Alignment.Ally, 5);
        AddCard(Card.Title.Null, Card.Alignment.Enemy, 5);
    }
    public void DrawCardClicked()
    {
        for (int i = 0; i < 10; i++)
        {
            DrawCard(Card.Alignment.Ally);
            DrawCard(Card.Alignment.Enemy);
        }
    }

    public void DrawCard(Card.Alignment alignment)
    {
        if (alignment == Card.Alignment.Ally)
        {
            if (deckAlly.Count > 0)
            {
                Rng rng = new Rng();
                int rnd = rng.Range(0, deckAlly.Count);
                Hand hand = new Hand();
                hand.AddCardFromDeck(deckAlly[rnd], rnd, alignment);
                RemoveCard(rnd, alignment);
            }
        }
        else
        {
            if (deckEnemy.Count > 0)
            {
                Rng rng = new Rng();
                int rnd = rng.Range(0, deckEnemy.Count);
                Hand hand = new Hand();
                hand.AddCardFromDeck(deckEnemy[rnd], rnd, alignment);
                RemoveCard(rnd, alignment);
            }
        }
    }

    public void AddCard(Card.Title title, Card.Alignment alignment, int amount = 1)
    {
        CardStat cardStat = new CardStat();
        for (int i = 0; i < amount; i++)
        {
            Card card = cardStat.GetStats(title, alignment);
            if (alignment == Card.Alignment.Ally)
                deckAllyDefault.Add(card);
            else
                deckAllyDefault.Add(card);
            //deckEnemyDefault.Add(card);
        }

        DisplayDeck();
    }

    public void RemoveCard(int i, Card.Alignment alignment)
    {
        if (alignment == Card.Alignment.Ally)
            deckAlly.RemoveAt(i);
        else
            deckEnemy.RemoveAt(i);
        DisplayDeck();
    }

    public void DisplayDeck()
    {
        int handAlly = 0;
        for (int i = 0; i < Hand.SIZE; i++)
        {
            if (Hand.occupied[i])
                handAlly++;
        }
        int handEnemy = 0;
        for (int i = Hand.SIZE; i < Hand.SIZE * 2; i++)
        {
            if (Hand.occupied[i])
                handEnemy++;
        }

        Decks.GetComponentInChildren<Text>().text =
            "<color=green>" + "Hand: " + "</color>" + handAlly + "\n" +
            "<color=green>" + "Deck: " + "</color>" + deckAlly.Count + "\n\n" +
            "<color=red>" + "Hand: " + "</color>" + handEnemy + "\n" +
            "<color=red>" + "Deck: " + "</color>" + deckEnemy.Count;
    }
}
