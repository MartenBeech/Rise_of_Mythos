using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    const int SIZE = 2;
    public static GameObject[] Heroes = new GameObject[SIZE];
    public static Hero[] heroes = new Hero[SIZE];

    public int health,  healthDefault = 50;

    private void Start()
    {
        for (int i = 0; i < SIZE; i++)
        {
            Heroes[i] = GameObject.Find("Hero (" + i + ")");
            heroes[i] = new Hero();
        }
    }

    public void AttackHero(Card dealer, Card.Alignment alignment)
    {
        Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.red;
        for (int i = 0; i < dealer.special.multistrike + 1; i++)
        {
            if (alignment == Card.Alignment.Ally)
            {
                heroes[0].health -= dealer.attack;
                if (heroes[0].health > 0)
                {
                    DisplayHero(Card.Alignment.Ally);
                    AnimaText animaText = new AnimaText();
                    animaText.ShowText(Heroes[0], dealer.attack.ToString(), Hue.red);
                }
                else
                {
                    Game game = new Game();
                    game.LoseGame();
                }
            }
            else
            {
                heroes[1].health -= dealer.attack;
                if (heroes[1].health > 0)
                {
                    DisplayHero(Card.Alignment.Enemy);
                    AnimaText animaText = new AnimaText();
                    animaText.ShowText(Heroes[1], dealer.attack.ToString(), Hue.red);
                }
                else
                {
                    Game game = new Game();
                    game.WinGame();
                }
            }
        }
    }

    public void DisplayHero(Card.Alignment alignment)
    {
        if (alignment == Card.Alignment.Ally)
        {
            Heroes[0].GetComponentInChildren<Text>().text = "<color=red>" + heroes[0].health + "/" + heroes[0].healthDefault + "</color>";
        }
        else
        {
            Heroes[1].GetComponentInChildren<Text>().text = "<color=red>" + heroes[1].health + "/" + heroes[1].healthDefault + "</color>";
        }
    }
}
