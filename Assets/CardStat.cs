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
            case Card.Title.Paladin:
                card.attack = 5;
                card.health = 10;
                card.cd = 0;
                card.speed = 2;
                card.range = 2;
                card.race = Card.Race.Human;
                card.damageType = Card.DamageType.Physical;

                card.alignment = Card.Alignment.Ally;
                card.special.regeneration = 10;
                card.special.dispel = true;
                break;

            case Card.Title.Captain:
                card.attack = 5;
                card.health = 10;
                card.cd = 0;
                card.speed = 2;
                card.range = 4;
                card.race = Card.Race.Human;
                card.damageType = Card.DamageType.Physical;

                card.alignment = Card.Alignment.Enemy;
                card.special.regeneration = 10;
                card.special.heroic = 10;
                break;
        }


        SetDefaults(card, title);
        return card;
    }

    private void SetDefaults(Card card, Card.Title title)
    {
        card.attackDefault = card.attack;
        card.healthMaxDefault = card.healthMax = card.healthDefault = card.health;
        card.cdDefault = card.cd;

        card.tile = Bf.SIZE;

        card.sprite = Resources.Load<Sprite>("Cards/" + title.ToString());
    }
}
