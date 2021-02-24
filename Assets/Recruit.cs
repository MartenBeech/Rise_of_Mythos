using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recruit : MonoBehaviour
{
    public const int SIZE = 3;
    public static GameObject Textbox;
    public static GameObject[] Recruits = new GameObject[SIZE];
    public static GameObject[] Infos = new GameObject[SIZE];
    public static GameObject[] Hourglasses = new GameObject[SIZE];
    public static Card[] Cards = new Card[SIZE];
    private static int cardsToRecruit;

    private void Start()
    {
        for (int i = 0; i < SIZE; i++)
        {
            Recruits[i] = GameObject.Find("RecruitCard (" + i + ")");
            Infos[i] = GameObject.Find("RecruitInfo (" + i + ")");
            Textbox = GameObject.Find("RecruitText");
            Hourglasses[i] = GameObject.Find("RecruitHourglass (" + i + ")");
        }
    }

    public void NewCards(int amount)
    {
        Textbox.GetComponentInChildren<Text>().text = "Recruit " + amount + (amount > 1 ? " cards" : " card");
        cardsToRecruit = amount;
        Camera camera = new Camera();
        camera.Recruit();
        Rng rng = new Rng();
        Card card = new Card();
        CardStat cardStat = new CardStat();
        Card rndCard;
        Cards[0] = cardStat.GetStats(Card.Title.Null, Card.Alignment.Ally);
        Cards[1] = cardStat.GetStats(Card.Title.Null, Card.Alignment.Ally);
        Cards[2] = cardStat.GetStats(Card.Title.Null, Card.Alignment.Ally);


        int rarityChosen = GetRarityToRecruit();

        

        for (int i = 0; i < SIZE; i++)
        {
            List<Card> cards = card.GetCardsByRarity(rarityChosen);
            do
            {
                rndCard = cards[rng.Range(0, cards.Count)];
            } while (rndCard.title == Cards[0].title || rndCard.title == Cards[1].title || rndCard.title == Cards[2].title);

            card.DisplayCard(Recruits[i], rndCard);
            Cards[i] = rndCard;

            SpecialInfo specialInfo = new SpecialInfo();
            Infos[i].GetComponentInChildren<Text>().text = specialInfo.GetCardInfo(rndCard);
            Hourglasses[i].GetComponentInChildren<Text>().text = rndCard.cd.ToString();
        }
    }

    public int GetRarityToRecruit()
    {
        int[] rarityChances;

        switch (Game.level)
        {
            case 1:
                rarityChances = new int[] { 80, 20, 0, 0, 0 };
                break;
            case 2:
                rarityChances = new int[] { 70, 30, 0, 0, 0 };
                break;
            case 3:
                rarityChances = new int[] { 60, 40, 0, 0, 0 };
                break;
            case 4:
                rarityChances = new int[] { 50, 40, 10, 0, 0 };
                break;
            case 5:
                rarityChances = new int[] { 0, 0, 0, 100, 0 };
                break;
            case 6:
                rarityChances = new int[] { 45, 30, 25, 0, 0 };
                break;
            case 7:
                rarityChances = new int[] { 35, 35, 30, 0, 0 };
                break;
            case 8:
                rarityChances = new int[] { 30, 30, 30, 10, 0 };
                break;
            case 9:
                rarityChances = new int[] { 30, 30, 20, 20, 0 };
                break;
            case 10:
                rarityChances = new int[] { 0, 0, 0, 0, 100 };
                break;
            default:
                rarityChances = new int[] { 22, 22, 22, 22, 12 };
                break;
        }

        Rng rng = new Rng();
        int rnd = rng.Range(0, 100);

        if (rnd < rarityChances[0])
            return 1;
        else if (rnd < rarityChances[0] + rarityChances[1])
            return 2;
        else if (rnd < rarityChances[0] + rarityChances[1] + rarityChances[2])
            return 3;
        else if (rnd < rarityChances[0] + rarityChances[1] + rarityChances[2] + rarityChances[3])
            return 4;
        else
            return 5;
    }

    public void ChooseCard(int i)
    {
        Deck deck = new Deck();
        deck.AddCard(Cards[i].title, Cards[i].alignment, 1);

        cardsToRecruit--;
        if (cardsToRecruit > 0)
            NewCards(cardsToRecruit);
        else
        {
            Game game = new Game();
            game.NewBattle();

            Camera camera = new Camera();
            camera.Battle();
        }
    }
}
