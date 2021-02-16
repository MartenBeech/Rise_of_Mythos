using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardStat : MonoBehaviour
{
    private void SetDefaults(Card card, Card.Title title, Card.Alignment alignment)
    {
        card.title = title;
        card.attackDefault = card.attack;
        card.healthMaxDefault = card.healthMax = card.healthDefault = card.health;
        card.cdDefault = card.cd;

        card.tile = Bf.SIZE;
        card.alignment = alignment;

        card.nameTag = title.ToString();
        for (int j = 1; j < card.nameTag.Length; j++)
        {
            if ((int)card.nameTag[j] >= 65 && (int)card.nameTag[j] <= 90) //Capital Letters
            {
                card.nameTag = card.nameTag.Insert(j, " ");
                j++;
            }
        }

        card.race = Card.Race.Human;
        card.sprite = Resources.Load<Sprite>("Cards/" + card.race + "/" + card.nameTag.Replace(' ', '_'));
    }

    public Card GetStats(Card.Title title, Card.Alignment alignment)
    {
        Card card = new Card();

        switch(title)
        {
            case Card.Title.Bat:
                card.attack = 2;
                card.health = 9;
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.CentaurArcher:
                card.attack = 4;
                card.health = 3;
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.CentaurRider:
                card.attack = 2;
                card.health = 9;
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.Crossbowman:
                card.attack = 4;
                card.health = 11;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.DarkRider:
                card.attack = 3;
                card.health = 11;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.DreadScout:
                card.attack = 3;
                card.health = 10;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ElvenArcher:
                card.attack = 4;
                card.health = 7;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ElvenFireApprentice:
                card.attack = 3;
                card.health = 5;
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ElvenFrostApprentice:
                card.attack = 1;
                card.health = 5;
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ElvenGuard:
                card.attack = 4;
                card.health = 7;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ElvenHunter:
                card.attack = 6;
                card.health = 3;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ElvenSamurai:
                card.attack = 2;
                card.health = 12;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ElvenThunderApprentice:
                card.attack = 3;
                card.health = 4;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ElvenWitch:
                card.attack = 2;
                card.health = 8;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.FelesMessenger:
                card.attack = 2;
                card.health = 6;
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.FelesTracker:
                card.attack = 3;
                card.health = 5;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.Fencer:
                card.attack = 4;
                card.health = 7;
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.FoulSkeleton:
                card.attack = 4;
                card.health = 6;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.Ghost:
                card.attack = 3;
                card.health = 4;
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.Guard:
                card.attack = 2;
                card.health = 7;
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.HellHound:
                card.attack = 3;
                card.health = 8;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.Horseman:
                card.attack = 2;
                card.health = 12;
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.HuntingDog:
                card.attack = 2;
                card.health = 7;
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.Lancer:
                card.attack = 2;
                card.health = 5;
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.Lizard:
                card.attack = 2;
                card.health = 9;
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.Mercenary:
                card.attack = 6;
                card.health = 5;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.PegasusRider:
                card.attack = 4;
                card.health = 7;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.PegasusScout:
                card.attack = 3;
                card.health = 6;
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.Priest:
                card.attack = 1;
                card.health = 9;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.Priestess:
                card.attack = 6;
                card.health = 10;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.RepeatingCrossbow:
                card.attack = 2;
                card.health = 9;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.Squire:
                card.attack = 3;
                card.health = 7;
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ThunderLizard:
                card.attack = 2;
                card.health = 12;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.Vampire:
                card.attack = 4;
                card.health = 8;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.VampireApprentice:
                card.attack = 2;
                card.health = 12;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.VenomousBat:
                card.attack = 2;
                card.health = 5;
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.VileSkeleton:
                card.attack = 2;
                card.health = 6;
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.WerewolfHowler:
                card.attack = 6;
                card.health = 10;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.WerewolfIronclaw:
                card.attack = 3;
                card.health = 14;
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.Wraith:
                card.attack = 6;
                card.health = 4;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ZombieGuard:
                card.attack = 1;
                card.health = 3;
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ZombieSwordsman:
                card.attack = 3;
                card.health = 5;
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ArmouredLizard:
                card.attack = 2;
                card.health = 8;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.BattlePriestess:
                card.attack = 2;
                card.health = 7;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.BlackRider:
                card.attack = 2;
                card.health = 14;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.BlessedElvenSamurai:
                card.attack = 3;
                card.health = 10;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.BloodthirstyBat:
                card.attack = 3;
                card.health = 7;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.CentaurGuerrilla:
                card.attack = 2;
                card.health = 12;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.CentaurHunter:
                card.attack = 6;
                card.health = 3;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.Cerberus:
                card.attack = 3;
                card.health = 11;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ChillingGhost:
                card.attack = 4;
                card.health = 8;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.DreadKnight:
                card.attack = 3;
                card.health = 13;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.DreadWraith:
                card.attack = 5;
                card.health = 5;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ElvenFireMage:
                card.attack = 3;
                card.health = 2;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ElvenFrostArchmage:
                card.attack = 2;
                card.health = 9;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ElvenLongbowArcher:
                card.attack = 3;
                card.health = 3;
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ElvenPraetorian:
                card.attack = 4;
                card.health = 7;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ElvenPriestess:
                card.attack = 3;
                card.health = 9;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ElvenSniper:
                card.attack = 4;
                card.health = 4;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ElvenThunderMage:
                card.attack = 2;
                card.health = 6;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.FelesAssassin:
                card.attack = 5;
                card.health = 7;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.FelesScout:
                card.attack = 3;
                card.health = 7;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.GrandFencer:
                card.attack = 2;
                card.health = 13;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.HeavyCrossbowman:
                card.attack = 5;
                card.health = 17;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.HeavyRepeatingCrossbow:
                card.attack = 2;
                card.health = 9;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.HighPriestess:
                card.attack = 2;
                card.health = 12;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.Hound:
                card.attack = 2;
                card.health = 12;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.Knight:
                card.attack = 1;
                card.health = 8;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.LanceKnight:
                card.attack = 3;
                card.health = 10;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.MercenaryVeteran:
                card.attack = 7;
                card.health = 10;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.Paladin:
                card.attack = 2;
                card.health = 9;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.PegasusGuard:
                card.attack = 2;
                card.health = 5;
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.PegasusLegionnaire:
                card.attack = 3;
                card.health = 8;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.RottenSkeleton:
                card.attack = 2;
                card.health = 3;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.SeniorThunderLizard:
                card.attack = 3;
                card.health = 12;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.Sentinel:
                card.attack = 3;
                card.health = 12;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.SepticBat:
                card.attack = 3;
                card.health = 9;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.UnholySkeleton:
                card.attack = 3;
                card.health = 3;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.VampireMage:
                card.attack = 2;
                card.health = 8;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.VampireNoble:
                card.attack = 4;
                card.health = 14;
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.WerewolfProwler:
                card.attack = 7;
                card.health = 5;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.WerewolfSteelclaw:
                card.attack = 2;
                card.health = 10;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ZombieLegionnaire:
                card.attack = 2;
                card.health = 7;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ZombieSentinel:
                card.attack = 2;
                card.health = 8;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.AegisLizard:
                card.attack = 2;
                card.health = 17;
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.BattleAbbess:
                card.attack = 2;
                card.health = 9;
                card.cd = 6;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.Captain:
                card.attack = 3;
                card.health = 13;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.CentaurGuerrillaLeader:
                card.attack = 1;
                card.health = 13;
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.CentaurMarksman:
                card.attack = 5;
                card.health = 2;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ChampionKnight:
                card.attack = 2;
                card.health = 10;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.CrossbowCaptain:
                card.attack = 7;
                card.health = 16;
                card.cd = 6;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.DoomRider:
                card.attack = 3;
                card.health = 14;
                card.cd = 6;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.DreadChampion:
                card.attack = 2;
                card.health = 13;
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.DreadPhantom:
                card.attack = 3;
                card.health = 7;
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ElvenFireArchmage:
                card.attack = 3;
                card.health = 6;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ElvenFrostSorcerer:
                card.attack = 2;
                card.health = 13;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ElvenHighPriestess:
                card.attack = 2;
                card.health = 6;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ElvenLegionnaire:
                card.attack = 4;
                card.health = 11;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ElvenMarksman:
                card.attack = 5;
                card.health = 4;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ElvenRebel:
                card.attack = 3;
                card.health = 13;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ElvenSharpShooter:
                card.attack = 5;
                card.health = 7;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ElvenThunderArchmage:
                card.attack = 1;
                card.health = 9;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.FelesAssassinMaster:
                card.attack = 5;
                card.health = 9;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.FelesSwordsman:
                card.attack = 4;
                card.health = 7;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.FencingMaster:
                card.attack = 3;
                card.health = 14;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.FieryCerberus:
                card.attack = 3;
                card.health = 9;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.FieryHound:
                card.attack = 2;
                card.health = 10;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.HellishSkeleton:
                card.attack = 3;
                card.health = 4;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.HolyMaster:
                card.attack = 1;
                card.health = 12;
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.IcyGaleGhost:
                card.attack = 5;
                card.health = 7;
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.LanceChampion:
                card.attack = 5;
                card.health = 10;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.MercenaryCaptain:
                card.attack = 2;
                card.health = 12;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.PegasusChampion:
                card.attack = 3;
                card.health = 7;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.PegasusRaidLeader:
                card.attack = 5;
                card.health = 7;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.PlaguedSkeleton:
                card.attack = 3;
                card.health = 3;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.RepeatingCrossbowCaptain:
                card.attack = 2;
                card.health = 9;
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.SawtoothThunderLizard:
                card.attack = 2;
                card.health = 18;
                card.cd = 6;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ScarletBat:
                card.attack = 3;
                card.health = 13;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.SpitefulBat:
                card.attack = 3;
                card.health = 12;
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.Templar:
                card.attack = 3;
                card.health = 9;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.VampireArchmage:
                card.attack = 1;
                card.health = 13;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.VampireLord:
                card.attack = 3;
                card.health = 11;
                card.cd = 6;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.WerewolfDeathclaw:
                card.attack = 2;
                card.health = 13;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.WerewolfFleshripper:
                card.attack = 9;
                card.health = 5;
                card.cd = 6;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ZombieCaptain:
                card.attack = 3;
                card.health = 7;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ZombieChampion:
                card.attack = 3;
                card.health = 8;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.CainTheTraitor:
                card.attack = 3;
                card.health = 10;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.CerberusHegemon:
                card.attack = 2;
                card.health = 18;
                card.cd = 6;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ChiefIronhide:
                card.attack = 1;
                card.health = 15;
                card.cd = 6;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.CrusaderLucanus:
                card.attack = 2;
                card.health = 12;
                card.cd = 6;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.DariusDarkhand:
                card.attack = 2;
                card.health = 13;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.DemonHunterAzrael:
                card.attack = 2;
                card.health = 10;
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.DesperateSoul:
                card.attack = 4;
                card.health = 8;
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.EacannTheCharger:
                card.attack = 4;
                card.health = 14;
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.FenrisTheButcher:
                card.attack = 6;
                card.health = 15;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.FirstRangerTalenor:
                card.attack = 2;
                card.health = 9;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.LuciusSwift:
                card.attack = 6;
                card.health = 1;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.MifzunaTheWind:
                card.attack = 4;
                card.health = 5;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.OfeigurTheUndying:
                card.attack = 3;
                card.health = 14;
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.OpheliaWestWind:
                card.attack = 2;
                card.health = 10;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.PontiffFaol:
                card.attack = 1;
                card.health = 15;
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.PrinceSerka:
                card.attack = 2;
                card.health = 15;
                card.cd = 7;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.SilvaTheFrozenHeart:
                card.attack = 3;
                card.health = 13;
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.TanwenWildfire:
                card.attack = 5;
                card.health = 14;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.VelynTheUnscarred:
                card.attack = 3;
                card.health = 15;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.VirulentBatKing:
                card.attack = 1;
                card.health = 11;
                card.cd = 6;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.WindDancerElke:
                card.attack = 1;
                card.health = 15;
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.AryaTheHonorable:
                card.attack = 1;
                card.health = 19;
                card.cd = 7;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.BigShuck:
                card.attack = 1;
                card.health = 12;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ChieftainLionroar:
                card.attack = 1;
                card.health = 9;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.DragonHunterVincent:
                card.attack = 6;
                card.health = 15;
                card.cd = 6;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.EmperorAugustus:
                card.attack = 4;
                card.health = 20;
                card.cd = 8;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.EmrysTheUnyielding:
                card.attack = 5;
                card.health = 21;
                card.cd = 7;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.ExecutionerGrimbone:
                card.attack = 2;
                card.health = 9;
                card.cd = 6;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.Gringheist:
                card.attack = 0;
                card.health = 5;
                card.cd = 3;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.JasmineTheDervish:
                card.attack = 1;
                card.health = 21;
                card.cd = 7;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.KathrynEmberwind:
                card.attack = 2;
                card.health = 13;
                card.cd = 6;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.KingVelAssar:
                card.attack = 3;
                card.health = 10;
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.LordFleder:
                card.attack = 1;
                card.health = 13;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.MaiaShadowblade:
                card.attack = 2;
                card.health = 3;
                card.cd = 1;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.PrincessSarya:
                card.attack = 1;
                card.health = 4;
                card.cd = 7;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.RyliTheWhiteWitch:
                card.attack = 1;
                card.health = 12;
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.SorannTheUnforgiving:
                card.attack = 2;
                card.health = 9;
                card.cd = 2;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.StormLizardKing:
                card.attack = 1;
                card.health = 14;
                card.cd = 5;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.TarielThePhalanx:
                card.attack = 4;
                card.health = 10;
                card.cd = 6;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.UndeadKingBael:
                card.attack = 4;
                card.health = 22;
                card.cd = 9;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.VarkusTheBlight:
                card.attack = 1;
                card.health = 10;
                card.cd = 7;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;

            case Card.Title.Whitemane:
                card.attack = 3;
                card.health = 13;
                card.cd = 4;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;

                break;



            case Card.Title.PlaceHolder:
                card.race = Card.Race.Neutral;
                card.attack = 1;
                card.health = 1;
                card.cd = 0;
                card.range = 2;
                card.speed = 2;
                card.damageType = Card.DamageType.Physical;
                break;

            case Card.Title.BoneHeap:
                card.race = Card.Race.Neutral;
                card.attack = 0;
                card.health = 1;
                card.cd = 0;
                card.range = 0;
                card.speed = 0;
                card.damageType = Card.DamageType.Physical;

                card.special.boneHeap = true;
                break;
        }

        SetDefaults(card, title, alignment);
        return card;
    }
}
