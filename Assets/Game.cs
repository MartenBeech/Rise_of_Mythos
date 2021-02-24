using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static bool gameOver = false;
    private void Start()
    {
        WinBattle();
    }

    public static int level = 0;

    public void NewBattle()
    {
        Hero hero = new Hero();
        Hero.heroes[1].healthDefault = hero.GetEnemyHealth(level);

        Hero.heroes[0].health = Hero.heroes[0].healthDefault;
        Hero.heroes[1].health = Hero.heroes[1].healthDefault;
        hero.DisplayHero(Card.Alignment.Ally);
        hero.DisplayHero(Card.Alignment.Enemy);

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

        EnemyHero.Hero enemy;
        EnemyHero enemyHero = new EnemyHero();
        if (level <= 0)
            enemy = enemyHero.GetRandomNovice();
        else if (level % 5 != 0)
            enemy = enemyHero.GetRandomHero();
        else
            enemy = enemyHero.GetRandomBoss();

        if (level <= 0)
        {
            Tutorial tutorial = new Tutorial();
            tutorial.SetDeckAlly(level);
            tutorial.SetDeckEnemy(level);
        }
        else
        {
            Tutorial.Textbox.GetComponentInChildren<Text>().text = null;
            CardStat cardStat = new CardStat();
            Deck.deckAlly.Clear();
            for (int i = 0; i < Deck.deckAllyDefault.Count; i++)
            {
                Deck.deckAlly.Add(cardStat.GetStats(Deck.deckAllyDefault[i].title, Deck.deckAllyDefault[i].alignment));
            }

            EnemyDeck enemyDeck = new EnemyDeck();
            enemyDeck.SetEnemyDeckDefault(enemy);
            Deck.deckEnemy.Clear();
            for (int i = 0; i < Deck.deckEnemyDefault.Count; i++)
            {
                Deck.deckEnemy.Add(cardStat.GetStats(Deck.deckEnemyDefault[i].title, Deck.deckEnemyDefault[i].alignment));
            }
        }

        Hero.Heroes[1].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Heroes/" + enemy);

        Deck deck = new Deck();
        for (int i = 0; i < 3; i++)
        {
            deck.DrawCard(Card.Alignment.Ally);
            deck.DrawCard(Card.Alignment.Enemy);
        }

        gameOver = false;
    }

    public void WinBattle()
    {
        level++;
        if (level == 1)
        {
            Recruit recruit = new Recruit();
            recruit.NewCards(10);
        }
        else if (level > 1)
        {
            Recruit recruit = new Recruit();
            recruit.NewCards(1);
        }
        else
            NewBattle();
    }

    public void LoseBattle()
    {
        NewBattle();
    }

    public void NewGame()
    {
        //Deck deck = new Deck();
        //Card card = new Card();
        //Rng rng = new Rng();
        //List<Card> cardsRarity1 = card.GetCardsByRarity(1);

        //for (int i = 0; i < 10; i++)
        //    deck.AddCard(cardsRarity1[rng.Range(0, cardsRarity1.Count)].title, Card.Alignment.Ally);

        NewBattle();
    }
}
