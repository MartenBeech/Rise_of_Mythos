using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public static GameObject Textbox;

    private string[] text1 = new string[] { 
        "Welcome to the game, Commander!\nThe bottom of the screen shows your hand. You have 2 cards in your hand; a Fencer and a Priestess.",
        "The hourglasses over your cards show their countdown. The countdown is reduced by 1 each turn, and cards can be played when they have a countdown of 0.",
        "Your opponent just played a Lizard. Lucky for you it has reduced speed and range. The default value for both is 2.",
        "Play your Fencer in the same row as the Lizard to defend your Hero. She will be able to move up to 2 tiles, and then attack 2 tiles in front of it.",
        "Unfortunately, your Fencer's <b>Physical</b> damage is no match against the Lizard's <b>Armor</b>. Luckily, your Priestess deals <b>Magical</b> damage. Play her on the same row.",
        "",
        "Phew, that was close. Now your units are unthreatened to attack the Enemy Hero."
        };
    private string[] text2 = new string[] { 
        "The botton left shows each player's deck and hand count. You would draw 1 card each turn if you had any in your deck.",
        "Oh boy, your opponent just summoned 2 Elven Longbow Archers. They have 7 range and can attack from long distances.",
        "Units with 4+ range choose not to move when they have a target in range. Sadly for you, your hero is that target.",
        "You can now play your Lancers. They have 4 speed and <b>Charge</b> which allows them to deal more damage by gaining a runup. Play all 3 on the far left column.",
        "That should deal with them. Now charge for the enemy hero!"
    };
    private string[] text3 = new string[] { 
        "This game is very fun and addictive. Remember to take a few breaks once in a while. But not now!",
        "Looks like your opponent is trying to rush you down with his own cavalry. At least his doesn't have <b>Charge</b>.",
        "The Knight has the <b>Heroic</b> ability, causing his attacks to get stronger and stronger. You need to stop him quickly.",
        "Your Squire has the <b>Vigilance</b> ability which allows him to attack adjacent tiles. Play him behind the Knight.",
        "",
        "",
        "Good job, Commander. Now finish up the enemy hero and finish the tutorial. After this you will be able to craft your own deck.",
        "You can speed up the game if the animations are too slow for your taste."
    };
    private static int arrayPoint = 0;

    private void Start()
    {
        Textbox = GameObject.Find("Tutorial");
    }
    public void SetDeckAlly(int level)
    {
        arrayPoint = 0;
        SetText(level);
        Deck.deckAlly.Clear();
        CardStat cardStat = new CardStat();
        Card card = new Card();
        switch (level)
        {
            case -2:
                card = cardStat.GetStats(Card.Title.Fencer, Card.Alignment.Ally, 0);
                card.attack = card.attackDefault = 4;
                card.health = card.healthDefault = card.healthMax = card.healthMaxDefault = 6;
                card.cd = card.cdDefault = 3;
                Deck.deckAlly.Add(card);

                card = cardStat.GetStats(Card.Title.Priestess, Card.Alignment.Ally, 0);
                card.attack = card.attackDefault = 4;
                card.health = card.healthDefault = card.healthMax = card.healthMaxDefault = 10;
                card.cd = card.cdDefault = 4;
                card.range = card.rangeDefault = 2;
                card.special.penetrate = false;
                Deck.deckAlly.Add(card);
                break;

            case -1:
                for (int i = 0; i < 2; i++)
                {
                    card = cardStat.GetStats(Card.Title.Lancer, Card.Alignment.Ally, 0);
                    card.attack = card.attackDefault = 1;
                    card.health = card.healthDefault = card.healthMax = card.healthMaxDefault = 10;
                    card.cd = card.cdDefault = 3;

                    Deck.deckAlly.Add(card);
                }
                break;

            case 0:
                card = cardStat.GetStats(Card.Title.Squire, Card.Alignment.Ally, 0);
                card.attack = card.attackDefault = 5;
                card.health = card.healthDefault = card.healthMax = card.healthMaxDefault = 25;
                card.cd = card.cdDefault = 3;

                Deck.deckAlly.Add(card);
                break;
        }
    }

    public void SetDeckEnemy(int level)
    {
        Deck.deckEnemy.Clear();
        CardStat cardStat = new CardStat();
        Card card = new Card();
        switch (level)
        {
            case -2:
                card = cardStat.GetStats(Card.Title.Lizard, Card.Alignment.Enemy, 0);
                card.attack = card.attackDefault = 2;
                card.health = card.healthDefault = card.healthMax = card.healthMaxDefault = 10;
                card.cd = card.cdDefault = 2;
                card.special.headbutt = false;
                card.special.armor = 3;
                Deck.deckEnemy.Add(card);
                break;

            case -1:
                for (int i = 0; i < 2; i++)
                {
                    card = cardStat.GetStats(Card.Title.ElvenLongbowArcher, Card.Alignment.Enemy, 0);
                    card.attack = card.attackDefault = 1;
                    card.health = card.healthDefault = card.healthMax = card.healthMaxDefault = 5;
                    card.cd = card.cdDefault = 1;
                    card.range = 7;

                    Deck.deckEnemy.Add(card);
                }
                break;

            case 0:
                card = cardStat.GetStats(Card.Title.Knight, Card.Alignment.Enemy, 0);
                card.attack = card.attackDefault = 3;
                card.health = card.healthDefault = card.healthMax = card.healthMaxDefault = 15;
                card.cd = card.cdDefault = 1;

                Deck.deckEnemy.Add(card);
                break;
        }
    }

    public void SetText(int level)
    {
        switch (level)
        {
            case -2:
                if (arrayPoint < text1.Length)
                {
                    if (text1[arrayPoint] != "")
                        ShowText(text1[arrayPoint]);
                    arrayPoint++;
                }
                break;

            case -1:
                if (arrayPoint < text2.Length)
                {
                    if (text2[arrayPoint] != "")
                        ShowText(text2[arrayPoint]);
                    arrayPoint++;
                }
                break;

            case 0:
                if (arrayPoint < text3.Length)
                {
                    if (text3[arrayPoint] != "")
                        ShowText(text3[arrayPoint]);
                    arrayPoint++;
                }
                break;
        }
    }

    public void ShowText(string text)
    {
        Textbox.GetComponentInChildren<Text>().text = text + "\n\n<i>(Press End Turn)</i>";
    }
}