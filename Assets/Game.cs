using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static bool gameOver = false;
    public static EnemyHero.Hero enemy;

    public static int level = 0;    //-3
    public static int rank = (level / 5) - 1;

    public void NewBattle()
    {
        Camera camera = new Camera();
        camera.Battle();

        for (int i = 0; i < 10; i++)
        {
            Destroy(GameObject.Find("Card(Clone)"));
        }

        Hero hero = new Hero();
        Hero.heroes[1].healthDefault = hero.GetEnemyHealth(level);
        Hero.heroes[0].healthDefault = hero.GetAllyHealth(level);

        Hero.heroes[0].health = Hero.heroes[0].healthDefault;
        Hero.heroes[1].health = Hero.heroes[1].healthDefault;
        hero.DisplayHero(Card.Alignment.Ally);
        hero.DisplayHero(Card.Alignment.Enemy);

        UI.EndTurn.GetComponentInChildren<Button>().enabled = true;

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

        if (level <= 0)
        {
            Tutorial tutorial = new Tutorial();
            tutorial.SetDeckAlly(level);
            tutorial.SetDeckEnemy(level);
        }
        else
        {
            Tutorial.Textbox.GetComponentInChildren<Text>().text = null;
            EnemyDeck enemyDeck = new EnemyDeck();
            enemyDeck.SetEnemyDeckDefault(enemy);
        }

        if (level == 1)
        {
            UI ui = new UI();
            while (UI.TIMER != 1f)
                ui.SpeedUpGame();
            UI.StartOver.GetComponentInChildren<Image>().enabled = true;
            UI.StartOver.GetComponentInChildren<Button>().enabled = true;
            UI.StartOver.GetComponentInChildren<Text>().enabled = true;
        }

        CardCopy cardCopy = new CardCopy();
        Deck.deckAlly.Clear();
        for (int i = 0; i < Deck.deckAllyDefault.Count; i++)
        {
            Deck.deckAlly.Add(cardCopy.GetCopyOfCard(Deck.deckAllyDefault[i]));
        }
        
        Deck.deckEnemy.Clear();
        for (int i = 0; i < Deck.deckEnemyDefault.Count; i++)
        {
            Deck.deckEnemy.Add(cardCopy.GetCopyOfCard(Deck.deckEnemyDefault[i]));
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

    public EnemyHero.Hero GetRandomEnemy()
    {
        EnemyHero.Hero enemy;
        EnemyHero enemyHero = new EnemyHero();
        if (level <= 0)
            enemy = enemyHero.GetRandomNovice();
        else if (level == 25)
            enemy = enemyHero.GetRandomFinalBoss();
        else if (level % 5 != 0)
            enemy = enemyHero.GetRandomHero();
        else
            enemy = enemyHero.GetRandomBoss();
        return enemy;
    }

    public void WinBattle()
    {
        level++;
        if (level % 5 == 1)
        {
            rank++;
            if (level > 5)
            {
                Upgrade upgrade = new Upgrade();
                upgrade.UpgradeAllCards();
            }
        }
        if (level == 1)
        {
            Recruit recruit = new Recruit();
            recruit.NewCards(10);
        }
        else if (level == 5)
        {
            Recruit recruit = new Recruit();
            recruit.NewCards(3);
        }
        else if (level > 1)
        {
            Recruit recruit = new Recruit();
            recruit.NewCards(1);
        }
        else
        {
            enemy = GetRandomEnemy();
            NewBattle();
        }
    }

    public void LoseBattle()
    {
        NewBattle();
    }

    public void NewGame()
    {
        enemy = GetRandomEnemy();
        NewBattle();
    }

    public void WinBoss()
    {
        AnimaVictory animaVictory = new AnimaVictory();
        animaVictory.DisplayVictory();
    }
}
