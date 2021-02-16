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
        LuciusSwift, MifzunaTheWind, OfeigurTheUndying, OpheliaWestWind, PontiffFaol, PrinceSerka, SilvaTheFrozenHeart, TanwenWildfire, VelynTheUnscarred, VirulentBatKing,
        WindDancerElke,

        AryaTheHonorable, BigShuck, ChieftainLionroar, DragonHunterVincent, EmperorAugustus, EmrysTheUnyielding, ExecutionerGrimbone, Gringheist, JasmineTheDervish, KathrynEmberwind,
        KingVelAssar, LordFleder, MaiaShadowblade, PrincessSarya, RyliTheWhiteWitch, SorannTheUnforgiving, StormLizardKing, TarielThePhalanx, UndeadKingBael, VarkusTheBlight,
        Whitemane,

        PlaceHolder, BoneHeap,
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
    public string nameTag;

    public int bonusAttackNextTurn = 0;
    public int heroicThisTurn = 0;
    public bool canAttackThisTurn = true;
    public bool readyToAttack = false;
    public Sprite sprite;
    public Special special = new Special();

    public void DisplayCard(GameObject gameObject, Card card)
    {
        gameObject.GetComponentInChildren<Text>().text = "";
        if (card.cd > 0)
        {
            gameObject.GetComponentInChildren<Text>().text += "<size=50>" + card.cd + " / " + card.cdDefault + "</size>" + "\n";
        }

        gameObject.GetComponentInChildren<Text>().text +=
            (card.alignment == Card.Alignment.Ally ? "<color=green>" : "<color=red>") + "<size=" + (60 - (2 * card.nameTag.Length)) + ">" +
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
}
