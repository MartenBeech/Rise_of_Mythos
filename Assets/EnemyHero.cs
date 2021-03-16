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

    public static Hero[] novices =
    {
        Hero.Murazel, Hero.Qasim, Hero.Zakera
    };
    
    public static Hero[] heroes = 
    {
        Hero.Ajit, Hero.Anastasya, Hero.Andras, Hero.Danan, Hero.Fahada, 
        Hero.Imani, Hero.Jengo, Hero.Kente, Hero.Konrad, Hero.Lasir, 
        Hero.Malathua, Hero.Malwen, Hero.Masfar, Hero.Mateusz, Hero.Nolwenn, 
        Hero.Seamus, Hero.Tanis, Hero.Vayaron, Hero.Wysloth, Hero.Zenda
    };

    public static Hero[] bosses =
    {
        Hero.Adar, Hero.Ivan, Hero.Khalida, Hero.Ludmilla, Hero.Menan
    };

    public Hero GetRandomNovice()
    {
        List<Hero> heroList = new List<Hero>();
        for (int i = 0; i < novices.Length; i++)
        {
            if (novices[i] != Hero.Null)
                heroList.Add(novices[i]);
        }
        Rng rng = new Rng();
        int rnd = rng.Range(0, heroList.Count);

        for (int i = 0; i < novices.Length; i++)
        {
            if (novices[i] == heroList[rnd])
            {
                novices[i] = Hero.Null;
                break;
            }
        }

        return heroList[rnd];
    }

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

    public Hero GetRandomBoss()
    {
        List<Hero> heroList = new List<Hero>();
        for (int i = 0; i < bosses.Length; i++)
        {
            if (bosses[i] != Hero.Null)
                heroList.Add(bosses[i]);
        }
        Rng rng = new Rng();
        int rnd = rng.Range(0, heroList.Count);

        for (int i = 0; i < bosses.Length; i++)
        {
            if (bosses[i] == heroList[rnd])
            {
                bosses[i] = Hero.Null;
                break;
            }
        }

        return heroList[rnd];
    }

    public string GetHeroInfo()
    {
        string text = "<size=50>" + Game.enemy + "</size>" + "\n\n";

        text += "Speciality: ";

        if (Game.enemy == Hero.Adar)
            text += "Legendary units have -1 cd";
        else if (Game.enemy == Hero.Ivan)
            text += "Units with 4+ speed gain Charge " + (Game.level < 25 ? "+1" : "+2");
        else if (Game.enemy == Hero.Kente)
            text += "Units gain Multistrike +1";
        else if (Game.enemy == Hero.Ludmilla)
            text += "Units gain Soulbound and Reanimate";
        else if (Game.enemy == Hero.Menan)
            text += "Units with Life Steal gain Life Absorb";
        else
            text += "None";

        return text;
    }
}
