using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static int level = 0;
    public void NewBattle()
    {
        Hero hero = new Hero();
        Hero.heroes[0].health = Hero.heroes[0].healthDefault;
        Hero.heroes[1].health = Hero.heroes[1].healthDefault;
        hero.DisplayHero(Card.Alignment.Ally);
        hero.DisplayHero(Card.Alignment.Enemy);

        Recruit recruit = new Recruit();
        recruit.NewCards();
        Camera camera = new Camera();
        camera.Recruit();
    }

    public void WinGame()
    {
        level++;
    }

    public void LoseGame()
    {

    }
}
