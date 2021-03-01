using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public const int SIZE = 3;
    public static GameObject Textbox;
    public static GameObject[] Upgrades = new GameObject[SIZE * 2];
    public static GameObject[] Infos = new GameObject[SIZE * 2];
    public static GameObject[] Hourglasses = new GameObject[SIZE];
    public static Card[] Cards = new Card[SIZE * 2];

    private void Start()
    {
        for (int i = 0; i < SIZE * 2; i++)
        {
            Upgrades[i] = GameObject.Find("UpgradeCard (" + i + ")");
            Infos[i] = GameObject.Find("UpgradeInfo (" + i + ")");
        }
        for (int i = 0; i < SIZE; i++)
        {
            Hourglasses[i] = GameObject.Find("UpgradeHourglass (" + i + ")");
        }
        Textbox = GameObject.Find("UpgradeText");
    }

    public void NewCards()
    {
        Textbox.GetComponentInChildren<Text>().text = "Select 1 of 3 cards from your deck to be permanently upgraded";
        Camera camera = new Camera();
        camera.Upgrade();
        Rng rng = new Rng();
        Card card = new Card();
        CardStat cardStat = new CardStat();
        Card rndCard;
        Cards[0] = cardStat.GetStats(Card.Title.Null, Card.Alignment.Ally, Game.rank);
        Cards[1] = cardStat.GetStats(Card.Title.Null, Card.Alignment.Ally, Game.rank);
        Cards[2] = cardStat.GetStats(Card.Title.Null, Card.Alignment.Ally, Game.rank);

        List<Card> cards = new List<Card>();
        for (int i = 0; i < Deck.deckAllyDefault.Count; i++)
        {
            if (!Deck.deckAllyDefault[i].upgraded)
                cards.Add(Deck.deckAllyDefault[i]);
        }

        for (int i = 0; i < SIZE; i++)
        {
            do
            {
                rndCard = cards[rng.Range(0, cards.Count)];
            } while (rndCard.title == Cards[0].title || rndCard.title == Cards[1].title || rndCard.title == Cards[2].title);

            Cards[i] = cardStat.GetStats(rndCard.title, rndCard.alignment, rndCard.rank);
            card.DisplayCard(Upgrades[i], Cards[i]);

            SpecialInfo specialInfo = new SpecialInfo();
            Infos[i].GetComponentInChildren<Text>().text = specialInfo.GetCardInfo(Cards[i]);
            Hourglasses[i].GetComponentInChildren<Text>().text = rndCard.cd.ToString();
        }

        for (int i = SIZE; i < SIZE * 2; i++)
        {
            Cards[i] = cardStat.GetStats(Cards[i - 3].title, Cards[i - 3].alignment, Cards[i - 3].rank + 1);
            card.DisplayCard(Upgrades[i], Cards[i]);

            SpecialInfo specialInfo = new SpecialInfo();
            Infos[i].GetComponentInChildren<Text>().text = specialInfo.GetCardInfo(Cards[i]);
        }
    }

    public void ChooseCard(int i)
    {
        CardStat cardStat = new CardStat();
        for (int j = 0; j < Deck.deckAllyDefault.Count; j++)
        {
            if (Deck.deckAllyDefault[j].title == Cards[i].title && !Deck.deckAllyDefault[j].upgraded)
            {
                Deck.deckAllyDefault[j] = cardStat.GetStats(Deck.deckAllyDefault[j].title, Deck.deckAllyDefault[j].alignment, Deck.deckAllyDefault[j].rank + 1);
                Deck.deckAllyDefault[j].upgraded = true;
                break;
            }
        }
        Game game = new Game();
        Game.enemy = game.GetRandomEnemy();
        game.NewBattle();
    }

    public void UpgradeAllCards()
    {
        CardStat cardStat = new CardStat();
        for (int i = 0; i < Deck.deckAllyDefault.Count; i++)
        {
            bool upgraded = Deck.deckAllyDefault[i].upgraded;
            Deck.deckAllyDefault[i] = cardStat.GetStats(Deck.deckAllyDefault[i].title, Deck.deckAllyDefault[i].alignment, Deck.deckAllyDefault[i].rank + 1);
            Deck.deckAllyDefault[i].upgraded = upgraded;
        }
        AnimaText animaText = new AnimaText();
        animaText.ShowText(Hero.Heroes[0], "All cards rank up", Hue.cyan);
    }
}
