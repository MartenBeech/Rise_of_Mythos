using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardStat : MonoBehaviour
{
    public Card SetStats(Card.Title title)
    {
        Card card = new Card();

        switch(title)
        {
            case Card.Title.PlaceHolder:
                card.race = Card.Race.Neutral;
                card.attack = 1;
                card.health = 1;
                card.cd = 0;
                card.range = 2;
                card.speed = 2;

                card.alignment = Card.Alignment.Ally;
                break;

            case Card.Title.Paladin:
                card.race = Card.Race.Human;
                card.attack = 5;
                card.health = 50;
                card.cd = 0;
                card.range = 2;
                card.speed = 2;
                
                card.alignment = Card.Alignment.Ally;
                card.special.whirlwind = true;
                break;

            case Card.Title.Captain:
                card.race = Card.Race.Human;
                card.attack = 5;
                card.health = 50;
                card.cd = 0;
                card.range = 10;
                card.speed = 2;
                
                card.alignment = Card.Alignment.Enemy;
                card.special.whirlwind = true;
                break;

            case Card.Title.ZombieSwordsman:
                card.race = Card.Race.Undead;
                card.attack = 1;
                card.health = 1;
                card.cd = 0;
                card.range = 2;
                card.speed = 2;

                card.alignment = Card.Alignment.Ally;
                break;
        }


        SetDefaults(card, title);
        return card;
    }

    private void SetDefaults(Card card, Card.Title title)
    {
        card.title = title;
        card.attackDefault = card.attack;
        card.healthMaxDefault = card.healthMax = card.healthDefault = card.health;
        card.cdDefault = card.cd;

        card.tile = Bf.SIZE;

        card.nameTag = title.ToString();
        for (int j = 1; j < card.nameTag.Length; j++)
        {
            if ((int)card.nameTag[j] >= 65 && (int)card.nameTag[j] <= 90) //Capital Letters
            {
                card.nameTag = card.nameTag.Insert(j, " ");
                j++;
            }
        }

        card.sprite = Resources.Load<Sprite>("Cards/" + card.race + "/" + card.nameTag.Replace(' ', '_'));
    }
}
