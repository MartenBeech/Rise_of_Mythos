using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Special : MonoBehaviour
{
    public bool wall = false;
    public bool archer = false;
    public bool cavalry = false;
    public bool flying = false;
    public bool vigilance = false;

    public int armor = 0;
    public int resistance = 0;
    public int cure = 0;
    public int heroic = 0;

    public int lifeHuman = 0;
    public int lifeUndead = 0;

    public bool charge = false;
    public bool pierce = false;
    public bool whirlwind = false;
    public bool counterattack = false;


    public bool penetrate = false;

    public bool kingsCommand = false;
    public bool combatMaster = false;

    public int CheckArmor(Card dealer, Card target, int damage)
    {
        if (target.special.armor > 0)
        {
            if (dealer.damageType == Card.DamageType.Physical)
            {
                damage -= target.special.armor;
            }
        }
        if (damage < 0)
            damage = 0;

        return damage;
    }

    public int CheckResistance(Card dealer, Card target, int damage)
    {
        if (target.special.resistance > 0)
        {
            if (dealer.damageType == Card.DamageType.Magical)
            {
                damage -= target.special.resistance;
            }
        }
        if (damage < 0)
            damage = 0;

        return damage;
    }

    public bool CheckVililanceMove(Card dealer)
    {
        if (dealer.special.vigilance)
        {
            Tile tile = new Tile();
            if (tile.GetNearbyEnemies(dealer).Count > 0)
            {
                return true;
            }
        }
        return false;
    }

    public bool CheckVililanceAttack(Card dealer)
    {
        if (dealer.special.vigilance)
        {
            Tile tile = new Tile();
            List<Card> enemies = tile.GetNearbyEnemies(dealer);
            if (enemies.Count > 0)
            {
                UnitAttack unitAttack = new UnitAttack();
                unitAttack.DealDamage(dealer, enemies[0], dealer.attack);
                return true;
            }
        }
        return false;
    }

    public bool CheckCure(Card dealer)
    {
        if (dealer.special.cure > 0)
        {
            Tile tile = new Tile();
            List<Card> allies = tile.GetAllOtherAllies(dealer);
            int mostDamage = 0;
            Card mostDamageCard = dealer;

            for (int i = 0; i < allies.Count; i++)
            {
                if (allies[i].healthDefault - allies[i].health > mostDamage)
                {
                    mostDamage = allies[i].healthDefault - allies[i].health;
                    mostDamageCard = allies[i];
                }
            }

            if (mostDamage > 0)
            {
                UnitAttack unitAttack = new UnitAttack();
                unitAttack.Heal(dealer, mostDamageCard, dealer.special.cure);
                return true;
            }
        }
        return false;
    }

    public void CheckHeroic(Card dealer)
    {
        if (dealer.special.heroic > 0)
        {
            if (dealer.heroicThisTurn == 0 || dealer.alignment != Turn.turn)
            {
                dealer.heroicThisTurn = dealer.special.heroic;
            }
        }
    }

    public void CheckLifeBonusBattlecry(Card card)
    {
        if (card.special.lifeHuman > 0 || card.special.lifeUndead > 0)
        {
            Tile tile = new Tile();
            List<Card> allies = tile.GetAllOtherAllies(card);

            for (int i = 0; i < allies.Count; i++)
            {
                if (card.special.lifeHuman > 0 && allies[i].race == Card.Race.Human)
                {
                    UnitAttack unitAttack = new UnitAttack();
                    unitAttack.IncreaseHealth(card, allies[i], card.special.lifeHuman);
                }
                if (card.special.lifeUndead > 0 && allies[i].race == Card.Race.Undead)
                {
                    UnitAttack unitAttack = new UnitAttack();
                    unitAttack.IncreaseHealth(card, allies[i], card.special.lifeUndead);
                }
            }
        }
    }

    public void CheckLifeBonusAura(Card card)
    {
        if (card.race == Card.Race.Human || card.race == Card.Race.Undead)
        {
            Tile tile = new Tile();
            List<Card> allies = tile.GetAllOtherAllies(card);
        
            for (int i = 0; i < allies.Count; i++)
            {
                if (allies[i].special.lifeHuman > 0 && card.race == Card.Race.Human)
                {
                    UnitAttack unitAttack = new UnitAttack();
                    unitAttack.IncreaseHealth(allies[i], card, allies[i].special.lifeHuman);
                }
                if (allies[i].special.lifeUndead > 0 && card.race == Card.Race.Undead)
                {
                    UnitAttack unitAttack = new UnitAttack();
                    unitAttack.IncreaseHealth(allies[i], card, allies[i].special.lifeUndead);
                }
            }
        }
    }

    public bool CheckSummonUnitEndTurn(Card card)
    {
        if (card.special.kingsCommand)
        {
            CardStat cardStat = new CardStat();
            Card _card = cardStat.SetStats(Card.Title.Paladin);

            Rng rng = new Rng();
            int summonTile = 0;
            List<int> emptyTiles = new List<int>();

            if (card.alignment == Card.Alignment.Ally)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (!Bf.occupied[i])
                    {
                        emptyTiles.Add(i);
                    }
                }
            }
            else
            {
                for (int i = Bf.SIZE - 9; i < Bf.SIZE; i++)
                {
                    if (!Bf.occupied[i])
                    {
                        emptyTiles.Add(i);
                    }
                }
            }

            if (emptyTiles.Count > 0)
            {
                summonTile = emptyTiles[rng.Range(0, emptyTiles.Count)];
                AnimaCard animaCard = new AnimaCard();
                animaCard.MoveBfBf(_card, card.tile, summonTile, true);
                return true;
            }
        }
        return false;
    }

    public int CheckChargeAttack(Card dealer, Card target, int damage)
    {
        if (dealer.special.charge && target.special.archer)
        {
            damage *= 2;
        }
        return damage;
    }

    public void CheckChargeMove(Card card, int tileFrom, int tileTo)
    {
        if (card.special.charge)
        {
            card.bonusAttackNextTurn += Mathf.Abs(((tileTo - tileFrom) / 3) / 2);
        }
    }

    public int CheckCombatMaster(Card dealer, Card target, int damage)
    {
        if (dealer.special.combatMaster)
        {
            if (target.special.archer || target.special.cavalry || target.special.armor >= 1 || target.special.wall || target.special.flying)
            {
                damage *= 2;
            }
        }
        return damage;
    }

    public void CheckPierce(Card dealer, Card target)
    {
        if (dealer.special.pierce)
        {
            int tileCheck = 0;
            if (dealer.alignment == Card.Alignment.Ally && target.tile < Bf.SIZE - 3)
            {
                tileCheck = target.tile + 3;
            }
            else if (dealer.alignment == Card.Alignment.Enemy && target.tile >= 3)
            {
                tileCheck = target.tile - 3;
            }
            else
            {
                return;
            }

            if (Bf.occupied[tileCheck])
            {
                if (Bf.Cards[tileCheck].alignment != dealer.alignment)
                {
                    UnitAttack unitAttack = new UnitAttack();
                    unitAttack.DealDamage(dealer, Bf.Cards[tileCheck], dealer.attack);
                }
            }
        }
    }

    public bool CheckWhirlwind(Card dealer)
    {
        if (dealer.special.whirlwind)
        {
            Tile tile = new Tile();
            List<Card> enemies = tile.GetNearbyEnemies(dealer);

            for (int i = 0; i < enemies.Count; i++)
            {
                UnitAttack unitAttack = new UnitAttack();
                unitAttack.DealDamage(dealer, enemies[i], dealer.attack);
            }

            return true;
        }
        return false;
    }

    public bool CheckCounterattack(Card dealer, Card target)
    {
        if (target.special.counterattack)
        {
            UnitAttack unitAttack = new UnitAttack();
            unitAttack.DealDamage(target, dealer, target.attack);
            if (target.health > 0)
            {
                return true;
            }
        }
        return false;
    }
}
