using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardStat : MonoBehaviour
{
    private void SetDefaults(Card card, Card.Title title, Card.Alignment alignment, int rank)
    {
        card.title = title;
        card.attackDefault = new int[6] { card.attack[0], card.attack[1], card.attack[2], card.attack[3], card.attack[4], card.attack[5] };
        card.healthMaxDefault = card.healthMax = card.healthDefault = new int[6] { card.health[0], card.health[1], card.health[2], card.health[3], card.health[4], card.health[5] };
        card.cdDefault = card.cd;
        card.speedDefault = card.speed;
        card.rangeDefault = card.range;

        card.alignment = alignment;
        card.rank = rank;

        card.nameTag = title.ToString();
        for (int j = 1; j < card.nameTag.Length; j++)
        {
            if ((int)card.nameTag[j] >= 65 && (int)card.nameTag[j] <= 90) //Capital Letters
            {
                card.nameTag = card.nameTag.Insert(j, " ");
                j++;
            }
        }

        card.sprite = Resources.Load<Sprite>("Cards/Rarity" + card.rarity + "/" + card.nameTag.Replace(' ', '_'));
    }

    public Card GetStats(Card.Title title, Card.Alignment alignment, int rank)
    {
        Card card = new Card();


        switch (title)
        {
            case Card.Title.Bat:
                card.attack = new int[6] { 1, 1, 2, 2, 2, 3 };
                card.health = new int[6] { 4, 6, 6, 8, 10, 12 };
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                card.special.flying = true;
                card.special.lifeSteal = true;
                break;

            case Card.Title.CentaurArcher:
                card.attack = new int[6] { 1, 1, 2, 2, 3, 4 };
                card.health = new int[6] { 1, 2, 2, 4, 4, 5 };
                card.cd = 1;
                card.range = 4;
                card.speed = 4;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                card.special.hitAndRun = true;
                break;

            case Card.Title.CentaurRider:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                card.health = new int[6] { 4, 5, 7, 7, 9, 11 };
                card.cd = 1;
                card.range = 2;
                card.speed = 4;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                card.special.hitAndRun = true;
                break;

            case Card.Title.Crossbowman:
                card.attack = new int[6] { 2, 2, 3, 3, 4, 5 };
                card.health = new int[6] { 5, 7, 8, 10, 11, 14 };
                card.cd = 2;
                card.range = 4;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                card.special.heavyWeapon = true;
                break;

            case Card.Title.DarkRider:
                card.attack = new int[6] { 1, 1, 2, 2, 3, 3 };
                card.health = new int[6] { 4, 6, 7, 10, 11, 13 };
                card.cd = 3;
                card.range = 2;
                card.speed = 4;
                card.rarity = 1;
                card.damageType = Card.DamageType.Magical;
                card.special.armor = new int[6] { 1, 1, 1, 1, 1, 1 };
                card.special.spellCurse = new int[6] { 1, 1, 2, 2, 2, 3 };
                break;

            case Card.Title.DreadScout:
                card.attack = new int[6] { 1, 1, 2, 2, 3, 4 };
                card.health = new int[6] { 4, 6, 7, 9, 10, 12 };
                card.cd = 2;
                card.range = 2;
                card.speed = 4;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                card.special.armor = new int[6] { 1, 1, 1, 1, 1, 1 };
                break;

            case Card.Title.ElvenArcher:
                card.attack = new int[6] { 1, 2, 3, 3, 4, 5 };
                card.health = new int[6] { 4, 4, 4, 6, 7, 8 };
                card.cd = 2;
                card.range = 5;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                break;

            case Card.Title.ElvenFireApprentice:
                card.attack = new int[6] { 1, 1, 2, 2, 3, 3 };
                card.health = new int[6] { 1, 3, 3, 5, 5, 5 };
                card.cd = 1;
                card.range = 4;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Magical;
                card.special.ember = true;
                card.special.herosBane = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.ElvenFrostApprentice:
                card.attack = new int[6] { 1, 1, 1, 1, 1, 2 };
                card.health = new int[6] { 1, 2, 3, 4, 5, 6 };
                card.cd = 1;
                card.range = 4;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Magical;
                card.special.frostBolt = true;
                card.special.conjure = true;
                break;

            case Card.Title.ElvenGuard:
                card.attack = new int[6] { 1, 1, 2, 2, 3, 4 };
                card.health = new int[6] { 4, 5, 5, 7, 7, 9 };
                card.cd = 2;
                card.range = 3;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                card.special.spear = true;
                card.special.vigilance = true;
                break;

            case Card.Title.ElvenHunter:
                card.attack = new int[6] { 2, 3, 4, 5, 6, 8 };
                card.health = new int[6] { 1, 1, 2, 2, 3, 3 };
                card.cd = 3;
                card.range = 5;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                break;

            case Card.Title.ElvenSamurai:
                card.attack = new int[6] { 0, 1, 1, 2, 2, 3 };
                card.health = new int[6] { 5, 6, 8, 9, 12, 13 };
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                card.special.armor = new int[6] { 1, 1, 1, 1, 1, 1 };
                card.special.resistance = new int[6] { 1, 1, 2, 2, 3, 4 };
                break;

            case Card.Title.ElvenThunderApprentice:
                card.attack = new int[6] { 1, 1, 1, 2, 3, 3 };
                card.health = new int[6] { 1, 2, 4, 4, 4, 4 };
                card.cd = 2;
                card.range = 4;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Magical;
                card.special.stun = true;
                card.special.lightningBolt = new int[6] { 1, 1, 1, 2, 2, 3 };
                break;

            case Card.Title.ElvenWitch:
                card.attack = new int[6] { 1, 1, 1, 1, 2, 2 };
                card.health = new int[6] { 3, 4, 6, 8, 8, 8 };
                card.cd = 2;
                card.range = 4;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Magical;
                card.special.inspiration = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.FelesMessenger:
                card.attack = new int[6] { 1, 1, 1, 1, 2, 2 };
                card.health = new int[6] { 2, 3, 4, 6, 6, 9 };
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                card.special.distraction = true;
                break;

            case Card.Title.FelesTracker:
                card.attack = new int[6] { 1, 2, 2, 2, 3, 4 };
                card.health = new int[6] { 2, 2, 3, 5, 5, 6 };
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                card.special.distraction = true;
                card.special.hitAndRun = true;
                break;

            case Card.Title.Fencer:
                card.attack = new int[6] { 2, 2, 3, 3, 4, 5 };
                card.health = new int[6] { 3, 5, 5, 7, 7, 9 };
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                break;

            case Card.Title.FoulSkeleton:
                card.attack = new int[6] { 2, 2, 3, 3, 4, 5 };
                card.health = new int[6] { 2, 3, 3, 5, 6, 7 };
                card.cd = 3;
                card.range = 4;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                card.special.skeletal = true;
                break;

            case Card.Title.Ghost:
                card.attack = new int[6] { 1, 2, 2, 3, 3, 4 };
                card.health = new int[6] { 1, 1, 2, 2, 4, 5 };
                card.cd = 1;
                card.range = 4;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Magical;
                card.special.soulbound = true;
                card.special.frostBolt = true;
                break;

            case Card.Title.Guard:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                card.health = new int[6] { 4, 5, 5, 5, 7, 9 };
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                card.special.armor = new int[6] { 1, 1, 2, 2, 2, 3 };
                break;

            case Card.Title.HellHound:
                card.attack = new int[6] { 1, 1, 2, 2, 3, 4 };
                card.health = new int[6] { 4, 6, 6, 8, 8, 9 };
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Magical;
                card.special.ember = true;
                card.special.cleave = true;
                break;

            case Card.Title.Horseman:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                card.health = new int[6] { 6, 8, 10, 10, 12, 13 };
                card.cd = 1;
                card.range = 2;
                card.speed = 4;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                break;

            case Card.Title.HuntingDog:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                card.health = new int[6] { 4, 5, 6, 6, 7, 8 };
                card.cd = 1;
                card.range = 2;
                card.speed = 3;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                card.special.counterattack = true;
                break;

            case Card.Title.Lancer:
                card.attack = new int[6] { 0, 0, 1, 1, 2, 3 };
                card.health = new int[6] { 2, 3, 3, 5, 5, 6 };
                card.cd = 1;
                card.range = 2;
                card.speed = 4;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                card.special.charge = new int[6] { 1, 1, 1, 1, 1, 1 };
                break;

            case Card.Title.Lizard:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                card.health = new int[6] { 4, 6, 7, 8, 10, 12 };
                card.cd = 1;
                card.range = 1;
                card.speed = 1;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                card.special.armor = new int[6] { 1, 1, 2, 2, 2, 3 };
                card.special.headbutt = true;
                break;

            case Card.Title.Mercenary:
                card.attack = new int[6] { 1, 2, 3, 4, 5, 6 };
                card.health = new int[6] { 1, 1, 2, 3, 4, 5 };
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                card.special.influence = true;
                break;

            case Card.Title.PegasusRider:
                card.attack = new int[6] { 2, 2, 3, 3, 4, 5 };
                card.health = new int[6] { 3, 5, 5, 7, 7, 9 };
                card.cd = 2;
                card.range = 2;
                card.speed = 4;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                card.special.flying = true;
                break;

            case Card.Title.PegasusScout:
                card.attack = new int[6] { 1, 1, 2, 2, 3, 4 };
                card.health = new int[6] { 3, 4, 4, 6, 6, 7 };
                card.cd = 1;
                card.range = 2;
                card.speed = 4;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                card.special.flying = true;
                break;

            case Card.Title.Priest:
                card.attack = new int[6] { 0, 0, 0, 1, 1, 1 };
                card.health = new int[6] { 4, 6, 6, 7, 9, 11 };
                card.cd = 2;
                card.range = 4;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Magical;
                card.special.cure = new int[6] { 2, 2, 3, 3, 3, 4 };
                break;

            case Card.Title.Priestess:
                card.attack = new int[6] { 2, 3, 3, 4, 4, 5 };
                card.health = new int[6] { 5, 5, 7, 7, 10, 12 };
                card.cd = 3;
                card.range = 4;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Magical;
                break;

            case Card.Title.RepeatingCrossbow:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                card.health = new int[6] { 3, 5, 7, 7, 9, 10 };
                card.cd = 2;
                card.range = 4;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                card.special.multistrike = new int[6] { 1, 1, 1, 1, 1, 1 };
                break;

            case Card.Title.Squire:
                card.attack = new int[6] { 1, 1, 2, 2, 3, 4 };
                card.health = new int[6] { 4, 5, 5, 7, 7, 8 };
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                card.special.vigilance = true;
                break;

            case Card.Title.ThunderLizard:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                card.health = new int[6] { 5, 7, 10, 11, 14, 16 };
                card.cd = 2;
                card.range = 1;
                card.speed = 1;
                card.rarity = 1;
                card.damageType = Card.DamageType.Magical;
                card.special.stun = true;
                card.special.armor = new int[6] { 1, 1, 2, 2, 2, 3 };
                break;

            case Card.Title.Vampire:
                card.attack = new int[6] { 2, 2, 3, 3, 4, 5 };
                card.health = new int[6] { 5, 6, 6, 8, 8, 10 };
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                card.special.lifeSteal = true;
                break;

            case Card.Title.VampireApprentice:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                card.health = new int[6] { 6, 8, 10, 10, 12, 14 };
                card.cd = 2;
                card.range = 4;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Magical;
                card.special.lifeSteal = true;
                break;

            case Card.Title.VenomousBat:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                card.health = new int[6] { 4, 5, 5, 5, 7, 8 };
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                card.special.flying = true;
                card.special.poison = new int[6] { 1, 1, 2, 2, 2, 3 };
                break;

            case Card.Title.VileSkeleton:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                card.health = new int[6] { 2, 3, 4, 4, 6, 7 };
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                card.special.skeletal = true;
                break;

            case Card.Title.WerewolfHowler:
                card.attack = new int[6] { 3, 3, 4, 5, 6, 7 };
                card.health = new int[6] { 6, 8, 8, 9, 10, 12 };
                card.cd = 2;
                card.range = 2;
                card.speed = 3;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                card.special.bloodPrice = new int[6] { 1, 1, 1, 1, 1, 1 };
                break;

            case Card.Title.WerewolfIronclaw:
                card.attack = new int[6] { 2, 2, 2, 3, 3, 4 };
                card.health = new int[6] { 6, 8, 10, 10, 12, 14 };
                card.cd = 1;
                card.range = 2;
                card.speed = 3;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                card.special.bloodPrice = new int[6] { 1, 1, 1, 1, 1, 1 };
                break;

            case Card.Title.Wraith:
                card.attack = new int[6] { 2, 3, 4, 5, 6, 7 };
                card.health = new int[6] { 1, 1, 2, 3, 4, 5 };
                card.cd = 3;
                card.range = 4;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Magical;
                card.special.soulbound = true;
                card.special.shadowBolt = new int[6] { 2, 2, 2, 2, 2, 2 };
                break;

            case Card.Title.ZombieGuard:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                card.health = new int[6] { 2, 3, 4, 4, 5, 5 };
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                card.special.reanimate = true;
                card.special.armor = new int[6] { 1, 1, 1, 1, 1, 2 };
                card.special.donor = true;
                break;

            case Card.Title.ZombieSwordsman:
                card.attack = new int[6] { 2, 2, 2, 3, 3, 4 };
                card.health = new int[6] { 1, 2, 3, 3, 5, 5 };
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                card.special.reanimate = true;
                card.special.vigilance = true;
                break;

            case Card.Title.ArmouredLizard:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                card.health = new int[6] { 5, 6, 7, 8, 11, 13 };
                card.cd = 2;
                card.range = 1;
                card.speed = 1;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.armor = new int[6] { 1, 2, 3, 3, 3, 4 };
                card.special.headbutt = true;
                break;

            case Card.Title.BattlePriestess:
                card.attack = new int[6] { 0, 0, 1, 1, 2, 2 };
                card.health = new int[6] { 3, 5, 5, 7, 7, 9 };
                card.cd = 4;
                card.range = 4;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Magical;
                card.special.cure = new int[6] { 1, 1, 1, 1, 1, 2 };
                card.special.faith = true;
                break;

            case Card.Title.BlackRider:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                card.health = new int[6] { 6, 9, 12, 13, 14, 14 };
                card.cd = 4;
                card.range = 2;
                card.speed = 4;
                card.rarity = 2;
                card.damageType = Card.DamageType.Magical;
                card.special.armor = new int[6] { 1, 1, 1, 1, 1, 1 };
                card.special.spellFeed = new int[6] { 1, 1, 1, 1, 1, 2 };
                card.special.spellCurse = new int[6] { 1, 1, 1, 1, 2, 3 };
                break;

            case Card.Title.BlessedElvenSamurai:
                card.attack = new int[6] { 1, 1, 2, 2, 3, 3 };
                card.health = new int[6] { 6, 8, 8, 10, 10, 13 };
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.nimble = true;
                card.special.armor = new int[6] { 1, 1, 1, 1, 1, 1 };
                card.special.resistance = new int[6] { 1, 2, 3, 3, 4, 5 };
                break;

            case Card.Title.BloodthirstyBat:
                card.attack = new int[6] { 2, 2, 3, 3, 3, 4 };
                card.health = new int[6] { 4, 5, 5, 6, 8, 9 };
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.flying = true;
                card.special.lifeSteal = true;
                break;

            case Card.Title.CentaurGuerrilla:
                card.attack = new int[6] { 0, 0, 1, 1, 2, 2 };
                card.health = new int[6] { 4, 6, 7, 10, 12, 15 };
                card.cd = 3;
                card.range = 2;
                card.speed = 4;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.charge = new int[6] { 1, 1, 1, 1, 1, 1 };
                card.special.hitAndRun = true;
                break;

            case Card.Title.CentaurHunter:
                card.attack = new int[6] { 2, 3, 3, 4, 5, 6 };
                card.health = new int[6] { 5, 5, 7, 8, 9, 10 };
                card.cd = 4;
                card.range = 4;
                card.speed = 4;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.hitAndRun = true;
                break;

            case Card.Title.Cerberus:
                card.attack = new int[6] { 1, 2, 2, 3, 3, 4 };
                card.health = new int[6] { 7, 7, 9, 9, 11, 13 };
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.cleave = true;
                break;

            case Card.Title.ChillingGhost:
                card.attack = new int[6] { 1, 2, 2, 3, 4, 5 };
                card.health = new int[6] { 4, 4, 6, 7, 8, 9 };
                card.cd = 3;
                card.range = 4;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Magical;
                card.special.soulbound = true;
                card.special.frostBolt = true;
                break;

            case Card.Title.DreadKnight:
                card.attack = new int[6] { 1, 1, 2, 2, 3, 4 };
                card.health = new int[6] { 8, 11, 11, 11, 13, 15 };
                card.cd = 4;
                card.range = 2;
                card.speed = 4;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.armor = new int[6] { 1, 1, 1, 1, 1, 1 };
                card.special.soulEater = new int[6] { 1, 1, 1, 2, 2, 2 };
                break;

            case Card.Title.DreadWraith:
                card.attack = new int[6] { 3, 3, 3, 4, 5, 5 };
                card.health = new int[6] { 2, 3, 5, 5, 5, 5 };
                card.cd = 4;
                card.range = 4;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Magical;
                card.special.soulbound = true;
                card.special.shadowBolt = new int[6] { 2, 2, 2, 2, 2, 3 };
                card.special.fear = true;
                break;

            case Card.Title.ElvenFireMage:
                card.attack = new int[6] { 0, 1, 1, 2, 3, 3 };
                card.health = new int[6] { 1, 1, 2, 2, 2, 2 };
                card.cd = 2;
                card.range = 4;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Magical;
                card.special.ember = true;
                card.special.herosBane = new int[6] { 2, 2, 2, 2, 2, 3 };
                break;

            case Card.Title.ElvenFrostArchmage:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                card.health = new int[6] { 3, 5, 7, 7, 9, 10 };
                card.cd = 3;
                card.range = 4;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Magical;
                card.special.frostBolt = true;
                card.special.conjure = true;
                break;

            case Card.Title.ElvenLongbowArcher:
                card.attack = new int[6] { 1, 1, 2, 2, 3, 4 };
                card.health = new int[6] { 1, 2, 2, 3, 3, 3 };
                card.cd = 1;
                card.range = 6;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                break;

            case Card.Title.ElvenPraetorian:
                card.attack = new int[6] { 2, 2, 3, 3, 4, 5 };
                card.health = new int[6] { 4, 5, 5, 7, 7, 8 };
                card.cd = 3;
                card.range = 3;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.spear = true;
                card.special.vigilance = true;
                card.special.nimble = true;
                break;

            case Card.Title.ElvenPriestess:
                card.attack = new int[6] { 1, 1, 2, 2, 3, 3 };
                card.health = new int[6] { 5, 7, 7, 9, 9, 9 };
                card.cd = 3;
                card.range = 4;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Magical;
                card.special.inspiration = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.ElvenSniper:
                card.attack = new int[6] { 2, 2, 3, 3, 4, 5 };
                card.health = new int[6] { 1, 2, 2, 4, 4, 4 };
                card.cd = 2;
                card.range = 5;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.sniper = true;
                break;

            case Card.Title.ElvenThunderMage:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                card.health = new int[6] { 4, 4, 4, 6, 6, 8 };
                card.cd = 3;
                card.range = 4;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Magical;
                card.special.stun = true;
                card.special.lightningBolt = new int[6] { 1, 2, 2, 3, 3, 4 };
                break;

            case Card.Title.FelesAssassin:
                card.attack = new int[6] { 2, 2, 3, 4, 5, 6 };
                card.health = new int[6] { 4, 6, 6, 6, 7, 8 };
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.ambush = true;
                break;

            case Card.Title.FelesScout:
                card.attack = new int[6] { 1, 1, 2, 2, 3, 3 };
                card.health = new int[6] { 5, 6, 6, 7, 7, 9 };
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.distraction = true;
                break;

            case Card.Title.GrandFencer:
                card.attack = new int[6] { 2, 2, 2, 2, 2, 3 };
                card.health = new int[6] { 4, 6, 8, 10, 13, 14 };
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.counterattack = true;
                break;

            case Card.Title.HeavyCrossbowman:
                card.attack = new int[6] { 3, 3, 4, 4, 5, 6 };
                card.health = new int[6] { 9, 12, 13, 15, 17, 20 };
                card.cd = 4;
                card.range = 4;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.heavyWeapon = true;
                break;

            case Card.Title.HeavyRepeatingCrossbow:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                card.health = new int[6] { 4, 5, 7, 7, 9, 10 };
                card.cd = 3;
                card.range = 4;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.multistrike = new int[6] { 1, 1, 1, 1, 1, 1 };
                card.special.vigilance = true;
                break;

            case Card.Title.HighPriestess:
                card.attack = new int[6] { 0, 0, 1, 1, 2, 2 };
                card.health = new int[6] { 6, 8, 8, 10, 12, 14 };
                card.cd = 4;
                card.range = 4;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Magical;
                card.special.cure = new int[6] { 2, 2, 3, 4, 4, 5 };
                break;

            case Card.Title.Hound:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                card.health = new int[6] { 6, 8, 10, 10, 12, 13 };
                card.cd = 2;
                card.range = 2;
                card.speed = 3;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.counterattack = true;
                break;

            case Card.Title.Knight:
                card.attack = new int[6] { 1, 1, 1, 1, 2, 2 };
                card.health = new int[6] { 5, 7, 9, 11, 12, 12 };
                card.cd = 2;
                card.range = 2;
                card.speed = 4;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.heroic = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.LanceKnight:
                card.attack = new int[6] { 1, 1, 2, 2, 3, 4 };
                card.health = new int[6] { 6, 8, 8, 10, 10, 11 };
                card.cd = 2;
                card.range = 2;
                card.speed = 4;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.charge = new int[6] { 1, 1, 1, 1, 1, 1 };
                break;

            case Card.Title.MercenaryVeteran:
                card.attack = new int[6] { 3, 3, 4, 4, 4, 6 };
                card.health = new int[6] { 3, 5, 5, 7, 9, 9 };
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.influence = true;
                break;

            case Card.Title.Paladin:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                card.health = new int[6] { 3, 5, 7, 7, 9, 10 };
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.vigilance = true;
                card.special.cure = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.PegasusGuard:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                card.health = new int[6] { 3, 4, 5, 5, 5, 6 };
                card.cd = 1;
                card.range = 2;
                card.speed = 4;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.flying = true;
                card.special.regeneration = new int[6] { 1, 1, 1, 1, 2, 2 };
                break;

            case Card.Title.PegasusLegionnaire:
                card.attack = new int[6] { 2, 2, 3, 3, 3, 4 };
                card.health = new int[6] { 3, 4, 5, 7, 8, 9 };
                card.cd = 2;
                card.range = 2;
                card.speed = 4;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.flying = true;
                card.special.resistance = new int[6] { 1, 2, 2, 2, 3, 3 };
                break;

            case Card.Title.RottenSkeleton:
                card.attack = new int[6] { 1, 1, 2, 2, 2, 2 };
                card.health = new int[6] { 1, 2, 2, 2, 3, 3 };
                card.cd = 2;
                card.range = 4;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.skeletal = true;
                card.special.poison = new int[6] { 1, 1, 1, 2, 2, 3 };
                break;

            case Card.Title.SeniorThunderLizard:
                card.attack = new int[6] { 1, 1, 2, 2, 3, 3 };
                card.health = new int[6] { 7, 10, 12, 14, 15, 18 };
                card.cd = 4;
                card.range = 1;
                card.speed = 1;
                card.rarity = 2;
                card.damageType = Card.DamageType.Magical;
                card.special.stun = true;
                card.special.armor = new int[6] { 2, 2, 2, 3, 3, 4 };
                break;

            case Card.Title.Sentinel:
                card.attack = new int[6] { 2, 2, 2, 3, 3, 3 };
                card.health = new int[6] { 6, 8, 10, 10, 12, 14 };
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.armor = new int[6] { 2, 2, 2, 2, 2, 3 };
                break;

            case Card.Title.SepticBat:
                card.attack = new int[6] { 1, 1, 2, 2, 3, 3 };
                card.health = new int[6] { 6, 8, 8, 10, 11, 12 };
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.flying = true;
                card.special.poison = new int[6] { 2, 2, 2, 2, 2, 3 };
                break;

            case Card.Title.UnholySkeleton:
                card.attack = new int[6] { 1, 1, 2, 2, 3, 3 };
                card.health = new int[6] { 2, 3, 3, 3, 3, 4 };
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.skeletal = true;
                card.special.reapingCurse = new int[6] { 1, 1, 1, 2, 2, 3 };
                break;

            case Card.Title.VampireMage:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                card.health = new int[6] { 3, 4, 6, 6, 8, 8 };
                card.cd = 2;
                card.range = 4;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Magical;
                card.special.lifeSteal = true;
                card.special.weaken = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.VampireNoble:
                card.attack = new int[6] { 2, 3, 3, 4, 4, 5 };
                card.health = new int[6] { 8, 8, 10, 11, 14, 15 };
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.lifeSteal = true;
                break;

            case Card.Title.WerewolfProwler:
                card.attack = new int[6] { 3, 4, 5, 6, 7, 8 };
                card.health = new int[6] { 5, 5, 5, 5, 5, 5 };
                card.cd = 4;
                card.range = 2;
                card.speed = 3;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.bloodPrice = new int[6] { 1, 1, 1, 1, 1, 1 };
                card.special.carnivore = new int[6] { 1, 1, 2, 2, 3, 4 };
                break;

            case Card.Title.WerewolfSteelclaw:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                card.health = new int[6] { 6, 7, 8, 8, 10, 12 };
                card.cd = 3;
                card.range = 2;
                card.speed = 3;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.bloodPrice = new int[6] { 1, 1, 1, 1, 1, 1 };
                card.special.penetrate = true;
                card.special.maim = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.ZombieLegionnaire:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                card.health = new int[6] { 3, 4, 5, 5, 7, 7 };
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.reanimate = true;
                card.special.vigilance = true;
                card.special.regeneration = new int[6] { 1, 1, 2, 2, 2, 3 };
                break;

            case Card.Title.ZombieSentinel:
                card.attack = new int[6] { 1, 1, 2, 2, 3, 3 };
                card.health = new int[6] { 5, 7, 7, 9, 9, 11 };
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                card.special.reanimate = true;
                card.special.armor = new int[6] { 1, 1, 1, 1, 1, 2 };
                card.special.donor = true;
                break;

            case Card.Title.AegisLizard:
                card.attack = new int[6] { 2, 2, 2, 2, 2, 2 };
                card.health = new int[6] { 7, 9, 13, 16, 20, 23 };
                card.cd = 5;
                card.range = 1;
                card.speed = 1;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.armor = new int[6] { 2, 3, 3, 4, 4, 5 };
                card.special.knockback = new int[6] { 10, 10, 10, 10, 10, 10 };
                break;

            case Card.Title.BattleAbbess:
                card.attack = new int[6] { 0, 1, 1, 2, 2, 3 };
                card.health = new int[6] { 5, 5, 7, 7, 9, 11 };
                card.cd = 6;
                card.range = 4;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Magical;
                card.special.faith = true;
                card.special.cure = new int[6] { 2, 2, 2, 3, 3, 3 };
                break;

            case Card.Title.Captain:
                card.attack = new int[6] { 1, 2, 2, 2, 3, 4 };
                card.health = new int[6] { 7, 7, 10, 12, 13, 14 };
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.armor = new int[6] { 2, 2, 2, 3, 3, 4 };
                break;

            case Card.Title.CentaurGuerrillaLeader:
                card.attack = new int[6] { 1, 1, 2, 2, 0, 2 };
                card.health = new int[6] { 6, 8, 8, 10, 10, 10 };
                card.cd = 5;
                card.range = 2;
                card.speed = 4;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.charge = new int[6] { 1, 1, 1, 1, 2, 2 };
                card.special.hitAndRun = true;
                break;

            case Card.Title.CentaurMarksman:
                card.attack = new int[6] { 2, 2, 3, 3, 4, 5 };
                card.health = new int[6] { 2, 3, 3, 5, 5, 6 };
                card.cd = 2;
                card.range = 4;
                card.speed = 4;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.hitAndRun = true;
                break;

            case Card.Title.ChampionKnight:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                card.health = new int[6] { 6, 8, 8, 8, 10, 10 };
                card.cd = 3;
                card.range = 2;
                card.speed = 4;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.heroic = new int[6] { 1, 1, 2, 2, 2, 3 };
                break;

            case Card.Title.CrossbowCaptain:
                card.attack = new int[6] { 3, 4, 5, 6, 7, 8 };
                card.health = new int[6] { 8, 10, 12, 14, 16, 18 };
                card.cd = 6;
                card.range = 4;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.heavyWeapon = true;
                break;

            case Card.Title.DoomRider:
                card.attack = new int[6] { 2, 2, 2, 2, 3, 3 };
                card.health = new int[6] { 8, 9, 11, 12, 14, 14 };
                card.cd = 6;
                card.range = 2;
                card.speed = 4;
                card.rarity = 3;
                card.damageType = Card.DamageType.Magical;
                card.special.armor = new int[6] { 1, 1, 1, 1, 1, 1 };
                card.special.spellFeed = new int[6] { 1, 1, 1, 2, 2, 3 };
                card.special.spellCurse = new int[6] { 1, 2, 3, 3, 3, 4 };
                break;

            case Card.Title.DreadChampion:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                card.health = new int[6] { 7, 9, 9, 10, 13, 13 };
                card.cd = 5;
                card.range = 2;
                card.speed = 4;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.armor = new int[6] { 1, 1, 1, 1, 1, 1 };
                card.special.soulEater = new int[6] { 1, 1, 2, 2, 2, 3 };
                card.special.fear = true;
                break;

            case Card.Title.DreadPhantom:
                card.attack = new int[6] { 1, 1, 2, 2, 3, 3 };
                card.health = new int[6] { 4, 5, 5, 6, 7, 7 };
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.soulbound = true;
                card.special.incorporeal = true;
                card.special.fear = true;
                card.special.shadowBolt = new int[6] { 2, 2, 2, 2, 2, 3 };
                break;

            case Card.Title.ElvenFireArchmage:
                card.attack = new int[6] { 1, 2, 2, 3, 3, 4 };
                card.health = new int[6] { 3, 3, 4, 5, 6, 7 };
                card.cd = 3;
                card.range = 4;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Magical;
                card.special.ember = true;
                card.special.herosBane = new int[6] { 2, 2, 2, 2, 2, 3 };
                break;

            case Card.Title.ElvenFrostSorcerer:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                card.health = new int[6] { 7, 9, 11, 11, 13, 15 };
                card.cd = 4;
                card.range = 4;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Magical;
                card.special.frostBolt = true;
                card.special.conjure = true;
                break;

            case Card.Title.ElvenHighPriestess:
                card.attack = new int[6] { 0, 1, 1, 2, 2, 2 };
                card.health = new int[6] { 6, 6, 6, 6, 6, 6 };
                card.cd = 4;
                card.range = 4;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Magical;
                card.special.inspiration = new int[6] { 1, 1, 1, 1, 1, 2 };
                card.special.cure = new int[6] { 1, 1, 2, 2, 3, 4 };
                break;

            case Card.Title.ElvenLegionnaire:
                card.attack = new int[6] { 2, 2, 3, 3, 4, 5 };
                card.health = new int[6] { 6, 8, 8, 10, 11, 12 };
                card.cd = 4;
                card.range = 3;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.spear = true;
                card.special.vigilance = true;
                card.special.nimble = true;
                break;

            case Card.Title.ElvenMarksman:
                card.attack = new int[6] { 3, 3, 4, 4, 5, 6 };
                card.health = new int[6] { 1, 2, 2, 4, 4, 4 };
                card.cd = 3;
                card.range = 6;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                break;

            case Card.Title.ElvenRebel:
                card.attack = new int[6] { 1, 2, 2, 3, 3, 3 };
                card.health = new int[6] { 9, 9, 10, 11, 13, 15 };
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.nimble = true;
                card.special.armor = new int[6] { 1, 1, 1, 1, 1, 1 };
                card.special.resistance = new int[6] { 3, 3, 4, 4, 5, 6 };
                break;

            case Card.Title.ElvenSharpShooter:
                card.attack = new int[6] { 3, 3, 4, 4, 5, 6 };
                card.health = new int[6] { 3, 5, 5, 7, 7, 7 };
                card.cd = 4;
                card.range = 5;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.sniper = true;
                break;

            case Card.Title.ElvenThunderArchmage:
                card.attack = new int[6] { 1, 1, 1, 1, 1, 1 };
                card.health = new int[6] { 5, 5, 7, 7, 9, 10 };
                card.cd = 4;
                card.range = 4;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Magical;
                card.special.stun = true;
                card.special.lightningBolt = new int[6] { 2, 3, 3, 4, 4, 5 };
                break;

            case Card.Title.FelesAssassinMaster:
                card.attack = new int[6] { 3, 3, 4, 4, 5, 6 };
                card.health = new int[6] { 5, 7, 7, 9, 9, 9 };
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.ambush = true;
                card.special.penetrate = true;
                break;

            case Card.Title.FelesSwordsman:
                card.attack = new int[6] { 2, 2, 3, 3, 4, 5 };
                card.health = new int[6] { 3, 5, 5, 7, 7, 7 };
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.ambush = true;
                break;

            case Card.Title.FencingMaster:
                card.attack = new int[6] { 2, 2, 2, 3, 3, 4 };
                card.health = new int[6] { 8, 10, 12, 12, 14, 15 };
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.firstStrike = true;
                break;

            case Card.Title.FieryCerberus:
                card.attack = new int[6] { 2, 2, 2, 3, 3, 4 };
                card.health = new int[6] { 5, 6, 7, 7, 9, 10 };
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Magical;
                card.special.ember = true;
                card.special.vigilance = true;
                card.special.cleave = true;
                break;

            case Card.Title.FieryHound:
                card.attack = new int[6] { 0, 1, 1, 2, 2, 2 };
                card.health = new int[6] { 6, 6, 8, 8, 10, 10 };
                card.cd = 3;
                card.range = 2;
                card.speed = 3;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.counterattack = true;
                card.special.rage = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.HellishSkeleton:
                card.attack = new int[6] { 1, 1, 2, 2, 3, 4 };
                card.health = new int[6] { 1, 2, 2, 4, 4, 4 };
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.skeletal = true;
                card.special.reapingCurse = new int[6] { 2, 2, 2, 2, 2, 3 };
                break;

            case Card.Title.HolyMaster:
                card.attack = new int[6] { 0, 1, 1, 1, 1, 1 };
                card.health = new int[6] { 8, 8, 10, 11, 12, 13 };
                card.cd = 5;
                card.range = 4;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Magical;
                card.special.dispel = true;
                card.special.cure = new int[6] { 2, 2, 2, 3, 4, 5 };
                break;

            case Card.Title.IcyGaleGhost:
                card.attack = new int[6] { 1, 2, 3, 4, 5, 6 };
                card.health = new int[6] { 3, 4, 5, 6, 7, 8 };
                card.cd = 5;
                card.range = 4;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Magical;
                card.special.soulbound = true;
                card.special.knockback = new int[6] { 2, 2, 2, 2, 2, 2 };
                break;

            case Card.Title.LanceChampion:
                card.attack = new int[6] { 1, 2, 3, 4, 5, 6 };
                card.health = new int[6] { 6, 7, 8, 9, 10, 11 };
                card.cd = 4;
                card.range = 2;
                card.speed = 4;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.charge = new int[6] { 1, 1, 1, 1, 1, 1 };
                break;

            case Card.Title.MercenaryCaptain:
                card.attack = new int[6] { 2, 2, 2, 2, 2, 3 };
                card.health = new int[6] { 5, 6, 7, 9, 10, 10 };
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.whirlwind = true;
                card.special.influence = true;
                break;

            case Card.Title.PegasusChampion:
                card.attack = new int[6] { 2, 2, 2, 3, 3, 4 };
                card.health = new int[6] { 6, 7, 7, 7, 7, 7 };
                card.cd = 3;
                card.range = 2;
                card.speed = 4;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.flying = true;
                card.special.regeneration = new int[6] { 1, 1, 2, 2, 3, 4 };
                break;

            case Card.Title.PegasusRaidLeader:
                card.attack = new int[6] { 3, 3, 4, 4, 5, 6 };
                card.health = new int[6] { 4, 5, 5, 7, 7, 7 };
                card.cd = 4;
                card.range = 2;
                card.speed = 4;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.flying = true;
                card.special.resistance = new int[6] { 2, 3, 3, 3, 4, 5 };
                break;

            case Card.Title.PlaguedSkeleton:
                card.attack = new int[6] { 1, 2, 2, 3, 3, 3 };
                card.health = new int[6] { 1, 1, 2, 2, 3, 3 };
                card.cd = 4;
                card.range = 4;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.skeletal = true;
                card.special.poison = new int[6] { 3, 3, 3, 3, 3, 4 };
                break;

            case Card.Title.RepeatingCrossbowCaptain:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                card.health = new int[6] { 3, 5, 7, 7, 9, 9 };
                card.cd = 5;
                card.range = 4;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.multistrike = new int[6] { 1, 1, 1, 1, 1, 1 };
                card.special.vigilance = true;
                card.special.heroic = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.SawtoothThunderLizard:
                card.attack = new int[6] { 1, 1, 2, 2, 2, 3 };
                card.health = new int[6] { 10, 13, 15, 16, 21, 21 };
                card.cd = 6;
                card.range = 1;
                card.speed = 1;
                card.rarity = 3;
                card.damageType = Card.DamageType.Magical;
                card.special.stun = true;
                card.special.armor = new int[6] { 1, 2, 3, 4, 4, 5 };
                break;

            case Card.Title.ScarletBat:
                card.attack = new int[6] { 2, 2, 2, 3, 3, 4 };
                card.health = new int[6] { 8, 10, 12, 12, 14, 15 };
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.flying = true;
                card.special.bleedingAttack = true;
                card.special.lifeSteal = true;
                break;

            case Card.Title.SpitefulBat:
                card.attack = new int[6] { 1, 1, 2, 2, 3, 3 };
                card.health = new int[6] { 10, 12, 12, 14, 14, 14 };
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.flying = true;
                card.special.poison = new int[6] { 3, 3, 3, 3, 3, 4 };
                break;

            case Card.Title.Templar:
                card.attack = new int[6] { 1, 2, 2, 3, 3, 4 };
                card.health = new int[6] { 5, 5, 7, 7, 9, 10 };
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.vigilance = true;
                card.special.armor = new int[6] { 1, 1, 1, 1, 1, 2 };
                card.special.cure = new int[6] { 1, 1, 1, 2, 2, 2 };
                break;

            case Card.Title.VampireArchmage:
                card.attack = new int[6] { 1, 1, 1, 1, 1, 2 };
                card.health = new int[6] { 8, 9, 10, 11, 13, 13 };
                card.cd = 4;
                card.range = 4;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Magical;
                card.special.lifeSteal = true;
                card.special.weaken = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.VampireLord:
                card.attack = new int[6] { 3, 3, 3, 3, 3, 4 };
                card.health = new int[6] { 5, 7, 9, 9, 11, 13 };
                card.cd = 6;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.lifeSteal = true;
                card.special.weaken = new int[6] { 1, 1, 1, 2, 2, 2 };
                break;

            case Card.Title.WerewolfDeathclaw:
                card.attack = new int[6] { 2, 2, 2, 2, 2, 2 };
                card.health = new int[6] { 7, 9, 9, 11, 13, 13 };
                card.cd = 4;
                card.range = 2;
                card.speed = 3;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.bloodPrice = new int[6] { 1, 1, 1, 1, 1, 1 };
                card.special.penetrate = true;
                card.special.maim = new int[6] { 1, 1, 2, 2, 2, 3 };
                break;

            case Card.Title.WerewolfFleshripper:
                card.attack = new int[6] { 5, 6, 7, 8, 9, 10 };
                card.health = new int[6] { 3, 3, 4, 4, 5, 5 };
                card.cd = 6;
                card.range = 2;
                card.speed = 3;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.bloodPrice = new int[6] { 2, 2, 2, 2, 2, 2 };
                card.special.carnivore = new int[6] { 4, 5, 5, 6, 6, 7 };
                break;

            case Card.Title.ZombieCaptain:
                card.attack = new int[6] { 1, 1, 2, 2, 3, 4 };
                card.health = new int[6] { 6, 7, 8, 9, 10, 11 };
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.reanimate = true;
                card.special.armor = new int[6] { 2, 2, 2, 3, 3, 3 };
                card.special.donor = true;
                break;

            case Card.Title.ZombieChampion:
                card.attack = new int[6] { 2, 2, 3, 3, 3, 4 };
                card.health = new int[6] { 4, 5, 6, 7, 8, 9 };
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                card.special.reanimate = true;
                card.special.vigilance = true;
                card.special.regeneration = new int[6] { 1, 1, 1, 2, 3, 3 };
                break;

            case Card.Title.CainTheTraitor:
                card.attack = new int[6] { 1, 1, 2, 2, 3, 3 };
                card.health = new int[6] { 6, 8, 8, 10, 10, 12 };
                card.cd = 4;
                card.range = 4;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                card.special.skeletal = true;
                card.special.vengefulCurse = true;
                break;

            case Card.Title.CerberusHegemon:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                card.health = new int[6] { 9, 12, 15, 15, 18, 18 };
                card.cd = 6;
                card.range = 2;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Magical;
                card.special.ember = true;
                card.special.vigilance = true;
                card.special.cleave = true;
                card.special.rage = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.ChiefIronhide:
                card.attack = new int[6] { 0, 0, 0, 1, 1, 1 };
                card.health = new int[6] { 9, 12, 15, 15, 18, 18 };
                card.cd = 6;
                card.range = 1;
                card.speed = 1;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                card.special.armor = new int[6] { 3, 3, 3, 4, 4, 5 };
                card.special.armorAura = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.CrusaderLucanus:
                card.attack = new int[6] { 0, 0, 1, 1, 2, 2 };
                card.health = new int[6] { 6, 8, 8, 10, 12, 12 };
                card.cd = 6;
                card.range = 2;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                card.special.vigilance = true;
                card.special.cure = new int[6] { 1, 1, 2, 2, 2, 3 };
                card.special.lifeAura = new int[6] { 1, 1, 2, 2, 3, 4 };
                break;

            case Card.Title.DariusDarkhand:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                card.health = new int[6] { 4, 7, 10, 10, 13, 13 };
                card.cd = 2;
                card.range = 2;
                card.speed = 4;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                card.special.armor = new int[6] { 1, 1, 1, 1, 1, 1 };
                card.special.soulEater = new int[6] { 1, 1, 1, 2, 2, 3 };
                card.special.panicStrike = true;
                break;

            case Card.Title.DemonHunterAzrael:
                card.attack = new int[6] { 1, 1, 1, 1, 2, 2 };
                card.health = new int[6] { 2, 4, 6, 8, 8, 11 };
                card.cd = 5;
                card.range = 4;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                card.special.multistrike = new int[6] { 2, 2, 2, 2, 2, 2 };
                card.special.pierce = true;
                card.special.penetrate = true;
                break;

            case Card.Title.DesperateSoul:
                card.attack = new int[6] { 2, 2, 3, 3, 4, 4 };
                card.health = new int[6] { 4, 5, 6, 7, 8, 9 };
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                card.special.soulbound = true;
                card.special.incorporeal = true;
                card.special.resistance = new int[6] { 99, 99, 99, 99, 99, 99 };
                card.special.shadowBolt = new int[6] { 2, 2, 2, 2, 2, 3 };
                break;

            case Card.Title.EacannTheCharger:
                card.attack = new int[6] { 2, 2, 3, 3, 4, 5 };
                card.health = new int[6] { 8, 11, 11, 14, 14, 16 };
                card.cd = 5;
                card.range = 2;
                card.speed = 4;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                card.special.pierce = true;
                card.special.charge = new int[6] { 1, 1, 1, 1, 1, 1 };
                break;

            case Card.Title.FenrisTheButcher:
                card.attack = new int[6] { 4, 4, 5, 5, 6, 7 };
                card.health = new int[6] { 7, 10, 11, 14, 15, 15 };
                card.cd = 3;
                card.range = 2;
                card.speed = 3;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                card.special.bloodPrice = new int[6] { 2, 2, 2, 2, 2, 2 };
                card.special.rage = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.FirstRangerTalenor:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                card.health = new int[6] { 3, 5, 7, 7, 9, 9 };
                card.cd = 4;
                card.range = 6;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                card.special.rangeAura = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.KathrynEmberwind:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                card.health = new int[6] { 7, 9, 11, 11, 13, 13 };
                card.cd = 6;
                card.range = 4;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Magical;
                card.special.ember = true;
                card.special.immolate = new int[6] { 2, 2, 2, 2, 2, 3 };
                card.special.herosBane = new int[6] { 1, 1, 1, 1, 1, 2 };
                card.special.herosBaneAura = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.LuciusSwift:
                card.attack = new int[6] { 1, 2, 3, 4, 5, 6 };
                card.health = new int[6] { 1, 1, 1, 1, 1, 1 };
                card.cd = 1;
                card.range = 4;
                card.speed = 4;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                card.special.hitAndRun = true;
                break;

            case Card.Title.MifzunaTheWind:
                card.attack = new int[6] { 2, 2, 3, 3, 4, 5 };
                card.health = new int[6] { 3, 4, 4, 5, 5, 6 };
                card.cd = 3;
                card.range = 2;
                card.speed = 10;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                card.special.ambush = true;
                card.special.panicStrike = true;
                break;

            case Card.Title.OfeigurTheUndying:
                card.attack = new int[6] { 1, 2, 2, 3, 4, 5 };
                card.health = new int[6] { 8, 9, 11, 12, 14, 16 };
                card.cd = 6;
                card.range = 2;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                card.special.reanimate = true;
                card.special.martyrdom = true;
                card.special.ambush = true;
                break;

            case Card.Title.OpheliaWestWind:
                card.attack = new int[6] { 2, 2, 2, 3, 3, 3 };
                card.health = new int[6] { 6, 8, 10, 10, 12, 12 };
                card.cd = 4;
                card.range = 2;
                card.speed = 4;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                card.special.flying = true;
                card.special.flyingAura = true;
                card.special.resistance = new int[6] { 1, 1, 2, 2, 3, 4 };
                card.special.resistanceAura = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.PontiffFaol:
                card.attack = new int[6] { 1, 1, 1, 1, 1, 3 };
                card.health = new int[6] { 9, 11, 12, 13, 15, 15 };
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Magical;
                card.special.whirlwind = true;
                card.special.penetrate = true;
                card.special.martyrdom = true;
                card.special.regeneration = new int[6] { 1, 1, 2, 3, 3, 3 };
                break;

            case Card.Title.PrinceSerka:
                card.attack = new int[6] { 2, 2, 2, 2, 2, 3 };
                card.health = new int[6] { 7, 10, 11, 14, 15, 15 };
                card.cd = 7;
                card.range = 2;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                card.special.lifeSteal = true;
                card.special.counterattack = true;
                card.special.lifeAura = new int[6] { 1, 1, 2, 2, 3, 4 };
                break;

            case Card.Title.TanwenWildfire:
                card.attack = new int[6] { 3, 3, 4, 4, 5, 6 };
                card.health = new int[6] { 6, 8, 9, 14, 14, 17 };
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Magical;
                card.special.ember = true;
                card.special.herosBane = new int[6] { 2, 2, 2, 3, 3, 4 };
                card.special.immolate = new int[6] { 1, 1, 1, 2, 2, 3 };
                break;

            case Card.Title.VelynTheUnscarred:
                card.attack = new int[6] { 2, 2, 3, 3, 3, 4 };
                card.health = new int[6] { 7, 9, 10, 12, 15, 17 };
                card.cd = 4;
                card.range = 3;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                card.special.spear = true;
                card.special.nimble = true;
                card.special.resistance = new int[6] { 99, 99, 99, 99, 99, 99 };
                card.special.vigilance = true;
                break;

            case Card.Title.VirulentBatKing:
                card.attack = new int[6] { 1, 1, 1, 1, 1, 2 };
                card.health = new int[6] { 9, 10, 11, 12, 13, 14 };
                card.cd = 6;
                card.range = 2;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                card.special.flying = true;
                card.special.bleedingAttack = true;
                card.special.poison = new int[6] { 2, 3, 4, 5, 6, 7 };
                break;

            case Card.Title.WindDancerElke:
                card.attack = new int[6] { 1, 1, 1, 1, 1, 1 };
                card.health = new int[6] { 6, 8, 10, 12, 15, 15 };
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                card.special.whirlwind = true;
                card.special.penetrate = true;
                card.special.heroic = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.AryaTheHonorable:
                card.attack = new int[6] { 1, 1, 1, 1, 1, 1 };
                card.health = new int[6] { 10, 13, 13, 16, 19, 19 };
                card.cd = 7;
                card.range = 4;
                card.speed = 2;
                card.rarity = 5;
                card.damageType = Card.DamageType.Magical;
                card.special.regeneration = new int[6] { 2, 2, 3, 3, 3, 4 };
                card.special.regenerationAura = new int[6] { 1, 1, 2, 2, 2, 3 };
                break;

            case Card.Title.BigShuck:
                card.attack = new int[6] { 1, 1, 1, 1, 1, 1 };
                card.health = new int[6] { 6, 8, 10, 11, 12, 13 };
                card.cd = 3;
                card.range = 2;
                card.speed = 3;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                card.special.multistrike = new int[6] { 2, 2, 2, 3, 4, 5 };
                break;

            case Card.Title.ChieftainLionroar:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                card.health = new int[6] { 3, 5, 7, 7, 9, 9 };
                card.cd = 3;
                card.range = 2;
                card.speed = 4;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                card.special.hitAndRun = true;
                card.special.attackAura = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.DragonHunterVincent:
                card.attack = new int[6] { 4, 4, 5, 5, 6, 7 };
                card.health = new int[6] { 9, 11, 11, 13, 15, 17 };
                card.cd = 6;
                card.range = 4;
                card.speed = 2;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                card.special.heavyWeapon = true;
                card.special.knockback = new int[6] { 2, 2, 2, 2, 2, 2 };
                card.special.dragonSlayer = true;
                break;

            case Card.Title.EmperorAugustus:
                card.attack = new int[6] { 0, 1, 2, 3, 4, 5 };
                card.health = new int[6] { 8, 11, 14, 17, 20, 23 };
                card.cd = 8;
                card.range = 2;
                card.speed = 2;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                card.special.kingsCommand = true;
                break;

            case Card.Title.EmrysTheUnyielding:
                card.attack = new int[6] { 3, 3, 4, 4, 5, 6 };
                card.health = new int[6] { 12, 15, 16, 19, 21, 24 };
                card.cd = 7;
                card.range = 2;
                card.speed = 4;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                card.special.penetrate = true;
                card.special.combatMaster = true;
                break;

            case Card.Title.ExecutionerGrimbone:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                card.health = new int[6] { 5, 6, 7, 8, 9, 11 };
                card.cd = 6;
                card.range = 2;
                card.speed = 2;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                card.special.skeletal = true;
                card.special.reapingCurse = new int[6] { 2, 2, 2, 2, 3, 3 };
                card.special.resistance = new int[6] { 1, 1, 2, 2, 2, 3 };
                break;

            case Card.Title.Gringheist:
                card.attack = new int[6] { 1, 1, 1, 1, 1, 2 };
                card.health = new int[6] { 3, 4, 5, 6, 7, 8 };
                card.cd = 4;
                card.range = 4;
                card.speed = 2;
                card.rarity = 5;
                card.damageType = Card.DamageType.Magical;
                card.special.soulbound = true;
                card.special.frostBolt = true;
                card.special.incorporeal = true;
                card.special.blackIce = true;
                break;

            case Card.Title.JasmineTheDervish:
                card.attack = new int[6] { 1, 1, 1, 1, 1, 2 };
                card.health = new int[6] { 7, 9, 11, 13, 15, 15 };
                card.cd = 7;
                card.range = 2;
                card.speed = 2;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                card.special.whirlwind = true;
                card.special.firstStrike = true;
                card.special.cheif = true;
                card.special.influence = true;
                break;

            case Card.Title.KingVelAssar:
                card.attack = new int[6] { 1, 1, 2, 2, 3, 4 };
                card.health = new int[6] { 5, 7, 7, 9, 10, 11 };
                card.cd = 6;
                card.range = 10;
                card.speed = 2;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                card.special.multiShot = true;
                break;

            case Card.Title.LordFleder:
                card.attack = new int[6] { 0, 0, 1, 1, 1, 1 };
                card.health = new int[6] { 7, 9, 9, 11, 13, 13 };
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                card.special.flying = true;
                card.special.lifeSteal = true;
                card.special.battleSpirit = new int[6] { 1, 1, 1, 1, 1, 2 };
                card.special.bleedingAttack = true;
                break;

            case Card.Title.MaiaShadowblade:
                card.attack = new int[6] { 1, 1, 1, 2, 3, 3 };
                card.health = new int[6] { 1, 2, 3, 3, 3, 3 };
                card.cd = 1;
                card.range = 2;
                card.speed = 10;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                card.special.ambush = true;
                card.special.heroic = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.PrincessSarya:
                card.attack = new int[6] { 1, 1, 1, 1, 1, 2 };
                card.health = new int[6] { 4, 5, 6, 7, 8, 9 };
                card.cd = 7;
                card.range = 4;
                card.speed = 2;
                card.rarity = 5;
                card.damageType = Card.DamageType.Magical;
                card.special.lifeAbsorb = true;
                card.special.witheringAura = new int[6] { 1, 2, 3, 4, 5, 6 };
                break;

            case Card.Title.RyliTheWhiteWitch:
                card.attack = new int[6] { 1, 1, 1, 1, 1, 1 };
                card.health = new int[6] { 4, 6, 8, 10, 12, 14 };
                card.cd = 5;
                card.range = 4;
                card.speed = 2;
                card.rarity = 5;
                card.damageType = Card.DamageType.Magical;
                card.special.blizzardAura = true;
                card.special.frostBolt = true;
                break;

            case Card.Title.SilvaTheAlmighty:
                card.attack = new int[6] { 1, 1, 2, 2, 3, 3 };
                card.health = new int[6] { 7, 10, 10, 13, 13, 13 };
                card.cd = 7;
                card.range = 4;
                card.speed = 2;
                card.rarity = 5;
                card.damageType = Card.DamageType.Magical;
                card.special.stun = true;
                card.special.lightningBolt = new int[6] { 1, 1, 2, 2, 3, 4 };
                card.special.ember = true;
                card.special.thunderStorm = new int[6] { 1, 1, 1, 1, 1, 2 };
                card.special.herosBane = new int[6] { 1, 1, 1, 1, 1, 2 };
                card.special.frostBolt = true;
                card.special.conjure = true;
                break;

            case Card.Title.SorannTheUnforgiving:
                card.attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                card.health = new int[6] { 4, 6, 6, 7, 9, 9 };
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                card.special.vigilance = true;
                card.special.penetrate = true;
                card.special.nimble = true;
                card.special.disdain = new int[6] { 1, 1, 2, 2, 2, 3 };
                break;

            case Card.Title.StormLizardKing:
                card.attack = new int[6] { 1, 1, 1, 1, 1, 1 };
                card.health = new int[6] { 8, 10, 12, 14, 17, 20 };
                card.cd = 5;
                card.range = 1;
                card.speed = 1;
                card.rarity = 5;
                card.damageType = Card.DamageType.Magical;
                card.special.permaStun = true;
                card.special.armor = new int[6] { 1, 2, 3, 4, 4, 5 };
                break;

            case Card.Title.TarielThePhalanx:
                card.attack = new int[6] { 2, 2, 3, 3, 4, 5 };
                card.health = new int[6] { 8, 10, 11, 14, 15, 17 };
                card.cd = 5;
                card.range = 2;
                card.speed = 4;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                card.special.flying = true;
                card.special.nimble = true;
                card.special.reinforcement = true;
                break;

            case Card.Title.UndeadKingBael:
                card.attack = new int[6] { 0, 1, 2, 3, 4, 5 };
                card.health = new int[6] { 14, 16, 18, 20, 22, 24 };
                card.cd = 9;
                card.range = 2;
                card.speed = 2;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                card.special.callOfTheUndeadKing = true;
                break;

            case Card.Title.VarkusTheBlight:
                card.attack = new int[6] { 1, 1, 1, 1, 1, 2 };
                card.health = new int[6] { 4, 5, 6, 8, 10, 13 };
                card.cd = 7;
                card.range = 2;
                card.speed = 4;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                card.special.armor = new int[6] { 1, 1, 1, 1, 1, 1 };
                card.special.soulHarvest = true;
                break;

            case Card.Title.Whitemane:
                card.attack = new int[6] { 2, 2, 2, 3, 3, 4 };
                card.health = new int[6] { 5, 7, 9, 10, 13, 16 };
                card.cd = 4;
                card.range = 2;
                card.speed = 3;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                card.special.bloodPrice = new int[6] { 2, 2, 2, 2, 2, 2 };
                card.special.penetrate = true;
                card.special.penetrateAura = true;
                card.special.crushDefenses = true;
                break;



            case Card.Title.ArcaneCrystalTower:
                card.attack = new int[6] { 0, 0, 0, 0, 0, 0 };
                card.health = new int[6] { 15, 25, 35, 45, 60, 0 };
                card.cd = 4;
                card.range = 0;
                card.speed = 0;
                card.rarity = 0;
                card.damageType = Card.DamageType.Magical;
                card.special.wall = true;
                card.special.resistance = new int[6] { 1, 1, 1, 1, 3, 0};
                card.special.speedAura = new int[6] { 2, 2, 2, 2, 2, 0};
                break;

            case Card.Title.BoneWall:
                card.attack = new int[6] { 0, 0, 0, 0, 0, 0 };
                card.health = new int[6] { 15, 20, 25, 30, 50, 0 };
                card.cd = 4;
                card.range = 0;
                card.speed = 0;
                card.rarity = 0;
                card.damageType = Card.DamageType.Magical;
                card.special.wall = true;
                card.special.skeletal = true;
                break;

            case Card.Title.SentryTower:
                card.attack = new int[6] { 5, 6, 7, 8, 11, 0 };
                card.health = new int[6] { 10, 10, 10, 10, 15, 0 };
                card.cd = 4;
                card.range = 4;
                card.speed = 0;
                card.rarity = 0;
                card.damageType = Card.DamageType.Physical;
                card.special.wall = true;
                break;

            case Card.Title.WarTotem:
                card.attack = new int[6] { 0, 0, 0, 0, 0, 0 };
                card.health = new int[6] { 30, 35, 40, 45, 65, 0 };
                card.cd = 4;
                card.range = 0;
                card.speed = 0;
                card.rarity = 0;
                card.damageType = Card.DamageType.Physical;
                card.special.wall = true;
                card.special.inspiration = new int[6] { 1, 1, 1, 1, 3, 0 };
                card.special.distraction = true;
                break;

            case Card.Title.FlyerWall:
                card.attack = new int[6] { 0, 0, 0, 0, 0, 0 };
                card.health = new int[6] { 50, 60, 70, 80, 99, 0 };
                card.cd = 4;
                card.range = 0;
                card.speed = 0;
                card.rarity = 0;
                card.damageType = Card.DamageType.Magical;
                card.special.wall = true;
                card.special.flying = true;
                card.special.immolate = new int[6] { 4, 5, 6, 7, 8, 0 };
                card.special.regeneration = new int[6] { 0, 0, 0, 0, 3, 0 };
                break;



            case Card.Title.Null:
                card.attack = new int[6] { 10, 10, 10, 10, 10, 10 };
                card.health = new int[6] { 50, 50, 50, 50, 50, 50 };
                card.cd = 0;
                card.range = 2;
                card.speed = 2;
                card.rarity = 0;
                card.damageType = Card.DamageType.Physical;
                break;

            case Card.Title.BoneHeap:
                card.attack = new int[6] { 0, 0, 0, 0, 0, 0 };
                card.health = new int[6] { 1, 1, 1, 1, 1, 1 };
                card.cd = 0;
                card.range = 0;
                card.speed = 0;
                card.rarity = 0;
                card.damageType = Card.DamageType.Physical;
                card.special.boneHeap = true;
                break;

            case Card.Title.RaisedDead:
                card.attack = new int[6] { 0, 1, 1, 1, 2, 3 };
                card.health = new int[6] { 1, 1, 2, 3, 3, 4 };
                card.cd = 0;
                card.range = 2;
                card.speed = 2;
                card.rarity = 0;
                card.damageType = Card.DamageType.Physical;
                card.special.reanimate = true;
                break;
        }

        SetDefaults(card, title, alignment, rank);

        return card;
    }
}
