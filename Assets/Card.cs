using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public enum Title
    {
        Angel, Bat, CentaurArcher, CentaurRider, Crossbowman, DarkRider, DreadScout, ElvenArcher, ElvenFireApprentice, ElvenFrostApprentice, ElvenGuard,
        ElvenHunter, ElvenSamurai, ElvenThunderApprentice, ElvenWitch, FelesMessenger, FelesTracker, Fencer, FoulSkeleton, Ghost, Guard,
        HellHound, Horseman, HuntingDog, Lancer, Lizard, Mercenary, Ogre, OgreHercules, OgreWarrior, PegasusRider, PegasusScout, Priest, Priestess,
        RepeatingCrossbow, Squire, TenguAssassin, TenguSamurai, ThunderLizard, Vampire, VampireApprentice, VenomousBat, VileSkeleton, WerewolfHowler, WerewolfIronclaw, Wraith,
        ZombieGuard, ZombieSwordsman,

        AngelProtector, ArmouredLizard, BattlePriestess, BlackRider, BlessedElvenSamurai, BloodthirstyBat, CentaurGuerrilla, CentaurHunter, Cerberus, ChillingGhost, ColossalOgreHercules, DreadKnight,
        DreadWraith, ElvenFireMage, ElvenFrostArchmage, ElvenLongbowArcher, ElvenPraetorian, ElvenPriestess, ElvenSniper, ElvenThunderMage, FelesAssassin, FelesScout,
        GrandFencer, HeavyCrossbowman, HeavyRepeatingCrossbow, HighPriestess, Hound, Knight, LanceKnight, MercenaryVeteran, OgreBerserker, Paladin, PegasusGuard,
        PegasusLegionnaire, RottenSkeleton, SeniorOgre, SeniorThunderLizard, Sentinel, SepticBat, TenguAssaulter, TenguWarrior, UnholySkeleton, VampireMage, VampireNoble, WerewolfProwler, WerewolfSteelclaw,
        ZombieLegionnaire, ZombieSentinel,

        AegisLizard, AngelLightbinder, BattleAbbess, Captain, CentaurGuerrillaLeader, CentaurMarksman, ChampionKnight, CrossbowCaptain, DoomRider, DreadChampion, DreadPhantom,
        ElvenFireArchmage, ElvenFrostSorcerer, ElvenHighPriestess, ElvenLegionnaire, ElvenMarksman, ElvenRebel, ElvenSharpShooter, ElvenThunderArchmage, FelesAssassinMaster, FelesSwordsman,
        FencingMaster, FieryCerberus, FieryHound, HellishSkeleton, HolyMaster, IcyGaleGhost, LanceChampion, MercenaryCaptain, OgreBloodrager, OgreHerculesRingleader, OgreRingleader, PegasusChampion, PegasusRaidLeader,
        PlaguedSkeleton, RepeatingCrossbowCaptain, SawtoothThunderLizard, ScarletBat, SpitefulBat, Templar, TenguBloodseeker, TenguShadowWarrior, VampireArchmage, VampireLord, WerewolfDeathclaw, WerewolfFleshripper,
        ZombieCaptain, ZombieChampion,

        CainTheTraitor, CerberusHegemon, ChiefHrafn, ChiefIronhide, ChiefSharptooth, CrusaderLucanus, DariusDarkhand, DemonHunterAzrael, DesperateSoul, EacannTheCharger, FenrisTheButcher, FirstRangerTalenor,
        GuardianAngel, KathrynEmberwind, LuciusSwift, MifzunaTheWind, OfeigurTheUndying, OpheliaWestWind, PontiffFaol, PrinceSerka, TanwenWildfire, VelynTheUnscarred, VirulentBatKing,
        WindDancerElke,

        AryaTheHonorable, BigShuck, BossRagnar, ChieftainLionroar, DragonHunterVincent, EmperorAugustus, EmrysTheUnyielding, ExecutionerGrimbone, Gringheist, JasmineTheDervish, KingVelAssar, 
        Krusha, LordFleder, MaiaShadowblade, PrincessSarya, RyliTheWhiteWitch, Seraph, SilvaTheAlmighty, SkyReaverVara, SorannTheUnforgiving, StormLizardKing, TarielThePhalanx, UndeadKingBael, VarkusTheBlight,
        Whitemane,

        Null, BoneHeap, RaisedDead,
        ArcaneCrystalTower, BoneWall, SentryTower, WarTotem, FlyerWall
    }
    public Title title;

    public enum Alignment
    {
        Ally, Enemy
    }
    public Alignment alignment;

    public enum DamageType
    {
        Physical, Magical
    }
    public DamageType damageType;

    public int[] attack = new int[6] { -1, -1, -1, -1, -1, -1 };
    public int[] attackDefault = new int[6] { -1, -1, -1, -1, -1, -1 };
    public int[] health = new int[6] { -1, -1, -1, -1, -1, -1 };
    public int[] healthDefault = new int[6] { -1, -1, -1, -1, -1, -1 };
    public int[] healthMax = new int[6] { -1, -1, -1, -1, -1, -1 };
    public int[] healthMaxDefault = new int[6] { -1, -1, -1, -1, -1, -1 };

    public int cd = -1,          cdDefault = -1;
    public int speed = -1,       speedDefault = -1;
    public int range = -1,       rangeDefault = -1;
    public int tile = -1;
    public int rarity = -1;
    public int rank = -1;
    public bool upgraded = false;
    public bool occupied = false;
    public string nameTag = "";

    public int bonusAttackNextTurn = 0;
    public int heroicThisTurn = 0;
    public bool canAttackThisTurn = true;
    public bool attackedThisTurn = false;
    public bool returnedToHand = false;
    public Sprite sprite = null;
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
            card.nameTag + "</size>" + "</color>" + "<size=37>" + "\n\n\n\n\n\n" + "</size>";

        if (card.attack[card.rank].ToString().Length < 2)
            gameObject.GetComponentInChildren<Text>().text += " ";

        gameObject.GetComponentInChildren<Text>().text += (card.damageType == Card.DamageType.Physical ? "<color=red>" : "<color=blue>") + card.attack[card.rank] + "</color>";

        for (int i = card.attack[card.rank].ToString().Length + card.health[card.rank].ToString().Length; i < 13; i++)
            gameObject.GetComponentInChildren<Text>().text += "<size=47>" + " " + "</size>";

        gameObject.GetComponentInChildren<Text>().text += "<color=green>" + card.health[card.rank] + "</color>";

        if (card.health[card.rank].ToString().Length < 2)
            gameObject.GetComponentInChildren<Text>().text += " ";

        gameObject.GetComponentInChildren<Image>().sprite = card.sprite;
    }

    public void DisplayNull(GameObject gameObject)
    {
        gameObject.GetComponentInChildren<Text>().text = null;
        gameObject.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("UI/EmptyCard");
        gameObject.GetComponentInChildren<Image>().color = Hue.white;
    }

    public List<Card> GetCardsByRarity(int _rarity)
    {
        List<Card> cards = new List<Card>();
        CardStat cardStat = new CardStat();

        for (int i = 0; i < Enum.GetNames(typeof(Title)).Length; i++)
        {
            Card card = cardStat.GetStats((Title)i, Alignment.Ally, Game.rank);
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
            Card card = cardStat.GetStats((Title)i, Alignment.Ally, Game.rank);
            if (card.cd == _cd)
            {
                cards.Add(card);
            }
        }

        return cards;
    }
}
