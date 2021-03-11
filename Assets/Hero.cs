using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    const int SIZE = 2;
    public static GameObject[] Heroes = new GameObject[SIZE];
    public static Hero[] heroes = new Hero[SIZE];

    public int health,  healthDefault = 20;
    public bool destroyHero = false;

    private void Start()
    {
        for (int i = 0; i < SIZE; i++)
        {
            Heroes[i] = GameObject.Find("Hero (" + i + ")");
            heroes[i] = new Hero();
        }
    }

    private void Update()
    {
        if (heroes[0].destroyHero)
        {
            Heroes[0].transform.localScale = new Vector3(Heroes[0].transform.localScale.x - (0.001f / UI.TIMER), Heroes[0].transform.localScale.y - (0.001f / UI.TIMER), 1);
            if (Heroes[0].transform.localScale.x <= 0 || Heroes[0].transform.localScale.y <= 0)
            {
                heroes[0].destroyHero = false;
                Heroes[0].transform.localScale = new Vector3(0.5f, 0.5f, 1);
                Game game = new Game();
                game.LoseBattle();
            }
        }
        if (heroes[1].destroyHero)
        {
            Heroes[1].transform.localScale = new Vector3(Heroes[1].transform.localScale.x - (0.001f / UI.TIMER), Heroes[1].transform.localScale.y - (0.001f / UI.TIMER), 1);
            if (Heroes[1].transform.localScale.x <= 0 || Heroes[1].transform.localScale.y <= 0)
            {
                heroes[1].destroyHero = false;
                Heroes[1].transform.localScale = new Vector3(0.5f, 0.5f, 1);
                Game game = new Game();
                if (Game.level % 5 != 0)
                    game.WinBattle();
                else
                    game.WinBoss();
            }
        }
    }

    public void AttackHero(Card dealer, Card.Alignment alignment)
    {
        dealer.attackedThisTurn = true;
        int damage = dealer.attack[dealer.rank];
        damage += dealer.bonusAttackNextTurn;

        Special special = new Special();
        damage = special.CheckShadowBolt(dealer, damage);
        if (damage > 0)
        {
            special.CheckLifeSteal(dealer, damage);
            special.CheckLifeAbsorb(dealer, damage);
            special.CheckHeroic(dealer);
            special.CheckInfluence(dealer);
            special.CheckSoulEater(dealer);
            
            
        }

        for (int i = 0; i < dealer.special.multistrike[dealer.rank] + 1; i++)
        {
            special.CheckPanicStrike(dealer);
            DealDamage(dealer, alignment, damage);
        }
    }

    public void DealDamage(Card dealer, Card.Alignment alignment, int damage)
    {
        if (heroes[0].health > 0 && heroes[1].health > 0)
        {
            Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.red;

            if (alignment == Card.Alignment.Ally)
            {
                heroes[0].health -= damage;
                DisplayHero(Card.Alignment.Ally);
                AnimaText animaText = new AnimaText();
                animaText.ShowText(Heroes[0], damage.ToString(), Hue.red);

                if (heroes[0].health <= 0)
                {
                    heroes[0].destroyHero = true;
                    Game.gameOver = true;
                }
            }
            else
            {
                heroes[1].health -= damage;
                DisplayHero(Card.Alignment.Enemy);
                AnimaText animaText = new AnimaText();
                animaText.ShowText(Heroes[1], damage.ToString(), Hue.red);

                if (heroes[1].health <= 0)
                {
                    heroes[1].destroyHero = true;
                    Game.gameOver = true;
                    if (Game.level % 5 == 0)
                        animaText.ShowText(Hero.Heroes[0], "All cards rank up", Hue.cyan);
                }
            }
        }
    }

    public void DisplayHero(Card.Alignment alignment)
    {
        if (alignment == Card.Alignment.Ally)
        {
            Heroes[0].GetComponentInChildren<Text>().text = "<color=green>" + heroes[0].health + "/" + heroes[0].healthDefault + "</color>";
        }
        else
        {
            Heroes[1].GetComponentInChildren<Text>().text = "<color=red>" + heroes[1].health + "/" + heroes[1].healthDefault + "</color>";
        }
    }

    public int GetEnemyHealth(int level)
    {
        if (level <= 0)
            return 10;
        else if (level % 5 != 0)
        {
            if (level <= 5)
                return 10;
            else if (level <= 10)
                return 20;
            else if (level <= 15)
                return 30;
            else if (level <= 20)
                return 40;
            else
                return 50;
        }
        else
        {
            if (level <= 5)
                return 30;
            else if (level <= 10)
                return 50;
            else if (level <= 15)
                return 70;
            else if (level <= 20)
                return 90;
            else
                return 300;
        }
    }

    public int GetAllyHealth(int level)
    {
        if (level <= 0)
            return 20;
        else
            return 20 + level;
        
    }
}
