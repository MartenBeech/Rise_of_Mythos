using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeck : MonoBehaviour
{
    public void SetEnemyDeckDefault(EnemyHero.Hero hero)
    {
        Deck.deckEnemyDefault.Clear();
        Deck deck = new Deck();
        Card card = new Card();
        Rng rng = new Rng();
        List<Card> cardsRarity1 = card.GetCardsByRarity(1);
        List<Card> cardsRarity2 = card.GetCardsByRarity(2);
        List<Card> cardsRarity3 = card.GetCardsByRarity(3);
        List<Card> cardsRarity4 = card.GetCardsByRarity(4);
        List<Card> cardsRarity5 = card.GetCardsByRarity(5);
        switch (hero)
        {
            case EnemyHero.Hero.Ajit:
            case EnemyHero.Hero.Anastasya:
            case EnemyHero.Hero.Andras:
            case EnemyHero.Hero.Danan:
            case EnemyHero.Hero.Fahada:
            case EnemyHero.Hero.Imani:
            case EnemyHero.Hero.Jengo:
            case EnemyHero.Hero.Kente:
            case EnemyHero.Hero.Konrad:
            case EnemyHero.Hero.Lasir:
            case EnemyHero.Hero.Malathua:
            case EnemyHero.Hero.Malwen:
            case EnemyHero.Hero.Masfar:
            case EnemyHero.Hero.Mateusz:
            case EnemyHero.Hero.Nolwenn:
            case EnemyHero.Hero.Seamus:
            case EnemyHero.Hero.Tanis:
            case EnemyHero.Hero.Vayaron:
            case EnemyHero.Hero.Wysloth:
            case EnemyHero.Hero.Zenda:
                for (int i = 0; i < 8; i++)
                    deck.AddCard(cardsRarity1[rng.Range(0, cardsRarity1.Count)].title, Card.Alignment.Enemy);
                for (int i = 0; i < 8; i++)
                    deck.AddCard(cardsRarity2[rng.Range(0, cardsRarity2.Count)].title, Card.Alignment.Enemy);
                for (int i = 0; i < 8; i++)
                    deck.AddCard(cardsRarity3[rng.Range(0, cardsRarity3.Count)].title, Card.Alignment.Enemy);
                for (int i = 0; i < 4; i++)
                    deck.AddCard(cardsRarity4[rng.Range(0, cardsRarity4.Count)].title, Card.Alignment.Enemy);
                for (int i = 0; i < 2; i++)
                    deck.AddCard(cardsRarity5[rng.Range(0, cardsRarity5.Count)].title, Card.Alignment.Enemy);
                break;



            case EnemyHero.Hero.Adar:
                deck.AddCard(Card.Title.AryaTheHonorable, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.BigShuck, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.ChieftainLionroar, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.DragonHunterVincent, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.EmperorAugustus, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.EmrysTheUnyielding, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.ExecutionerGrimbone, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.Gringheist, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.JasmineTheDervish, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.KathrynEmberwind, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.KingVelAssar, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.LordFleder, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.MaiaShadowblade, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.PrincessSarya, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.RyliTheWhiteWitch, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.SorannTheUnforgiving, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.StormLizardKing, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.TarielThePhalanx, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.UndeadKingBael, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.VarkusTheBlight, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.Whitemane, Card.Alignment.Enemy, 1);
                break;

            case EnemyHero.Hero.Ivan:
                deck.AddCard(Card.Title.Lancer, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.Horseman, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.PegasusScout, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.PegasusRider, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.DarkRider, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.DreadScout, Card.Alignment.Enemy, 2);

                deck.AddCard(Card.Title.LanceKnight, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.Knight, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.PegasusLegionnaire, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.PegasusGuard, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.BlackRider, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.DreadKnight, Card.Alignment.Enemy, 1);

                deck.AddCard(Card.Title.LanceChampion, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.ChampionKnight, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.PegasusChampion, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.PegasusRaidLeader, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.DoomRider, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.DreadChampion, Card.Alignment.Enemy, 1);

                deck.AddCard(Card.Title.EacannTheCharger, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.OpheliaWestWind, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.DariusDarkhand, Card.Alignment.Enemy, 2);

                deck.AddCard(Card.Title.EmrysTheUnyielding, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.TarielThePhalanx, Card.Alignment.Enemy, 1);
                break;

            case EnemyHero.Hero.Khalida:

                deck.AddCard(Card.Title.ElvenThunderApprentice, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.ElvenFireApprentice, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.ElvenWitch, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.ElvenFrostApprentice, Card.Alignment.Enemy, 2);

                deck.AddCard(Card.Title.ElvenThunderMage, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.ElvenFireMage, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.ElvenPriestess, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.ElvenFrostArchmage, Card.Alignment.Enemy, 2);

                deck.AddCard(Card.Title.ElvenThunderArchmage, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.ElvenFireArchmage, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.ElvenHighPriestess, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.ElvenFrostSorcerer, Card.Alignment.Enemy, 2);

                deck.AddCard(Card.Title.KathrynEmberwind, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.TanwenWildfire, Card.Alignment.Enemy, 2);

                deck.AddCard(Card.Title.SilvaTheAlmighty, Card.Alignment.Enemy, 1);
                deck.AddCard(Card.Title.RyliTheWhiteWitch, Card.Alignment.Enemy, 1);
                break;

            case EnemyHero.Hero.Ludmilla:
                deck.AddCard(Card.Title.ZombieSwordsman, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.ZombieGuard, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.Wraith, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.Ghost, Card.Alignment.Enemy, 2);

                deck.AddCard(Card.Title.ZombieSentinel, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.ZombieLegionnaire, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.IcyGaleGhost, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.DreadWraith, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.ChillingGhost, Card.Alignment.Enemy, 2);

                deck.AddCard(Card.Title.ZombieChampion, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.ZombieCaptain, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.DreadPhantom, Card.Alignment.Enemy, 2);

                deck.AddCard(Card.Title.OfeigurTheUndying, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.DesperateSoul, Card.Alignment.Enemy, 2);

                deck.AddCard(Card.Title.Gringheist, Card.Alignment.Enemy, 2);
                break;

            case EnemyHero.Hero.Menan:
                deck.AddCard(Card.Title.Bat, Card.Alignment.Enemy, 3);
                deck.AddCard(Card.Title.Vampire, Card.Alignment.Enemy, 3);
                deck.AddCard(Card.Title.VampireApprentice, Card.Alignment.Enemy, 3);

                deck.AddCard(Card.Title.BloodthirstyBat, Card.Alignment.Enemy, 3);
                deck.AddCard(Card.Title.VampireMage, Card.Alignment.Enemy, 3);
                deck.AddCard(Card.Title.VampireNoble, Card.Alignment.Enemy, 3);

                deck.AddCard(Card.Title.ScarletBat, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.VampireArchmage, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.VampireLord, Card.Alignment.Enemy, 2);

                deck.AddCard(Card.Title.PrinceSerka, Card.Alignment.Enemy, 2);

                deck.AddCard(Card.Title.LordFleder, Card.Alignment.Enemy, 2);
                deck.AddCard(Card.Title.PrincessSarya, Card.Alignment.Enemy, 2);
                break;

        }
    }
}
