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
        Bf bf = new Bf();
        Hand hand = new Hand();
        CardStat cardStat = new CardStat();
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
                if (Game.level <= 5)
                {
                    //bf.AddCardFromNowhere(cardStat.GetStats(Card.Title.ElvenWitch, Card.Alignment.Enemy, 0), 15);
                    for (int i = 0; i < 10; i++)
                        deck.AddCard(cardsRarity1[rng.Range(0, cardsRarity1.Count)].title, Card.Alignment.Enemy, Game.rank);
                    for (int i = 0; i < Game.level - 1; i++)
                        deck.AddCard(cardsRarity2[rng.Range(0, cardsRarity2.Count)].title, Card.Alignment.Enemy, Game.rank);
                }
                else if (Game.level <= 10)
                {
                    for (int i = 0; i < 10; i++)
                        deck.AddCard(cardsRarity1[rng.Range(0, cardsRarity1.Count)].title, Card.Alignment.Enemy, Game.rank);
                    for (int i = 0; i < Game.level - 1; i++)
                        deck.AddCard(cardsRarity2[rng.Range(0, cardsRarity2.Count)].title, Card.Alignment.Enemy, Game.rank);
                }
                else if (Game.level <= 15)
                {
                    for (int i = 0; i < 10; i++)
                        deck.AddCard(cardsRarity1[rng.Range(0, cardsRarity1.Count)].title, Card.Alignment.Enemy, Game.rank);
                    for (int i = 0; i < Game.level - 1; i++)
                        deck.AddCard(cardsRarity2[rng.Range(0, cardsRarity2.Count)].title, Card.Alignment.Enemy, Game.rank);
                }
                else if (Game.level <= 20)
                {
                    for (int i = 0; i < 5; i++)
                        deck.AddCard(cardsRarity1[rng.Range(0, cardsRarity1.Count)].title, Card.Alignment.Enemy, Game.rank);
                    for (int i = 0; i < 5; i++)
                        deck.AddCard(cardsRarity2[rng.Range(0, cardsRarity2.Count)].title, Card.Alignment.Enemy, Game.rank);
                    for (int i = 0; i < 5; i++)
                        deck.AddCard(cardsRarity3[rng.Range(0, cardsRarity3.Count)].title, Card.Alignment.Enemy, Game.rank);
                    for (int i = 0; i < 3; i++)
                        deck.AddCard(cardsRarity4[rng.Range(0, cardsRarity4.Count)].title, Card.Alignment.Enemy, Game.rank);
                    for (int i = 0; i < 2; i++)
                        deck.AddCard(cardsRarity5[rng.Range(0, cardsRarity5.Count)].title, Card.Alignment.Enemy, Game.rank);
                }
                else
                {
                    for (int i = 0; i < 7; i++)
                        deck.AddCard(cardsRarity1[rng.Range(0, cardsRarity1.Count)].title, Card.Alignment.Enemy, Game.rank);
                    for (int i = 0; i < 7; i++)
                        deck.AddCard(cardsRarity2[rng.Range(0, cardsRarity2.Count)].title, Card.Alignment.Enemy, Game.rank);
                    for (int i = 0; i < 7; i++)
                        deck.AddCard(cardsRarity3[rng.Range(0, cardsRarity3.Count)].title, Card.Alignment.Enemy, Game.rank);
                    for (int i = 0; i < 5; i++)
                        deck.AddCard(cardsRarity4[rng.Range(0, cardsRarity4.Count)].title, Card.Alignment.Enemy, Game.rank);
                    for (int i = 0; i < 4; i++)
                        deck.AddCard(cardsRarity5[rng.Range(0, cardsRarity5.Count)].title, Card.Alignment.Enemy, Game.rank);
                }
                
                break;



            case EnemyHero.Hero.Adar:
                deck.AddCard(Card.Title.AryaTheHonorable, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.BigShuck, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.ChieftainLionroar, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.DragonHunterVincent, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.EmperorAugustus, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.EmrysTheUnyielding, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.ExecutionerGrimbone, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.Gringheist, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.JasmineTheDervish, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.KathrynEmberwind, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.KingVelAssar, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.LordFleder, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.MaiaShadowblade, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.PrincessSarya, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.RyliTheWhiteWitch, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.SorannTheUnforgiving, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.StormLizardKing, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.TarielThePhalanx, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.UndeadKingBael, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.VarkusTheBlight, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.Whitemane, Card.Alignment.Enemy, Game.rank, 1);
                break;

            case EnemyHero.Hero.Ivan:
                deck.AddCard(Card.Title.Lancer, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.Horseman, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.PegasusScout, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.PegasusRider, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.DarkRider, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.DreadScout, Card.Alignment.Enemy, Game.rank, 2);

                deck.AddCard(Card.Title.LanceKnight, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.Knight, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.PegasusLegionnaire, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.PegasusGuard, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.BlackRider, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.DreadKnight, Card.Alignment.Enemy, Game.rank, 1);

                deck.AddCard(Card.Title.LanceChampion, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.ChampionKnight, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.PegasusChampion, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.PegasusRaidLeader, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.DoomRider, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.DreadChampion, Card.Alignment.Enemy, Game.rank, 1);

                deck.AddCard(Card.Title.EacannTheCharger, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.OpheliaWestWind, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.DariusDarkhand, Card.Alignment.Enemy, Game.rank, 2);

                deck.AddCard(Card.Title.EmrysTheUnyielding, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.TarielThePhalanx, Card.Alignment.Enemy, Game.rank, 1);
                break;

            case EnemyHero.Hero.Khalida:

                deck.AddCard(Card.Title.ElvenThunderApprentice, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.ElvenFireApprentice, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.ElvenWitch, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.ElvenFrostApprentice, Card.Alignment.Enemy, Game.rank, 2);

                deck.AddCard(Card.Title.ElvenThunderMage, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.ElvenFireMage, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.ElvenPriestess, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.ElvenFrostArchmage, Card.Alignment.Enemy, Game.rank, 2);

                deck.AddCard(Card.Title.ElvenThunderArchmage, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.ElvenFireArchmage, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.ElvenHighPriestess, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.ElvenFrostSorcerer, Card.Alignment.Enemy, Game.rank, 2);

                deck.AddCard(Card.Title.KathrynEmberwind, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.TanwenWildfire, Card.Alignment.Enemy, Game.rank, 2);

                deck.AddCard(Card.Title.SilvaTheAlmighty, Card.Alignment.Enemy, Game.rank, 1);
                deck.AddCard(Card.Title.RyliTheWhiteWitch, Card.Alignment.Enemy, Game.rank, 1);
                break;

            case EnemyHero.Hero.Ludmilla:
                deck.AddCard(Card.Title.ZombieSwordsman, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.ZombieGuard, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.Wraith, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.Ghost, Card.Alignment.Enemy, Game.rank, 2);

                deck.AddCard(Card.Title.ZombieSentinel, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.ZombieLegionnaire, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.IcyGaleGhost, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.DreadWraith, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.ChillingGhost, Card.Alignment.Enemy, Game.rank, 2);

                deck.AddCard(Card.Title.ZombieChampion, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.ZombieCaptain, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.DreadPhantom, Card.Alignment.Enemy, Game.rank, 2);

                deck.AddCard(Card.Title.OfeigurTheUndying, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.DesperateSoul, Card.Alignment.Enemy, Game.rank, 2);

                deck.AddCard(Card.Title.Gringheist, Card.Alignment.Enemy, Game.rank, 2);
                break;

            case EnemyHero.Hero.Menan:
                deck.AddCard(Card.Title.Bat, Card.Alignment.Enemy, Game.rank, 3);
                deck.AddCard(Card.Title.Vampire, Card.Alignment.Enemy, Game.rank, 3);
                deck.AddCard(Card.Title.VampireApprentice, Card.Alignment.Enemy, Game.rank, 3);

                deck.AddCard(Card.Title.BloodthirstyBat, Card.Alignment.Enemy, Game.rank, 3);
                deck.AddCard(Card.Title.VampireMage, Card.Alignment.Enemy, Game.rank, 3);
                deck.AddCard(Card.Title.VampireNoble, Card.Alignment.Enemy, Game.rank, 3);

                deck.AddCard(Card.Title.ScarletBat, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.VampireArchmage, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.VampireLord, Card.Alignment.Enemy, Game.rank, 2);

                deck.AddCard(Card.Title.PrinceSerka, Card.Alignment.Enemy, Game.rank, 2);

                deck.AddCard(Card.Title.LordFleder, Card.Alignment.Enemy, Game.rank, 2);
                deck.AddCard(Card.Title.PrincessSarya, Card.Alignment.Enemy, Game.rank, 2);
                break;

        }
    }
}
