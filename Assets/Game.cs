using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static int level = 1;

    public void NewBattle()
    {
        Hero hero = new Hero();
        Hero.heroes[0].health = Hero.heroes[0].healthDefault;
        Hero.heroes[1].health = Hero.heroes[1].healthDefault;
        hero.DisplayHero(Card.Alignment.Ally);
        hero.DisplayHero(Card.Alignment.Enemy);

        CardStat cardStat = new CardStat();
        Deck.deckAlly.Clear();
        Deck.deckEnemy.Clear();
        for (int i = 0; i < Deck.deckAllyDefault.Count; i++)
        {
            Deck.deckAlly.Add(cardStat.GetStats(Deck.deckAllyDefault[i].title, Deck.deckAllyDefault[i].alignment));
        }
        for (int i = 0; i < Deck.deckEnemyDefault.Count; i++)
        {
            Deck.deckEnemy.Add(cardStat.GetStats(Deck.deckAllyDefault[i].title, Deck.deckAllyDefault[i].alignment));
        }
        Deck deck = new Deck();
        deck.DisplayDeck();

        Hand hand = new Hand();
        for (int i = 0; i < Hand.SIZE * 2; i++)
        {
            hand.RemoveCard(i);
        }

        Bf bf = new Bf();
        for (int i = 0; i < Bf.SIZE; i++)
        {
            bf.RemoveCard(i);
        }
    }

    public void WinGame()
    {
        level++;
        Recruit recruit = new Recruit();
        recruit.NewCards();
    }

    public void LoseGame()
    {
        Recruit recruit = new Recruit();
        recruit.NewCards();
    }
}
