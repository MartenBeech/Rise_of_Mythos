using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHero : MonoBehaviour
{
    public enum Hero
    {
        Adar, Ajit, Anastasya, Andras, Danan,
        Fahada, Imani, Ivan, Jengo, Kente,
        Khalida, Konrad, Lasir, Ludmilla, Malathua,
        Malwen, Masfar, Mateusz, Menan, Murazel,
        Nolwenn, Qasim, Seamus, Tanis, Vayaron,
        Wysloth, Zakera, Zenda,
        Null
    };

    public Hero[] tutorials =
    {
        Hero.Murazel, Hero.Qasim, Hero.Zakera
    };
    
    public Hero[] heroes = 
    {
        Hero.Ajit, Hero.Anastasya, Hero.Andras, Hero.Danan, Hero.Fahada, 
        Hero.Imani, Hero.Jengo, Hero.Kente, Hero.Konrad, Hero.Lasir, 
        Hero.Malathua, Hero.Malwen, Hero.Masfar, Hero.Mateusz, Hero.Nolwenn, 
        Hero.Seamus, Hero.Tanis, Hero.Vayaron, Hero.Wysloth, Hero.Zenda
    };

    public Hero[] bosses =
    {
        Hero.Adar, Hero.Ivan, Hero.Khalida, Hero.Ludmilla, Hero.Menan
    };

    public Hero GetRandomHero()
    {
        List<Hero> heroList = new List<Hero>();
        for (int i = 0; i < heroes.Length; i++)
        {
            if (heroes[i] != Hero.Null)
                heroList.Add(heroes[i]);
        }
        Rng rng = new Rng();
        int rnd = rng.Range(0, heroList.Count);

        for (int i = 0; i < heroes.Length; i++)
        {
            if (heroes[i] == heroList[rnd])
            {
                heroes[i] = Hero.Null;
                break;
            }
        }

        return heroList[rnd];
    }
}
