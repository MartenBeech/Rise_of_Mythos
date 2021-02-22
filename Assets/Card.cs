using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public enum Title
    {
        Bat, CentaurArcher, CentaurRider, Crossbowman, DarkRider, DreadScout, ElvenArcher, ElvenFireApprentice, ElvenFrostApprentice, ElvenGuard,
        ElvenHunter, ElvenSamurai, ElvenThunderApprentice, ElvenWitch, FelesMessenger, FelesTracker, Fencer, FoulSkeleton, Ghost, Guard,
        HellHound, Horseman, HuntingDog, Lancer, Lizard, Mercenary, PegasusRider, PegasusScout, Priest, Priestess,
        RepeatingCrossbow, Squire, ThunderLizard, Vampire, VampireApprentice, VenomousBat, VileSkeleton, WerewolfHowler, WerewolfIronclaw, Wraith,
        ZombieGuard, ZombieSwordsman,

        ArmouredLizard, BattlePriestess, BlackRider, BlessedElvenSamurai, BloodthirstyBat, CentaurGuerrilla, CentaurHunter, Cerberus, ChillingGhost, DreadKnight,
        DreadWraith, ElvenFireMage, ElvenFrostArchmage, ElvenLongbowArcher, ElvenPraetorian, ElvenPriestess, ElvenSniper, ElvenThunderMage, FelesAssassin, FelesScout,
        GrandFencer, HeavyCrossbowman, HeavyRepeatingCrossbow, HighPriestess, Hound, Knight, LanceKnight, MercenaryVeteran, Paladin, PegasusGuard,
        PegasusLegionnaire, RottenSkeleton, SeniorThunderLizard, Sentinel, SepticBat, UnholySkeleton, VampireMage, VampireNoble, WerewolfProwler, WerewolfSteelclaw,
        ZombieLegionnaire, ZombieSentinel,

        AegisLizard, BattleAbbess, Captain, CentaurGuerrillaLeader, CentaurMarksman, ChampionKnight, CrossbowCaptain, DoomRider, DreadChampion, DreadPhantom,
        ElvenFireArchmage, ElvenFrostSorcerer, ElvenHighPriestess, ElvenLegionnaire, ElvenMarksman, ElvenRebel, ElvenSharpShooter, ElvenThunderArchmage, FelesAssassinMaster, FelesSwordsman,
        FencingMaster, FieryCerberus, FieryHound, HellishSkeleton, HolyMaster, IcyGaleGhost, LanceChampion, MercenaryCaptain, PegasusChampion, PegasusRaidLeader,
        PlaguedSkeleton, RepeatingCrossbowCaptain, SawtoothThunderLizard, ScarletBat, SpitefulBat, Templar, VampireArchmage, VampireLord, WerewolfDeathclaw, WerewolfFleshripper,
        ZombieCaptain, ZombieChampion,

        CainTheTraitor, CerberusHegemon, ChiefIronhide, CrusaderLucanus, DariusDarkhand, DemonHunterAzrael, DesperateSoul, EacannTheCharger, FenrisTheButcher, FirstRangerTalenor,
        KathrynEmberwind, LuciusSwift, MifzunaTheWind, OfeigurTheUndying, OpheliaWestWind, PontiffFaol, PrinceSerka, TanwenWildfire, VelynTheUnscarred, VirulentBatKing,
        WindDancerElke,

        AryaTheHonorable, BigShuck, ChieftainLionroar, DragonHunterVincent, EmperorAugustus, EmrysTheUnyielding, ExecutionerGrimbone, Gringheist, JasmineTheDervish, KingVelAssar, 
        LordFleder, MaiaShadowblade, PrincessSarya, RyliTheWhiteWitch, SilvaTheAlmighty, SorannTheUnforgiving, StormLizardKing, TarielThePhalanx, UndeadKingBael, VarkusTheBlight,
        Whitemane,

        Null, BoneHeap, RaisedDead
    }
    public Title title;

    public enum Alignment
    {
        Ally, Enemy
    }
    public Alignment alignment;

    public enum Race
    {
        Human, Undead, Elf, Halfblood, Neutral
    }
    public Race race;

    public enum DamageType
    {
        Physical, Magical, True
    }
    public DamageType damageType;

    public int attack,      attackDefault;
    public int health,      healthDefault;
    public int healthMax,   healthMaxDefault;
    public int cd,          cdDefault;

    public int speed;
    public int range;
    public int tile;
    public int rarity;
    public string nameTag;

    public int bonusAttackNextTurn = 0;
    public int heroicThisTurn = 0;
    public bool canAttackThisTurn = true;
    public bool attackedThisTurn = false;
    public Sprite sprite;
    public Special special = new Special();

    public void DisplayCard(GameObject gameObject, Card card)
    {
        for (int i = 0; i < Hand.SIZE; i++)
        {
            if (gameObject == Hand.Hands[i])
            {
                if (card.cd > 0)
                {
                    Hand.Hourglasses[i].GetComponentInChildren<Image>().enabled = true;
                    Hand.Hourglasses[i].GetComponentInChildren<Text>().text = card.cd.ToString();
                    Hand.Hands[i].GetComponentInChildren<Button>().enabled = false;
                }
                else
                {
                    Hand.Hourglasses[i].GetComponentInChildren<Image>().enabled = false;
                    Hand.Hourglasses[i].GetComponentInChildren<Text>().text = null;
                    Hand.Hands[i].GetComponentInChildren<Button>().enabled = true;
                }
                break;
            }
        }

        for (int i = 0; i < Bf.SIZE; i++)
        {
            if (gameObject == Bf.Bfs[i])
            {
                if (!Bf.occupied[i])
                {
                    DisplayNull(gameObject);
                    return;
                }
                break;
            }
        }

        int nameTagSize = (60 - (2 * card.nameTag.Length));
        if (nameTagSize > 40)
            nameTagSize = 40;
        else if (nameTagSize < 22)
            nameTagSize = 22;

        gameObject.GetComponentInChildren<Text>().text =
            (card.alignment == Card.Alignment.Ally ? "<color=green>" : "<color=red>") + "<size=" + nameTagSize + ">" +
            card.nameTag + "</size>" + "</color>" + "<size=36>" + "\n\n\n\n\n\n" + "</size>" +
            "<color=red>" + card.attack + "</color>";
        for (int i = card.attack.ToString().Length + card.health.ToString().Length; i < 9; i++)
        {
            gameObject.GetComponentInChildren<Text>().text += " ";
        }
        gameObject.GetComponentInChildren<Text>().text += "<color=green>" + card.health + "</color>";

        gameObject.GetComponentInChildren<Image>().sprite = card.sprite;
    }

    public void DisplayNull(GameObject gameObject)
    {
        gameObject.GetComponentInChildren<Text>().text = null;
        gameObject.GetComponentInChildren<Image>().sprite = null;
        gameObject.GetComponentInChildren<Image>().color = Hue.white;
    }

    public List<Card> GetCardsByRarity(int _rarity)
    {
        List<Card> cards = new List<Card>();
        CardStat cardStat = new CardStat();

        for (int i = 0; i < Enum.GetNames(typeof(Title)).Length; i++)
        {
            Card card = cardStat.GetStats((Title)i, Alignment.Ally);
            if (card.rarity == _rarity)
            {
                cards.Add(card);
            }
        }

        return cards;
    }

    public List<Card> GetCardsByCD(int _cd)
    {
        List<Card> cards = new List<Card>();
        CardStat cardStat = new CardStat();

        for (int i = 0; i < Enum.GetNames(typeof(Title)).Length; i++)
        {
            Card card = cardStat.GetStats((Title)i, Alignment.Ally);
            if (card.cd == _cd)
            {
                cards.Add(card);
            }
        }

        return cards;
    }
}
