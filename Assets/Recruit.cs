using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recruit : MonoBehaviour
{
    public const int SIZE = 3;
    public static GameObject[] Recruits = new GameObject[SIZE];
    public static GameObject[] Infos = new GameObject[SIZE];
    public static Card[] Cards = new Card[SIZE];

    private void Start()
    {
        for (int i = 0; i < SIZE; i++)
        {
            Recruits[i] = GameObject.Find("RecruitCard (" + i + ")");
            Infos[i] = GameObject.Find("RecruitInfo (" + i + ")");
        }
    }

    public void NewCards()
    {
        Rng rng = new Rng();
        Card card = new Card();
        CardStat cardStat = new CardStat();
        Card rndCard;
        Cards[0] = cardStat.GetStats(Card.Title.Null, Card.Alignment.Ally);
        Cards[1] = cardStat.GetStats(Card.Title.Null, Card.Alignment.Ally);
        Cards[2] = cardStat.GetStats(Card.Title.Null, Card.Alignment.Ally);

        for (int i = 0; i < SIZE; i++)
        {
            List<Card> cards = card.GetCardsByRarity(1);
            do
            {
                rndCard = cards[rng.Range(0, cards.Count)];
            } while (rndCard.title == Cards[0].title || rndCard.title == Cards[1].title || rndCard.title == Cards[2].title);

            card.DisplayCard(Recruits[i], rndCard);
            Cards[i] = rndCard;
        }
    }
}
