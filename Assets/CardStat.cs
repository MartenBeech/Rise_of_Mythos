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
                card.race = Card.Race.Human;
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
                card.special.shadowBolt = 2;
                break;

            case Card.Title.Captain:
                card.race = Card.Race.Human;
                card.attack = 5;
                card.health = 50;
                card.cd = 0;
                card.range = 10;
                card.speed = 2;
                
                card.alignment = Card.Alignment.Enemy;
                card.special.shadowBolt = 2;
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

        string _title = title.ToString();
        for (int j = 1; j < _title.Length; j++)
        {
            if ((int)_title[j] >= 65 && (int)_title[j] <= 90) //Capital Letters
            {
                _title = _title.Insert(j, "_");
                j++;
            }
        }

        card.sprite = Resources.Load<Sprite>("Cards/" + _title);
    }
}
