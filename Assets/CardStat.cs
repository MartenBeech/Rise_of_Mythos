using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardStat : MonoBehaviour
{
    private void SetDefaults(Card card, Card.Title title, Card.Alignment alignment, int rank)
    {
        card.title = title;
        card.cdDefault = card.cd;
        card.speedDefault = card.speed;
        card.rangeDefault = card.range;

        card.tile = Bf.SIZE;
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

    public Card GetStats(Card.Title title, Card.Alignment alignment, int rank = -1)
    {
        Card card = new Card();

        int[] attack = new int[6] { 0, 0, 0, 0, 0, 0 };
        int[] health = new int[6] { 0, 0, 0, 0, 0, 0 };

        bool wall = false;
         bool flying = false;

         bool vigilance = false;
         bool penetrate = false;

         int[] armor = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] resistance = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] charge = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] cure = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] heroic = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] regeneration = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] multistrike = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] weaken = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] shadowBolt = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] poison = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] poisoned = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] immolate = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] reapingCurse = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] soulEater = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] spellCurse = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] spellCursed = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] spellFeed = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] inspiration = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] herosBane = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] embered = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] lightningBolt = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] rage = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] carnivore = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] bloodPrice = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] maim = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] maimed = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] battleSpirit = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] knockback = new int[6] { 0, 0, 0, 0, 0, 0 };

         int[] lifeAura = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] regenerationAura = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] witheringAura = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] rangeAura = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] speedAura = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] attackAura = new int[6] { 0, 0, 0, 0, 0, 0 };
         bool blizzardAura = false;
         int[] herosBaneAura = new int[6] { 0, 0, 0, 0, 0, 0 };
         bool penetrateAura = false;
         int[] poisonAura = new int[6] { 0, 0, 0, 0, 0, 0 };
         int[] armorAura = new int[6] { 0, 0, 0, 0, 0, 0 };

         bool pierce = false;
         bool whirlwind = false;
         bool counterattack = false;
         bool firstStrike = false;
         bool dispel = false;
         bool faith = false;
         bool martyrdom = false;
         bool heavyWeapon = false;
         bool dragonSlayer = false;
         bool reanimate = false;
         bool lifeSteal = false;
         bool soulbound = false;
         bool frostBolt = false;
         bool incorporeal = false;
         bool fear = false;
         bool skeletal = false;
         bool boneHeap = false;
         bool vengefulCurse = false;
         bool vengefulCursed = false;
         bool panicStrike = false;
         bool sniper = false;
         bool ember = false;
         bool nimble = false;
         bool conjure = false;
         bool donor = false;
         bool stun = false;
         bool stunned = false;
         bool permaStun = false;
         bool distraction = false;
         bool spear = false;
         bool ambush = false;
         bool cleave = false;
         bool charm = false;
         bool hitAndRun = false;
         bool bleedingAttack = false;
         bool bleeding = false;
         bool influence = false;
         bool headbutt = false;

         bool kingsCommand = false;
         bool combatMaster = false;
         bool callOfTheUndeadKing = false;
         bool blackIce = false;
         bool soulHarvest = false;
         bool multiShot = false;
         bool reinforcement = false;
         int[] disdain = new int[6] { 0, 0, 0, 0, 0, 0 };
         bool crushDefenses = false;
         bool cheif = false;

         bool krush = false;
         int[] thunderStorm = new int[6] { 0, 0, 0, 0, 0, 0 };


        switch (title)
        {
            case Card.Title.Bat:
                attack = new int[6] { 1, 1, 2, 2, 2, 3 };
                health = new int[6] { 3, 5, 5, 7, 9, 11 };
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                flying = true;
                lifeSteal = true;
                break;

            case Card.Title.CentaurArcher:
                attack = new int[6] { 1, 1, 2, 2, 3, 4 };
                health = new int[6] { 1, 2, 2, 4, 4, 5 };
                card.cd = 1;
                card.range = 4;
                card.speed = 4;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                hitAndRun = true;
                break;

            case Card.Title.CentaurRider:
                attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                health = new int[6] { 3, 5, 7, 7, 9, 11 };
                card.cd = 1;
                card.range = 2;
                card.speed = 4;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                hitAndRun = true;
                break;

            case Card.Title.Crossbowman:
                attack = new int[6] { 2, 2, 3, 3, 4, 5 };
                health = new int[6] { 5, 7, 8, 10, 11, 14 };
                card.cd = 2;
                card.range = 4;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                heavyWeapon = true;
                break;

            case Card.Title.DarkRider:
                attack = new int[6] { 1, 2, 2, 2, 3, 3 };
                health = new int[6] { 7, 7, 7, 10, 11, 13 };
                card.cd = 3;
                card.range = 2;
                card.speed = 4;
                card.rarity = 1;
                card.damageType = Card.DamageType.Magical;
                armor = new int[6] { 1, 1, 1, 1, 1, 1 };
                spellCurse = new int[6] { 1, 1, 2, 2, 2, 3 };
                break;

            case Card.Title.DreadScout:
                attack = new int[6] { 1, 1, 2, 2, 3, 4 };
                health = new int[6] { 5, 7, 7, 9, 10, 12 };
                card.cd = 2;
                card.range = 2;
                card.speed = 4;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                armor = new int[6] { 1, 1, 1, 1, 1, 1 };
                break;

            case Card.Title.ElvenArcher:
                attack = new int[6] { 2, 2, 3, 3, 4, 5 };
                health = new int[6] { 3, 5, 5, 7, 7, 8 };
                card.cd = 2;
                card.range = 5;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                break;

            case Card.Title.ElvenFireApprentice:
                attack = new int[6] { 1, 1, 2, 2, 3, 3 };
                health = new int[6] { 1, 3, 3, 5, 5, 5 };
                card.cd = 1;
                card.range = 4;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Magical;
                ember = true;
                herosBane = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.ElvenFrostApprentice:
                attack = new int[6] { 0, 0, 1, 1, 1, 2 };
                health = new int[6] { 2, 3, 3, 4, 5, 6 };
                card.cd = 1;
                card.range = 4;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Magical;
                frostBolt = true;
                conjure = true;
                break;

            case Card.Title.ElvenGuard:
                attack = new int[6] { 1, 1, 2, 2, 3, 4 };
                health = new int[6] { 4, 5, 5, 7, 7, 9 };
                card.cd = 2;
                card.range = 3;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                spear = true;
                vigilance = true;
                break;

            case Card.Title.ElvenHunter:
                attack = new int[6] { 2, 3, 4, 5, 6, 8 };
                health = new int[6] { 3, 3, 3, 3, 3, 3 };
                card.cd = 3;
                card.range = 5;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                break;

            case Card.Title.ElvenSamurai:
                attack = new int[6] { 0, 1, 1, 2, 2, 2 };
                health = new int[6] { 7, 8, 9, 10, 12, 13 };
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                armor = new int[6] { 1, 1, 1, 1, 1, 1 };
                resistance = new int[6] { 1, 1, 2, 2, 3, 4 };
                break;

            case Card.Title.ElvenThunderApprentice:
                attack = new int[6] { 0, 1, 1, 2, 3, 3 };
                health = new int[6] { 2, 2, 4, 4, 4, 4 };
                card.cd = 2;
                card.range = 4;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Magical;
                stun = true;
                lightningBolt = new int[6] { 1, 1, 1, 2, 2, 3 };
                break;

            case Card.Title.ElvenWitch:
                attack = new int[6] { 0, 1, 1, 1, 2, 2 };
                health = new int[6] { 4, 4, 6, 8, 8, 8 };
                card.cd = 2;
                card.range = 4;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Magical;
                inspiration = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.FelesMessenger:
                attack = new int[6] { 0, 1, 1, 1, 2, 2 };
                health = new int[6] { 3, 3, 4, 6, 6, 9 };
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                distraction = true;
                break;

            case Card.Title.FelesTracker:
                attack = new int[6] { 1, 2, 2, 2, 3, 4 };
                health = new int[6] { 2, 2, 3, 5, 5, 6 };
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                distraction = true;
                hitAndRun = true;
                break;

            case Card.Title.Fencer:
                attack = new int[6] { 2, 2, 3, 3, 4, 5 };
                health = new int[6] { 3, 5, 5, 7, 7, 9 };
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                break;

            case Card.Title.FoulSkeleton:
                attack = new int[6] { 2, 2, 3, 3, 4, 5 };
                health = new int[6] { 2, 3, 3, 5, 6, 7 };
                card.cd = 3;
                card.range = 4;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                skeletal = true;
                break;

            case Card.Title.Ghost:
                attack = new int[6] { 1, 2, 2, 3, 3, 4 };
                health = new int[6] { 1, 1, 2, 2, 4, 5 };
                card.cd = 1;
                card.range = 4;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Magical;
                soulbound = true;
                frostBolt = true;
                break;

            case Card.Title.Guard:
                attack = new int[6] { 0, 1, 1, 2, 2, 2 };
                health = new int[6] { 4, 4, 4, 5, 7, 9 };
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                armor = new int[6] { 1, 1, 2, 2, 2, 3 };
                break;

            case Card.Title.HellHound:
                attack = new int[6] { 1, 1, 2, 2, 3, 4 };
                health = new int[6] { 4, 6, 6, 8, 8, 9 };
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Magical;
                ember = true;
                cleave = true;
                break;

            case Card.Title.Horseman:
                attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                health = new int[6] { 6, 8, 10, 10, 12, 13 };
                card.cd = 1;
                card.range = 2;
                card.speed = 4;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                break;

            case Card.Title.HuntingDog:
                attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                health = new int[6] { 3, 4, 5, 5, 7, 8 };
                card.cd = 1;
                card.range = 2;
                card.speed = 3;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                counterattack = true;
                break;

            case Card.Title.Lancer:
                attack = new int[6] { 0, 0, 1, 1, 2, 3 };
                health = new int[6] { 2, 3, 3, 5, 5, 6 };
                card.cd = 1;
                card.range = 2;
                card.speed = 4;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                charge = new int[6] { 1, 1, 1, 1, 1, 1 };
                break;

            case Card.Title.Lizard:
                attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                health = new int[6] { 5, 7, 8, 8, 10, 12 };
                card.cd = 1;
                card.range = 1;
                card.speed = 1;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                armor = new int[6] { 1, 1, 2, 2, 2, 3 };
                headbutt = true;
                break;

            case Card.Title.Mercenary:
                attack = new int[6] { 2, 2, 3, 4, 5, 6 };
                health = new int[6] { 2, 4, 4, 4, 4, 5 };
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                influence = true;
                break;

            case Card.Title.PegasusRider:
                attack = new int[6] { 2, 2, 3, 3, 4, 5 };
                health = new int[6] { 3, 5, 5, 7, 7, 9 };
                card.cd = 2;
                card.range = 2;
                card.speed = 4;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                flying = true;
                break;

            case Card.Title.PegasusScout:
                attack = new int[6] { 1, 1, 2, 2, 3, 4 };
                health = new int[6] { 3, 4, 4, 6, 6, 7 };
                card.cd = 1;
                card.range = 2;
                card.speed = 4;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                flying = true;
                break;

            case Card.Title.Priest:
                attack = new int[6] { 0, 0, 0, 1, 1, 1 };
                health = new int[6] { 4, 6, 6, 7, 9, 11 };
                card.cd = 2;
                card.range = 4;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Magical;
                cure = new int[6] { 2, 2, 3, 3, 3, 4 };
                break;

            case Card.Title.Priestess:
                attack = new int[6] { 3, 3, 3, 4, 4, 5 };
                health = new int[6] { 4, 6, 8, 8, 10, 12 };
                card.cd = 3;
                card.range = 4;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Magical;
                break;

            case Card.Title.RepeatingCrossbow:
                attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                health = new int[6] { 3, 5, 7, 7, 9, 10 };
                card.cd = 2;
                card.range = 4;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                multistrike = new int[6] { 1, 1, 1, 1, 1, 1 };
                break;

            case Card.Title.Squire:
                attack = new int[6] { 1, 1, 2, 2, 3, 4 };
                health = new int[6] { 4, 5, 5, 7, 7, 8 };
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                vigilance = true;
                break;

            case Card.Title.ThunderLizard:
                attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                health = new int[6] { 7, 9, 11, 12, 14, 16 };
                card.cd = 2;
                card.range = 1;
                card.speed = 1;
                card.rarity = 1;
                card.damageType = Card.DamageType.Magical;
                stun = true;
                armor = new int[6] { 1, 1, 2, 2, 2, 3 };
                break;

            case Card.Title.Vampire:
                attack = new int[6] { 2, 2, 3, 3, 4, 5 };
                health = new int[6] { 5, 6, 6, 8, 8, 10 };
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                lifeSteal = true;
                break;

            case Card.Title.VampireApprentice:
                attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                health = new int[6] { 6, 8, 10, 10, 12, 14 };
                card.cd = 2;
                card.range = 4;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Magical;
                lifeSteal = true;
                break;

            case Card.Title.VenomousBat:
                attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                health = new int[6] { 2, 3, 3, 3, 5, 6 };
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                flying = true;
                poison = new int[6] { 1, 1, 2, 2, 2, 3 };
                break;

            case Card.Title.VileSkeleton:
                attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                health = new int[6] { 2, 3, 4, 4, 6, 7 };
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                skeletal = true;
                break;

            case Card.Title.WerewolfHowler:
                attack = new int[6] { 3, 3, 4, 5, 6, 7 };
                health = new int[6] { 6, 8, 8, 9, 10, 12 };
                card.cd = 2;
                card.range = 2;
                card.speed = 3;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                bloodPrice = new int[6] { 1, 1, 1, 1, 1, 1 };
                break;

            case Card.Title.WerewolfIronclaw:
                attack = new int[6] { 2, 2, 2, 3, 3, 4 };
                health = new int[6] { 6, 8, 10, 10, 12, 14 };
                card.cd = 1;
                card.range = 2;
                card.speed = 3;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                bloodPrice = new int[6] { 1, 1, 1, 1, 1, 1 };
                break;

            case Card.Title.Wraith:
                attack = new int[6] { 2, 3, 4, 5, 6, 7 };
                health = new int[6] { 1, 1, 2, 3, 4, 5 };
                card.cd = 3;
                card.range = 4;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Magical;
                soulbound = true;
                shadowBolt = new int[6] { 2, 2, 2, 2, 2, 2 };
                break;

            case Card.Title.ZombieGuard:
                attack = new int[6] { 0, 1, 1, 2, 2, 3 };
                health = new int[6] { 3, 3, 4, 4, 5, 5 };
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                reanimate = true;
                armor = new int[6] { 1, 1, 1, 1, 1, 2 };
                donor = true;
                break;

            case Card.Title.ZombieSwordsman:
                attack = new int[6] { 2, 2, 2, 3, 3, 4 };
                health = new int[6] { 1, 2, 3, 3, 5, 5 };
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.rarity = 1;
                card.damageType = Card.DamageType.Physical;
                reanimate = true;
                vigilance = true;
                break;

            case Card.Title.ArmouredLizard:
                attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                health = new int[6] { 7, 9, 9, 9, 11, 13 };
                card.cd = 2;
                card.range = 1;
                card.speed = 1;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                armor = new int[6] { 2, 2, 3, 3, 3, 4 };
                headbutt = true;
                break;

            case Card.Title.BattlePriestess:
                attack = new int[6] { 0, 0, 1, 1, 2, 2 };
                health = new int[6] { 3, 5, 5, 7, 7, 9 };
                card.cd = 4;
                card.range = 4;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Magical;
                cure = new int[6] { 1, 1, 1, 1, 1, 2 };
                faith = true;
                break;

            case Card.Title.BlackRider:
                attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                health = new int[6] { 6, 9, 12, 13, 14, 14 };
                card.cd = 4;
                card.range = 2;
                card.speed = 4;
                card.rarity = 2;
                card.damageType = Card.DamageType.Magical;
                armor = new int[6] { 1, 1, 1, 1, 1, 1 };
                spellFeed = new int[6] { 1, 1, 1, 1, 1, 2 };
                spellCurse = new int[6] { 1, 1, 1, 1, 2, 3 };
                break;

            case Card.Title.BlessedElvenSamurai:
                attack = new int[6] { 1, 1, 2, 2, 3, 3 };
                health = new int[6] { 6, 8, 8, 10, 10, 13 };
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                nimble = true;
                armor = new int[6] { 1, 1, 1, 1, 1, 1 };
                resistance = new int[6] { 2, 2, 3, 3, 4, 5 };
                break;

            case Card.Title.BloodthirstyBat:
                attack = new int[6] { 2, 2, 3, 3, 3, 4 };
                health = new int[6] { 3, 4, 4, 5, 7, 8 };
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                flying = true;
                lifeSteal = true;
                break;

            case Card.Title.CentaurGuerrilla:
                attack = new int[6] { 0, 0, 1, 1, 2, 2 };
                health = new int[6] { 4, 7, 7, 10, 12, 15 };
                card.cd = 3;
                card.range = 2;
                card.speed = 4;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                charge = new int[6] { 1, 1, 1, 1, 1, 1 };
                hitAndRun = true;
                break;

            case Card.Title.CentaurHunter:
                attack = new int[6] { 2, 3, 3, 4, 5, 6 };
                health = new int[6] { 5, 5, 7, 8, 9, 10 };
                card.cd = 4;
                card.range = 4;
                card.speed = 4;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                hitAndRun = true;
                break;

            case Card.Title.Cerberus:
                attack = new int[6] { 1, 2, 2, 3, 3, 4 };
                health = new int[6] { 7, 7, 9, 9, 11, 13 };
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                cleave = true;
                break;

            case Card.Title.ChillingGhost:
                attack = new int[6] { 1, 2, 2, 3, 4, 5 };
                health = new int[6] { 4, 4, 6, 7, 8, 9 };
                card.cd = 3;
                card.range = 4;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Magical;
                soulbound = true;
                frostBolt = true;
                break;

            case Card.Title.DreadKnight:
                attack = new int[6] { 1, 1, 2, 2, 3, 4 };
                health = new int[6] { 8, 11, 11, 11, 13, 15 };
                card.cd = 4;
                card.range = 2;
                card.speed = 4;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                armor = new int[6] { 1, 1, 1, 1, 1, 1 };
                soulEater = new int[6] { 1, 1, 1, 2, 2, 2 };
                break;

            case Card.Title.DreadWraith:
                attack = new int[6] { 3, 3, 3, 4, 5, 5 };
                health = new int[6] { 2, 3, 5, 5, 5, 5 };
                card.cd = 4;
                card.range = 4;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Magical;
                soulbound = true;
                shadowBolt = new int[6] { 2, 2, 2, 2, 2, 3 };
                fear = true;
                break;

            case Card.Title.ElvenFireMage:
                attack = new int[6] { 0, 1, 1, 2, 3, 3 };
                health = new int[6] { 1, 1, 2, 2, 2, 2 };
                card.cd = 2;
                card.range = 4;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Magical;
                ember = true;
                herosBane = new int[6] { 1, 1, 2, 2, 2, 3 };
                break;

            case Card.Title.ElvenFrostArchmage:
                attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                health = new int[6] { 3, 5, 7, 7, 9, 10 };
                card.cd = 3;
                card.range = 4;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Magical;
                frostBolt = true;
                conjure = true;
                break;

            case Card.Title.ElvenLongbowArcher:
                attack = new int[6] { 1, 1, 2, 2, 3, 4 };
                health = new int[6] { 1, 2, 2, 3, 3, 3 };
                card.cd = 1;
                card.range = 6;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                break;

            case Card.Title.ElvenPraetorian:
                attack = new int[6] { 2, 2, 3, 3, 4, 5 };
                health = new int[6] { 4, 5, 5, 7, 7, 8 };
                card.cd = 3;
                card.range = 3;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                spear = true;
                vigilance = true;
                nimble = true;
                break;

            case Card.Title.ElvenPriestess:
                attack = new int[6] { 1, 1, 2, 2, 3, 3 };
                health = new int[6] { 5, 7, 7, 9, 9, 9 };
                card.cd = 3;
                card.range = 4;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Magical;
                inspiration = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.ElvenSniper:
                attack = new int[6] { 2, 2, 3, 3, 4, 5 };
                health = new int[6] { 1, 2, 2, 4, 4, 4 };
                card.cd = 2;
                card.range = 5;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                sniper = true;
                break;

            case Card.Title.ElvenThunderMage:
                attack = new int[6] { 0, 1, 1, 2, 2, 2 };
                health = new int[6] { 4, 4, 4, 4, 6, 8 };
                card.cd = 3;
                card.range = 4;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Magical;
                stun = true;
                lightningBolt = new int[6] { 1, 2, 3, 3, 3, 4 };
                break;

            case Card.Title.FelesAssassin:
                attack = new int[6] { 2, 2, 3, 4, 5, 6 };
                health = new int[6] { 4, 6, 6, 6, 7, 8 };
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                ambush = true;
                break;

            case Card.Title.FelesScout:
                attack = new int[6] { 1, 1, 2, 2, 3, 3 };
                health = new int[6] { 5, 6, 6, 7, 7, 9 };
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                distraction = true;
                break;

            case Card.Title.GrandFencer:
                attack = new int[6] { 2, 2, 2, 2, 2, 3 };
                health = new int[6] { 4, 6, 8, 10, 13, 14 };
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                counterattack = true;
                break;

            case Card.Title.HeavyCrossbowman:
                attack = new int[6] { 3, 3, 4, 4, 5, 6 };
                health = new int[6] { 9, 12, 13, 15, 17, 20 };
                card.cd = 4;
                card.range = 4;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                heavyWeapon = true;
                break;

            case Card.Title.HeavyRepeatingCrossbow:
                attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                health = new int[6] { 4, 5, 7, 7, 9, 10 };
                card.cd = 3;
                card.range = 4;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                multistrike = new int[6] { 1, 1, 1, 1, 1, 1 };
                vigilance = true;
                break;

            case Card.Title.HighPriestess:
                attack = new int[6] { 0, 0, 1, 1, 2, 2 };
                health = new int[6] { 6, 8, 8, 10, 12, 14 };
                card.cd = 4;
                card.range = 4;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Magical;
                cure = new int[6] { 2, 2, 3, 4, 4, 5 };
                break;

            case Card.Title.Hound:
                attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                health = new int[6] { 6, 8, 10, 10, 12, 13 };
                card.cd = 2;
                card.range = 2;
                card.speed = 3;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                counterattack = true;
                break;

            case Card.Title.Knight:
                attack = new int[6] { 1, 1, 1, 1, 2, 2 };
                health = new int[6] { 5, 7, 9, 11, 12, 12 };
                card.cd = 2;
                card.range = 2;
                card.speed = 4;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                heroic = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.LanceKnight:
                attack = new int[6] { 1, 1, 2, 2, 3, 4 };
                health = new int[6] { 6, 8, 8, 10, 10, 11 };
                card.cd = 2;
                card.range = 2;
                card.speed = 4;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                charge = new int[6] { 1, 1, 1, 1, 1, 1 };
                break;

            case Card.Title.MercenaryVeteran:
                attack = new int[6] { 3, 3, 4, 4, 4, 6 };
                health = new int[6] { 3, 5, 5, 7, 9, 9 };
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                influence = true;
                break;

            case Card.Title.Paladin:
                attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                health = new int[6] { 3, 5, 7, 7, 9, 10 };
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                vigilance = true;
                cure = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.PegasusGuard:
                attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                health = new int[6] { 3, 4, 5, 5, 5, 6 };
                card.cd = 1;
                card.range = 2;
                card.speed = 4;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                flying = true;
                regeneration = new int[6] { 1, 1, 1, 1, 2, 2 };
                break;

            case Card.Title.PegasusLegionnaire:
                attack = new int[6] { 2, 2, 3, 3, 3, 4 };
                health = new int[6] { 3, 4, 5, 7, 8, 9 };
                card.cd = 2;
                card.range = 2;
                card.speed = 4;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                flying = true;
                resistance = new int[6] { 1, 2, 2, 2, 3, 3 };
                break;

            case Card.Title.RottenSkeleton:
                attack = new int[6] { 1, 1, 2, 2, 2, 2 };
                health = new int[6] { 1, 2, 2, 2, 3, 3 };
                card.cd = 2;
                card.range = 4;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                skeletal = true;
                poison = new int[6] { 1, 1, 1, 2, 2, 3 };
                break;

            case Card.Title.SeniorThunderLizard:
                attack = new int[6] { 1, 1, 2, 2, 3, 3 };
                health = new int[6] { 10, 12, 13, 15, 15, 18 };
                card.cd = 4;
                card.range = 1;
                card.speed = 1;
                card.rarity = 2;
                card.damageType = Card.DamageType.Magical;
                stun = true;
                armor = new int[6] { 2, 2, 2, 3, 3, 4 };
                break;

            case Card.Title.Sentinel:
                attack = new int[6] { 2, 2, 2, 3, 3, 3 };
                health = new int[6] { 6, 8, 10, 10, 12, 14 };
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                armor = new int[6] { 2, 2, 2, 2, 2, 3 };
                break;

            case Card.Title.SepticBat:
                attack = new int[6] { 1, 1, 2, 2, 3, 3 };
                health = new int[6] { 4, 6, 6, 8, 9, 10 };
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                flying = true;
                poison = new int[6] { 2, 2, 2, 2, 2, 3 };
                break;

            case Card.Title.UnholySkeleton:
                attack = new int[6] { 1, 1, 2, 2, 3, 3 };
                health = new int[6] { 2, 3, 3, 3, 3, 4 };
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                skeletal = true;
                reapingCurse = new int[6] { 1, 1, 1, 2, 2, 3 };
                break;

            case Card.Title.VampireMage:
                attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                health = new int[6] { 3, 4, 6, 6, 8, 8 };
                card.cd = 2;
                card.range = 4;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Magical;
                lifeSteal = true;
                weaken = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.VampireNoble:
                attack = new int[6] { 3, 3, 3, 4, 4, 5 };
                health = new int[6] { 8, 10, 12, 12, 14, 15 };
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                lifeSteal = true;
                break;

            case Card.Title.WerewolfProwler:
                attack = new int[6] { 3, 4, 5, 6, 7, 8 };
                health = new int[6] { 5, 5, 5, 5, 5, 5 };
                card.cd = 4;
                card.range = 2;
                card.speed = 3;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                bloodPrice = new int[6] { 1, 1, 1, 1, 1, 1 };
                carnivore = new int[6] { 1, 1, 2, 2, 3, 4 };
                break;

            case Card.Title.WerewolfSteelclaw:
                attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                health = new int[6] { 6, 7, 8, 8, 10, 12 };
                card.cd = 3;
                card.range = 2;
                card.speed = 3;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                bloodPrice = new int[6] { 1, 1, 1, 1, 1, 1 };
                penetrate = true;
                maim = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.ZombieLegionnaire:
                attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                health = new int[6] { 3, 4, 5, 5, 7, 7 };
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                reanimate = true;
                vigilance = true;
                regeneration = new int[6] { 1, 1, 2, 2, 2, 3 };
                break;

            case Card.Title.ZombieSentinel:
                attack = new int[6] { 1, 1, 2, 2, 3, 3 };
                health = new int[6] { 5, 7, 7, 9, 9, 11 };
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.rarity = 2;
                card.damageType = Card.DamageType.Physical;
                reanimate = true;
                armor = new int[6] { 1, 1, 1, 1, 1, 2 };
                donor = true;
                break;

            case Card.Title.AegisLizard:
                attack = new int[6] { 2, 2, 2, 2, 2, 2 };
                health = new int[6] { 8, 11, 14, 17, 20, 23 };
                card.cd = 5;
                card.range = 1;
                card.speed = 1;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                armor = new int[6] { 2, 3, 3, 4, 4, 5 };
                knockback = new int[6] { 10, 10, 10, 10, 10, 10 };
                break;

            case Card.Title.BattleAbbess:
                attack = new int[6] { 0, 1, 1, 2, 2, 3 };
                health = new int[6] { 5, 5, 7, 7, 9, 11 };
                card.cd = 6;
                card.range = 4;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Magical;
                faith = true;
                cure = new int[6] { 2, 2, 2, 3, 3, 3 };
                break;

            case Card.Title.Captain:
                attack = new int[6] { 1, 2, 2, 2, 3, 4 };
                health = new int[6] { 7, 7, 10, 12, 13, 14 };
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                armor = new int[6] { 2, 2, 2, 3, 3, 4 };
                break;

            case Card.Title.CentaurGuerrillaLeader:
                attack = new int[6] { 2, 2, 2, 2, 0, 2 };
                health = new int[6] { 6, 7, 8, 10, 10, 10 };
                card.cd = 5;
                card.range = 2;
                card.speed = 4;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                charge = new int[6] { 1, 1, 1, 1, 2, 2 };
                hitAndRun = true;
                break;

            case Card.Title.CentaurMarksman:
                attack = new int[6] { 2, 2, 3, 3, 4, 5 };
                health = new int[6] { 2, 3, 3, 5, 5, 6 };
                card.cd = 2;
                card.range = 4;
                card.speed = 4;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                hitAndRun = true;
                break;

            case Card.Title.ChampionKnight:
                attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                health = new int[6] { 6, 8, 8, 8, 10, 10 };
                card.cd = 3;
                card.range = 2;
                card.speed = 4;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                heroic = new int[6] { 1, 1, 2, 2, 2, 3 };
                break;

            case Card.Title.CrossbowCaptain:
                attack = new int[6] { 3, 4, 5, 6, 7, 8 };
                health = new int[6] { 8, 10, 12, 14, 16, 18 };
                card.cd = 6;
                card.range = 4;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                heavyWeapon = true;
                break;

            case Card.Title.DoomRider:
                attack = new int[6] { 2, 2, 2, 2, 3, 3 };
                health = new int[6] { 8, 10, 11, 12, 14, 14 };
                card.cd = 6;
                card.range = 2;
                card.speed = 4;
                card.rarity = 3;
                card.damageType = Card.DamageType.Magical;
                armor = new int[6] { 1, 1, 1, 1, 1, 1 };
                spellFeed = new int[6] { 1, 1, 1, 2, 2, 3 };
                spellCurse = new int[6] { 2, 2, 3, 3, 3, 4 };
                break;

            case Card.Title.DreadChampion:
                attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                health = new int[6] { 7, 9, 9, 10, 13, 13 };
                card.cd = 5;
                card.range = 2;
                card.speed = 4;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                armor = new int[6] { 1, 1, 1, 1, 1, 1 };
                soulEater = new int[6] { 1, 1, 2, 2, 2, 3 };
                fear = true;
                break;

            case Card.Title.DreadPhantom:
                attack = new int[6] { 1, 1, 2, 2, 3, 3 };
                health = new int[6] { 4, 5, 5, 6, 7, 7 };
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                soulbound = true;
                incorporeal = true;
                fear = true;
                shadowBolt = new int[6] { 2, 2, 2, 2, 2, 3 };
                break;

            case Card.Title.ElvenFireArchmage:
                attack = new int[6] { 1, 2, 2, 3, 3, 4 };
                health = new int[6] { 3, 3, 4, 5, 6, 7 };
                card.cd = 3;
                card.range = 4;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Magical;
                ember = true;
                herosBane = new int[6] { 2, 2, 2, 2, 2, 3 };
                break;

            case Card.Title.ElvenFrostSorcerer:
                attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                health = new int[6] { 7, 9, 11, 11, 13, 15 };
                card.cd = 4;
                card.range = 4;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Magical;
                frostBolt = true;
                conjure = true;
                break;

            case Card.Title.ElvenHighPriestess:
                attack = new int[6] { 0, 1, 1, 2, 2, 2 };
                health = new int[6] { 6, 6, 6, 6, 6, 6 };
                card.cd = 4;
                card.range = 4;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Magical;
                inspiration = new int[6] { 1, 1, 1, 1, 1, 2 };
                cure = new int[6] { 1, 1, 2, 2, 3, 4 };
                break;

            case Card.Title.ElvenLegionnaire:
                attack = new int[6] { 2, 2, 3, 3, 4, 5 };
                health = new int[6] { 6, 8, 8, 10, 11, 12 };
                card.cd = 4;
                card.range = 3;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                spear = true;
                vigilance = true;
                nimble = true;
                break;

            case Card.Title.ElvenMarksman:
                attack = new int[6] { 3, 3, 4, 4, 5, 6 };
                health = new int[6] { 1, 2, 2, 4, 4, 4 };
                card.cd = 3;
                card.range = 6;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                break;

            case Card.Title.ElvenRebel:
                attack = new int[6] { 1, 2, 2, 3, 3, 3 };
                health = new int[6] { 9, 9, 10, 11, 13, 15 };
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                nimble = true;
                armor = new int[6] { 1, 1, 1, 1, 1, 1 };
                resistance = new int[6] { 3, 3, 4, 4, 5, 6 };
                break;

            case Card.Title.ElvenSharpShooter:
                attack = new int[6] { 3, 3, 4, 4, 5, 6 };
                health = new int[6] { 3, 5, 5, 7, 7, 7 };
                card.cd = 4;
                card.range = 5;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                sniper = true;
                break;

            case Card.Title.ElvenThunderArchmage:
                attack = new int[6] { 1, 1, 1, 1, 1, 1 };
                health = new int[6] { 5, 5, 7, 7, 9, 10 };
                card.cd = 4;
                card.range = 4;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Magical;
                stun = true;
                lightningBolt = new int[6] { 2, 3, 3, 4, 4, 5 };
                break;

            case Card.Title.FelesAssassinMaster:
                attack = new int[6] { 3, 3, 4, 4, 5, 6 };
                health = new int[6] { 5, 7, 7, 9, 9, 9 };
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                ambush = true;
                penetrate = true;
                break;

            case Card.Title.FelesSwordsman:
                attack = new int[6] { 2, 2, 3, 3, 4, 5 };
                health = new int[6] { 3, 5, 5, 7, 7, 7 };
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                ambush = true;
                break;

            case Card.Title.FencingMaster:
                attack = new int[6] { 2, 2, 2, 3, 3, 4 };
                health = new int[6] { 8, 10, 12, 12, 14, 15 };
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                firstStrike = true;
                break;

            case Card.Title.FieryCerberus:
                attack = new int[6] { 2, 2, 2, 3, 3, 4 };
                health = new int[6] { 5, 6, 7, 7, 9, 10 };
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Magical;
                ember = true;
                vigilance = true;
                cleave = true;
                break;

            case Card.Title.FieryHound:
                attack = new int[6] { 0, 1, 1, 2, 2, 2 };
                health = new int[6] { 6, 6, 8, 8, 10, 10 };
                card.cd = 3;
                card.range = 2;
                card.speed = 3;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                counterattack = true;
                rage = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.HellishSkeleton:
                attack = new int[6] { 1, 1, 2, 2, 3, 4 };
                health = new int[6] { 1, 2, 2, 4, 4, 4 };
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                skeletal = true;
                reapingCurse = new int[6] { 2, 2, 2, 2, 2, 3 };
                break;

            case Card.Title.HolyMaster:
                attack = new int[6] { 0, 1, 1, 1, 1, 1 };
                health = new int[6] { 8, 8, 10, 11, 12, 13 };
                card.cd = 5;
                card.range = 4;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Magical;
                dispel = true;
                cure = new int[6] { 2, 2, 2, 3, 4, 5 };
                break;

            case Card.Title.IcyGaleGhost:
                attack = new int[6] { 1, 2, 3, 4, 5, 6 };
                health = new int[6] { 3, 4, 5, 6, 7, 8 };
                card.cd = 5;
                card.range = 4;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Magical;
                soulbound = true;
                knockback = new int[6] { 2, 2, 2, 2, 2, 2 };
                break;

            case Card.Title.LanceChampion:
                attack = new int[6] { 1, 2, 3, 4, 5, 6 };
                health = new int[6] { 6, 7, 8, 9, 10, 11 };
                card.cd = 4;
                card.range = 2;
                card.speed = 4;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                charge = new int[6] { 1, 1, 1, 1, 1, 1 };
                break;

            case Card.Title.MercenaryCaptain:
                attack = new int[6] { 2, 2, 2, 2, 2, 3 };
                health = new int[6] { 5, 6, 7, 9, 10, 10 };
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                whirlwind = true;
                influence = true;
                break;

            case Card.Title.PegasusChampion:
                attack = new int[6] { 2, 2, 2, 3, 3, 4 };
                health = new int[6] { 6, 7, 7, 7, 7, 7 };
                card.cd = 3;
                card.range = 2;
                card.speed = 4;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                flying = true;
                regeneration = new int[6] { 1, 1, 2, 2, 3, 4 };
                break;

            case Card.Title.PegasusRaidLeader:
                attack = new int[6] { 3, 3, 4, 4, 5, 6 };
                health = new int[6] { 4, 5, 5, 7, 7, 7 };
                card.cd = 4;
                card.range = 2;
                card.speed = 4;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                flying = true;
                resistance = new int[6] { 2, 3, 3, 3, 4, 5 };
                break;

            case Card.Title.PlaguedSkeleton:
                attack = new int[6] { 1, 2, 2, 3, 3, 3 };
                health = new int[6] { 1, 1, 2, 2, 3, 3 };
                card.cd = 4;
                card.range = 4;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                skeletal = true;
                poison = new int[6] { 3, 3, 3, 3, 3, 4 };
                break;

            case Card.Title.RepeatingCrossbowCaptain:
                attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                health = new int[6] { 3, 5, 7, 7, 9, 9 };
                card.cd = 5;
                card.range = 4;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                multistrike = new int[6] { 1, 1, 1, 1, 1, 1 };
                vigilance = true;
                heroic = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.SawtoothThunderLizard:
                attack = new int[6] { 1, 1, 2, 2, 2, 3 };
                health = new int[6] { 13, 16, 17, 18, 21, 21 };
                card.cd = 6;
                card.range = 1;
                card.speed = 1;
                card.rarity = 3;
                card.damageType = Card.DamageType.Magical;
                stun = true;
                armor = new int[6] { 3, 3, 3, 4, 4, 5 };
                break;

            case Card.Title.ScarletBat:
                attack = new int[6] { 2, 2, 2, 3, 3, 4 };
                health = new int[6] { 7, 9, 11, 11, 13, 14 };
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                flying = true;
                bleedingAttack = true;
                lifeSteal = true;
                break;

            case Card.Title.SpitefulBat:
                attack = new int[6] { 1, 1, 2, 2, 3, 3 };
                health = new int[6] { 8, 10, 10, 12, 12, 12 };
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                flying = true;
                poison = new int[6] { 3, 3, 3, 3, 3, 4 };
                break;

            case Card.Title.Templar:
                attack = new int[6] { 1, 2, 2, 3, 3, 4 };
                health = new int[6] { 5, 5, 7, 7, 9, 10 };
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                vigilance = true;
                armor = new int[6] { 1, 1, 1, 1, 1, 2 };
                cure = new int[6] { 1, 1, 1, 2, 2, 2 };
                break;

            case Card.Title.VampireArchmage:
                attack = new int[6] { 1, 1, 1, 1, 1, 2 };
                health = new int[6] { 8, 9, 10, 11, 13, 13 };
                card.cd = 4;
                card.range = 4;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Magical;
                lifeSteal = true;
                weaken = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.VampireLord:
                attack = new int[6] { 3, 3, 3, 3, 3, 4 };
                health = new int[6] { 5, 7, 9, 9, 11, 13 };
                card.cd = 6;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                lifeSteal = true;
                weaken = new int[6] { 1, 1, 1, 2, 2, 2 };
                break;

            case Card.Title.WerewolfDeathclaw:
                attack = new int[6] { 2, 2, 2, 2, 2, 2 };
                health = new int[6] { 7, 9, 9, 11, 13, 13 };
                card.cd = 4;
                card.range = 2;
                card.speed = 3;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                bloodPrice = new int[6] { 1, 1, 1, 1, 1, 1 };
                penetrate = true;
                maim = new int[6] { 1, 1, 2, 2, 2, 3 };
                break;

            case Card.Title.WerewolfFleshripper:
                attack = new int[6] { 5, 6, 7, 8, 9, 10 };
                health = new int[6] { 3, 3, 4, 4, 5, 5 };
                card.cd = 6;
                card.range = 2;
                card.speed = 3;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                bloodPrice = new int[6] { 2, 2, 2, 2, 2, 2 };
                carnivore = new int[6] { 4, 5, 5, 6, 6, 7 };
                break;

            case Card.Title.ZombieCaptain:
                attack = new int[6] { 1, 1, 2, 2, 3, 4 };
                health = new int[6] { 6, 7, 8, 9, 10, 11 };
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                reanimate = true;
                armor = new int[6] { 2, 2, 2, 3, 3, 3 };
                donor = true;
                break;

            case Card.Title.ZombieChampion:
                attack = new int[6] { 2, 2, 3, 3, 3, 4 };
                health = new int[6] { 4, 5, 6, 7, 8, 9 };
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.rarity = 3;
                card.damageType = Card.DamageType.Physical;
                reanimate = true;
                vigilance = true;
                regeneration = new int[6] { 1, 1, 1, 2, 3, 3 };
                break;

            case Card.Title.CainTheTraitor:
                attack = new int[6] { 1, 1, 2, 2, 3, 3 };
                health = new int[6] { 6, 8, 8, 10, 10, 12 };
                card.cd = 4;
                card.range = 4;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                skeletal = true;
                vengefulCurse = true;
                break;

            case Card.Title.CerberusHegemon:
                attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                health = new int[6] { 9, 12, 15, 15, 18, 18 };
                card.cd = 6;
                card.range = 2;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Magical;
                ember = true;
                vigilance = true;
                cleave = true;
                rage = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.ChiefIronhide:
                attack = new int[6] { 0, 0, 0, 1, 1, 1 };
                health = new int[6] { 9, 12, 15, 15, 18, 18 };
                card.cd = 6;
                card.range = 1;
                card.speed = 1;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                armor = new int[6] { 3, 3, 3, 4, 4, 5 };
                armorAura = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.CrusaderLucanus:
                attack = new int[6] { 0, 0, 1, 1, 2, 2 };
                health = new int[6] { 6, 8, 8, 10, 12, 12 };
                card.cd = 6;
                card.range = 2;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                vigilance = true;
                cure = new int[6] { 1, 1, 2, 2, 2, 3 };
                lifeAura = new int[6] { 1, 1, 2, 2, 3, 4 };
                break;

            case Card.Title.DariusDarkhand:
                attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                health = new int[6] { 4, 7, 10, 10, 13, 13 };
                card.cd = 2;
                card.range = 2;
                card.speed = 4;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                armor = new int[6] { 1, 1, 1, 1, 1, 1 };
                soulEater = new int[6] { 1, 1, 1, 2, 2, 3 };
                panicStrike = true;
                break;

            case Card.Title.DemonHunterAzrael:
                attack = new int[6] { 1, 1, 1, 1, 2, 2 };
                health = new int[6] { 2, 4, 6, 8, 8, 11 };
                card.cd = 5;
                card.range = 4;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                multistrike = new int[6] { 2, 2, 2, 2, 2, 2 };
                pierce = true;
                penetrate = true;
                break;

            case Card.Title.DesperateSoul:
                attack = new int[6] { 2, 2, 3, 3, 4, 4 };
                health = new int[6] { 4, 5, 6, 7, 8, 9 };
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                soulbound = true;
                incorporeal = true;
                resistance = new int[6] { 99, 99, 99, 99, 99, 99 };
                shadowBolt = new int[6] { 2, 2, 2, 2, 2, 3 };
                break;

            case Card.Title.EacannTheCharger:
                attack = new int[6] { 2, 2, 3, 3, 4, 5 };
                health = new int[6] { 8, 11, 11, 14, 14, 16 };
                card.cd = 5;
                card.range = 2;
                card.speed = 4;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                pierce = true;
                penetrate = true;
                charge = new int[6] { 1, 1, 1, 1, 1, 1 };
                break;

            case Card.Title.FenrisTheButcher:
                attack = new int[6] { 4, 4, 5, 5, 6, 7 };
                health = new int[6] { 7, 10, 11, 14, 15, 15 };
                card.cd = 3;
                card.range = 2;
                card.speed = 3;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                bloodPrice = new int[6] { 2, 2, 2, 2, 2, 2 };
                rage = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.FirstRangerTalenor:
                attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                health = new int[6] { 3, 5, 7, 7, 9, 9 };
                card.cd = 4;
                card.range = 6;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                rangeAura = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.KathrynEmberwind:
                attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                health = new int[6] { 7, 9, 11, 11, 13, 13 };
                card.cd = 6;
                card.range = 4;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Magical;
                ember = true;
                immolate = new int[6] { 2, 2, 2, 2, 2, 3 };
                herosBane = new int[6] { 1, 1, 1, 1, 1, 2 };
                herosBaneAura = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.LuciusSwift:
                attack = new int[6] { 1, 2, 3, 4, 5, 6 };
                health = new int[6] { 1, 1, 1, 1, 1, 1 };
                card.cd = 1;
                card.range = 4;
                card.speed = 4;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                hitAndRun = true;
                break;

            case Card.Title.MifzunaTheWind:
                attack = new int[6] { 2, 2, 3, 3, 4, 5 };
                health = new int[6] { 3, 4, 4, 5, 5, 6 };
                card.cd = 3;
                card.range = 2;
                card.speed = 10;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                ambush = true;
                panicStrike = true;
                break;

            case Card.Title.OfeigurTheUndying:
                attack = new int[6] { 1, 1, 2, 2, 3, 4 };
                health = new int[6] { 8, 10, 10, 10, 10, 11 };
                card.cd = 6;
                card.range = 2;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                reanimate = true;
                martyrdom = true;
                vigilance = true;
                ambush = true;
                regeneration = new int[6] { 2, 2, 2, 3, 3, 3 };
                break;

            case Card.Title.OpheliaWestWind:
                attack = new int[6] { 2, 2, 2, 2, 2, 2 };
                health = new int[6] { 2, 4, 6, 8, 10, 10 };
                card.cd = 4;
                card.range = 2;
                card.speed = 4;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                flying = true;
                attackAura = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.PontiffFaol:
                attack = new int[6] { 1, 1, 1, 1, 1, 3 };
                health = new int[6] { 9, 11, 12, 13, 15, 15 };
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Magical;
                whirlwind = true;
                penetrate = true;
                martyrdom = true;
                regeneration = new int[6] { 1, 1, 2, 3, 3, 3 };
                break;

            case Card.Title.PrinceSerka:
                attack = new int[6] { 2, 2, 2, 2, 2, 3 };
                health = new int[6] { 7, 10, 11, 14, 15, 15 };
                card.cd = 7;
                card.range = 2;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                lifeSteal = true;
                counterattack = true;
                lifeAura = new int[6] { 1, 1, 2, 2, 3, 4 };
                break;

            case Card.Title.TanwenWildfire:
                attack = new int[6] { 3, 3, 4, 4, 5, 6 };
                health = new int[6] { 6, 8, 9, 14, 14, 17 };
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Magical;
                ember = true;
                herosBane = new int[6] { 2, 2, 2, 3, 3, 4 };
                immolate = new int[6] { 1, 1, 1, 2, 2, 3 };
                break;

            case Card.Title.VelynTheUnscarred:
                attack = new int[6] { 2, 2, 3, 3, 3, 4 };
                health = new int[6] { 7, 9, 10, 12, 15, 17 };
                card.cd = 4;
                card.range = 3;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                spear = true;
                nimble = true;
                resistance = new int[6] { 99, 99, 99, 99, 99, 99 };
                vigilance = true;
                break;

            case Card.Title.VirulentBatKing:
                attack = new int[6] { 1, 1, 1, 1, 1, 1 };
                health = new int[6] { 7, 8, 9, 10, 11, 12 };
                card.cd = 6;
                card.range = 2;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                flying = true;
                bleedingAttack = true;
                poison = new int[6] { 2, 3, 4, 5, 6, 7 };
                break;

            case Card.Title.WindDancerElke:
                attack = new int[6] { 1, 1, 1, 1, 1, 1 };
                health = new int[6] { 6, 8, 10, 12, 15, 15 };
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.rarity = 4;
                card.damageType = Card.DamageType.Physical;
                whirlwind = true;
                penetrate = true;
                heroic = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.AryaTheHonorable:
                attack = new int[6] { 1, 1, 1, 1, 1, 1 };
                health = new int[6] { 10, 13, 13, 16, 19, 19 };
                card.cd = 7;
                card.range = 4;
                card.speed = 2;
                card.rarity = 5;
                card.damageType = Card.DamageType.Magical;
                regeneration = new int[6] { 2, 2, 3, 3, 3, 4 };
                regenerationAura = new int[6] { 1, 1, 2, 2, 2, 3 };
                break;

            case Card.Title.BigShuck:
                attack = new int[6] { 1, 1, 1, 1, 1, 1 };
                health = new int[6] { 6, 8, 10, 11, 12, 13 };
                card.cd = 3;
                card.range = 2;
                card.speed = 3;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                multistrike = new int[6] { 2, 2, 2, 3, 4, 5 };
                break;

            case Card.Title.ChieftainLionroar:
                attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                health = new int[6] { 3, 5, 7, 7, 9, 9 };
                card.cd = 3;
                card.range = 2;
                card.speed = 4;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                hitAndRun = true;
                speedAura = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.DragonHunterVincent:
                attack = new int[6] { 4, 4, 5, 5, 6, 7 };
                health = new int[6] { 9, 11, 11, 13, 15, 17 };
                card.cd = 6;
                card.range = 4;
                card.speed = 2;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                heavyWeapon = true;
                knockback = new int[6] { 2, 2, 2, 2, 2, 2 };
                dragonSlayer = true;
                break;

            case Card.Title.EmperorAugustus:
                attack = new int[6] { 0, 1, 2, 3, 4, 5 };
                health = new int[6] { 8, 11, 14, 17, 20, 23 };
                card.cd = 8;
                card.range = 2;
                card.speed = 2;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                kingsCommand = true;
                break;

            case Card.Title.EmrysTheUnyielding:
                attack = new int[6] { 3, 3, 4, 4, 5, 6 };
                health = new int[6] { 12, 15, 16, 19, 21, 24 };
                card.cd = 7;
                card.range = 2;
                card.speed = 4;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                penetrate = true;
                combatMaster = true;
                break;

            case Card.Title.ExecutionerGrimbone:
                attack = new int[6] { 1, 1, 1, 2, 2, 3 };
                health = new int[6] { 5, 6, 7, 8, 9, 11 };
                card.cd = 6;
                card.range = 2;
                card.speed = 2;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                skeletal = true;
                reapingCurse = new int[6] { 2, 2, 2, 2, 3, 3 };
                resistance = new int[6] { 1, 1, 2, 2, 2, 3 };
                break;

            case Card.Title.Gringheist:
                attack = new int[6] { 1, 1, 1, 1, 1, 2 };
                health = new int[6] { 3, 4, 5, 6, 7, 8 };
                card.cd = 4;
                card.range = 4;
                card.speed = 2;
                card.rarity = 5;
                card.damageType = Card.DamageType.Magical;
                soulbound = true;
                frostBolt = true;
                incorporeal = true;
                blackIce = true;
                break;

            case Card.Title.JasmineTheDervish:
                attack = new int[6] { 1, 1, 1, 1, 1, 2 };
                health = new int[6] { 7, 9, 11, 13, 15, 15 };
                card.cd = 7;
                card.range = 2;
                card.speed = 2;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                whirlwind = true;
                firstStrike = true;
                cheif = true;
                influence = true;
                break;

            case Card.Title.KingVelAssar:
                attack = new int[6] { 1, 1, 2, 2, 3, 4 };
                health = new int[6] { 5, 7, 7, 9, 10, 11 };
                card.cd = 6;
                card.range = 10;
                card.speed = 2;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                multiShot = true;
                break;

            case Card.Title.LordFleder:
                attack = new int[6] { 0, 0, 1, 1, 1, 1 };
                health = new int[6] { 7, 9, 9, 11, 13, 13 };
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                flying = true;
                lifeSteal = true;
                battleSpirit = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.MaiaShadowblade:
                attack = new int[6] { 1, 1, 1, 2, 3, 3 };
                health = new int[6] { 1, 2, 3, 3, 3, 3 };
                card.cd = 1;
                card.range = 2;
                card.speed = 10;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                ambush = true;
                heroic = new int[6] { 1, 1, 1, 1, 1, 2 };
                break;

            case Card.Title.PrincessSarya:
                attack = new int[6] { 1, 1, 1, 1, 1, 1 };
                health = new int[6] { 4, 4, 4, 4, 4, 5 };
                card.cd = 7;
                card.range = 4;
                card.speed = 2;
                card.rarity = 5;
                card.damageType = Card.DamageType.Magical;
                lifeSteal = true;
                witheringAura = new int[6] { 1, 2, 3, 4, 5, 6 };
                break;

            case Card.Title.RyliTheWhiteWitch:
                attack = new int[6] { 1, 1, 1, 1, 1, 1 };
                health = new int[6] { 4, 6, 8, 10, 12, 14 };
                card.cd = 5;
                card.range = 4;
                card.speed = 2;
                card.rarity = 5;
                card.damageType = Card.DamageType.Magical;
                blizzardAura = true;
                frostBolt = true;
                break;

            case Card.Title.SilvaTheAlmighty:
                attack = new int[6] { 1, 1, 2, 2, 3, 3 };
                health = new int[6] { 7, 10, 10, 13, 13, 13 };
                card.cd = 7;
                card.range = 4;
                card.speed = 2;
                card.rarity = 5;
                card.damageType = Card.DamageType.Magical;
                stun = true;
                lightningBolt = new int[6] { 1, 1, 2, 2, 3, 4 };
                ember = true;
                thunderStorm = new int[6] { 1, 1, 1, 1, 1, 2 };
                herosBane = new int[6] { 1, 1, 1, 1, 1, 2 };
                frostBolt = true;
                conjure = true;
                break;

            case Card.Title.SorannTheUnforgiving:
                attack = new int[6] { 1, 1, 1, 2, 2, 2 };
                health = new int[6] { 4, 6, 6, 7, 9, 9 };
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                vigilance = true;
                penetrate = true;
                nimble = true;
                disdain = new int[6] { 1, 1, 2, 2, 2, 3 };
                break;

            case Card.Title.StormLizardKing:
                attack = new int[6] { 1, 1, 1, 1, 1, 1 };
                health = new int[6] { 8, 11, 11, 14, 17, 20 };
                card.cd = 5;
                card.range = 1;
                card.speed = 1;
                card.rarity = 5;
                card.damageType = Card.DamageType.Magical;
                permaStun = true;
                armor = new int[6] { 3, 3, 4, 4, 4, 5 };
                break;

            case Card.Title.TarielThePhalanx:
                attack = new int[6] { 2, 2, 3, 3, 4, 5 };
                health = new int[6] { 8, 10, 11, 14, 15, 17 };
                card.cd = 5;
                card.range = 2;
                card.speed = 4;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                flying = true;
                nimble = true;
                reinforcement = true;
                break;

            case Card.Title.UndeadKingBael:
                attack = new int[6] { 0, 1, 2, 3, 4, 5 };
                health = new int[6] { 14, 16, 18, 20, 22, 24 };
                card.cd = 9;
                card.range = 2;
                card.speed = 2;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                callOfTheUndeadKing = true;
                break;

            case Card.Title.VarkusTheBlight:
                attack = new int[6] { 1, 1, 1, 1, 1, 2 };
                health = new int[6] { 4, 5, 6, 8, 10, 13 };
                card.cd = 7;
                card.range = 2;
                card.speed = 4;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                armor = new int[6] { 1, 1, 1, 1, 1, 1 };
                soulHarvest = true;
                break;

            case Card.Title.Whitemane:
                attack = new int[6] { 2, 2, 2, 3, 3, 4 };
                health = new int[6] { 5, 7, 9, 10, 13, 16 };
                card.cd = 4;
                card.range = 2;
                card.speed = 3;
                card.rarity = 5;
                card.damageType = Card.DamageType.Physical;
                bloodPrice = new int[6] { 2, 2, 2, 2, 2, 2 };
                penetrate = true;
                penetrateAura = true;
                crushDefenses = true;
                break;



            case Card.Title.Null:
                attack = new int[6] { 1, 1, 1, 1, 1, 1 };
                health = new int[6] { 50, 50, 50, 50, 50, 50 };
                card.cd = 0;
                card.range = 2;
                card.speed = 2;
                card.rarity = 0;
                card.damageType = Card.DamageType.Physical;
                break;

            case Card.Title.BoneHeap:
                attack = new int[6] { 0, 0, 0, 0, 0, 0 };
                health = new int[6] { 1, 1, 1, 1, 1, 1 };
                card.cd = 0;
                card.range = 0;
                card.speed = 0;
                card.rarity = 0;
                card.damageType = Card.DamageType.Physical;
                boneHeap = true;
                break;

            case Card.Title.RaisedDead:
                attack = new int[6] { 0, 1, 1, 1, 2, 3 };
                health = new int[6] { 1, 1, 2, 3, 3, 4 };
                card.cd = 0;
                card.range = 2;
                card.speed = 2;
                card.rarity = 0;
                card.damageType = Card.DamageType.Physical;
                reanimate = true;
                break;
        }

        SetDefaults(card, title, alignment, rank);


        card.special.wall = wall;
        card.special.flying = flying;

        card.special.vigilance = vigilance;
        card.special.penetrate = penetrate;

        card.special.armor = armor[rank];
        card.special.resistance = resistance[rank];
        card.special.charge = charge[rank];
        card.special.cure = cure[rank];
        card.special.heroic = heroic[rank];
        card.special.regeneration = regeneration[rank];
        card.special.multistrike = multistrike[rank];
        card.special.weaken = weaken[rank];
        card.special.shadowBolt = shadowBolt[rank];
        card.special.poison = poison[rank];
        card.special.poisoned = poisoned[rank];
        card.special.immolate = immolate[rank];
        card.special.reapingCurse = reapingCurse[rank];
        card.special.soulEater = soulEater[rank];
        card.special.spellCurse = spellCurse[rank];
        card.special.spellCursed = spellCursed[rank];
        card.special.spellFeed = spellFeed[rank];
        card.special.inspiration = inspiration[rank];
        card.special.herosBane = herosBane[rank];
        card.special.embered = embered[rank];
        card.special.lightningBolt = lightningBolt[rank];
        card.special.rage = rage[rank];
        card.special.carnivore = carnivore[rank];
        card.special.bloodPrice = bloodPrice[rank];
        card.special.maim = maim[rank];
        card.special.maimed = maimed[rank];
        card.special.battleSpirit = battleSpirit[rank];
        card.special.knockback = knockback[rank];

        card.special.lifeAura = lifeAura[rank];
        card.special.regenerationAura = regenerationAura[rank];
        card.special.witheringAura = witheringAura[rank];
        card.special.rangeAura = rangeAura[rank];
        card.special.speedAura = speedAura[rank];
        card.special.attackAura = attackAura[rank];
        card.special.blizzardAura = blizzardAura;
        card.special.herosBaneAura = herosBaneAura[rank];
        card.special.penetrateAura = penetrateAura;
        card.special.poisonAura = poisonAura[rank];
        card.special.armorAura = armorAura[rank];

        card.special.pierce = pierce;
        card.special.whirlwind = whirlwind;
        card.special.counterattack = counterattack;
        card.special.firstStrike = firstStrike;
        card.special.dispel = dispel;
        card.special.faith = faith;
        card.special.martyrdom = martyrdom;
        card.special.heavyWeapon = heavyWeapon;
        card.special.dragonSlayer = dragonSlayer;
        card.special.reanimate = reanimate;
        card.special.lifeSteal = lifeSteal;
        card.special.soulbound = soulbound;
        card.special.frostBolt = frostBolt;
        card.special.incorporeal = incorporeal;
        card.special.fear = fear;
        card.special.skeletal = skeletal;
        card.special.boneHeap = boneHeap;
        card.special.vengefulCurse = vengefulCurse;
        card.special.vengefulCursed = vengefulCursed;
        card.special.panicStrike = panicStrike;
        card.special.sniper = sniper;
        card.special.ember = ember;
        card.special.nimble = nimble;
        card.special.conjure = conjure;
        card.special.donor = donor;
        card.special.stun = stun;
        card.special.stunned = stunned;
        card.special.permaStun = permaStun;
        card.special.distraction = distraction;
        card.special.spear = spear;
        card.special.ambush = ambush;
        card.special.cleave = cleave;
        card.special.charm = charm;
        card.special.hitAndRun = hitAndRun;
        card.special.bleedingAttack = bleedingAttack;
        card.special.bleeding = bleeding;
        card.special.influence = influence;
        card.special.headbutt = headbutt;

        card.special.kingsCommand = kingsCommand;
        card.special.combatMaster = combatMaster;
        card.special.callOfTheUndeadKing = callOfTheUndeadKing;
        card.special.blackIce = blackIce;
        card.special.soulHarvest = soulHarvest;
        card.special.multiShot = multiShot;
        card.special.reinforcement = reinforcement;
        card.special.disdain = disdain[rank];
        card.special.crushDefenses = crushDefenses;
        card.special.cheif = cheif;
        card.special.krush = krush;
        card.special.thunderStorm = thunderStorm[rank];

        return card;
    }
}
