using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Special : MonoBehaviour
{
    public bool wall = false;
    public bool flying = false;

    public bool vigilance = false;
    public bool penetrate = false;
    public bool magical = false;

    public int armor = 0;
    public int resistance = 0;
    public int cure = 0;
    public int heroic = 0;
    public int regeneration = 0;
    public int multistrike = 0;
    public int weaken = 0;
    public int shadowBolt = 0;

    public int lifeAura = 0;
    public int regenerationAura = 0;
    public int witheringAura = 0;

    public bool charge = false;
    public bool pierce = false;
    public bool whirlwind = false;
    public bool counterattack = false;
    public bool firstStrike = false;
    public bool dispel = false;
    public bool faith = false;
    public bool martyrdom = false;
    public bool heavyWeapon = false;
    public bool dragonSlayer = false;
    public bool knockBack = false;
    public bool reanimate = false;
    public bool lifeSteal = false;
    public bool soulBound = false;

    public bool kingsCommand = false;
    public bool combatMaster = false;
    public bool callOfTheUndeadKing = false;

    public int CheckArmor(Card dealer, Card target, int damage)
    {
        if (target.special.armor > 0)
        {
            if (!dealer.special.penetrate && !dealer.special.magical)
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
            if (dealer.special.magical && !dealer.special.penetrate)
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
                for (int i = 0; i < dealer.special.multistrike + 1; i++)
                {
                    UnitAttack unitAttack = new UnitAttack();
                    unitAttack.DealDamage(dealer, enemies[0], dealer.attack);
                }
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
            if (dealer.alignment != Turn.turn)
            {
                dealer.attack += dealer.special.heroic;
            }

            else if (dealer.heroicThisTurn == 0)
            {
                dealer.heroicThisTurn = dealer.special.heroic;
            }
        }
    }

    public void CheckLifeAuraBattlecry(Card dealer)
    {
        if (dealer.special.lifeAura > 0)
        {
            Tile tile = new Tile();
            List<Card> allies = tile.GetAllOtherAllies(dealer);

            for (int i = 0; i < allies.Count; i++)
            {
                UnitAttack unitAttack = new UnitAttack();
                unitAttack.IncreaseHealth(dealer, allies[i], dealer.special.lifeAura);
            }
        }
    }

    public void CheckLifeAuraSummon(Card dealer)
    {
        Tile tile = new Tile();
        List<Card> allies = tile.GetAllOtherAllies(dealer);
        
        for (int i = 0; i < allies.Count; i++)
        {
            if (allies[i].special.lifeAura > 0)
            {
                UnitAttack unitAttack = new UnitAttack();
                unitAttack.IncreaseHealth(allies[i], dealer, allies[i].special.lifeAura);
            }
        }
    }

    public bool CheckSummonUnitEndTurn(Card dealer)
    {
        if (dealer.special.kingsCommand)
        {
            CardStat cardStat = new CardStat();
            Card _card = cardStat.SetStats(Card.Title.PlaceHolder);

            Rng rng = new Rng();
            int summonTile = 0;
            List<int> emptyTiles = new List<int>();

            if (dealer.alignment == Card.Alignment.Ally)
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
                animaCard.MoveBfBf(_card, dealer.tile, summonTile, true);
                return true;
            }
        }
        return false;
    }

    public int CheckChargeAttack(Card dealer, Card target, int damage)
    {
        if (dealer.special.charge && target.range >= 4)
        {
            damage *= 2;
        }
        return damage;
    }

    public void CheckChargeMove(Card dealer, int tileFrom, int tileTo)
    {
        if (dealer.special.charge)
        {
            dealer.bonusAttackNextTurn += Mathf.Abs(((tileTo - tileFrom) / 3) / 2);
        }
    }

    public int CheckCombatMaster(Card dealer, Card target, int damage)
    {
        if (dealer.special.combatMaster)
        {
            if (target.range >= 4 || target.speed >= 4 || target.special.armor >= 1 || target.special.wall || target.special.flying)
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

            if (enemies.Count > 0)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    for (int j = 0; j < dealer.special.multistrike + 1; j++)
                    {
                        UnitAttack unitAttack = new UnitAttack();
                        unitAttack.DealDamage(dealer, enemies[i], dealer.attack);
                    }
                }
                return true;
            }
        }
        return false;
    }

    public void CheckCounterattack(Card dealer, Card target)
    {
        if (target.special.counterattack)
        {
            UnitAttack unitAttack = new UnitAttack();
            unitAttack.DealDamage(target, dealer, target.attack);
        }
    }

    public bool CheckFirstStrike(Card dealer, Card target)
    {
        if (target.special.firstStrike)
        {
            UnitAttack unitAttack = new UnitAttack();
            unitAttack.DealDamage(target, dealer, target.attack);
            if (target.health <= 0)
            {
                return true;
            }
        }
        return false;
    }

    public bool CheckRegeneration(Card dealer)
    {
        if (dealer.special.regeneration > 0)
        {
            if (dealer.health < dealer.healthMax)
            {
                UnitAttack unitAttack = new UnitAttack();
                unitAttack.Heal(dealer, dealer, dealer.special.regeneration);
                return true;
            }
        }
        return false;
    }

    public void CheckDispel(Card dealer, Card target)
    {
        if (dealer.special.dispel)
        {
            if (target.attack > target.attackDefault)
            {
                target.attack = target.attackDefault;
            }
            if (target.health > target.healthDefault)
            {
                target.health = target.healthDefault;
            }
            if (target.healthMax > target.healthMaxDefault)
            {
                target.healthMax = target.healthMaxDefault;
            }
        }
    }

    public void CheckFaith(Card dealer)
    {
        if (dealer.special.faith)
        {
            dealer.attack += 1;
            dealer.health += 1;
        }
    }

    public Card CheckMartyrdom(Card target)
    {
        if (target.special.martyrdom)
        {
            Tile tile = new Tile();
            List<Card> allies = tile.GetNearbyAllies(target);
            if (allies.Count > 0)
            {
                Rng rng = new Rng();
                return allies[rng.Range(0, allies.Count)];
            }
        }
        return target;
    }

    public void CheckRegenerationAuraBattlecry(Card dealer)
    {
        if (dealer.special.regenerationAura > 0)
        {
            Tile tile = new Tile();
            List<Card> allies = tile.GetAllOtherAllies(dealer);

            for (int i = 0; i < allies.Count; i++)
            {
                UnitAttack unitAttack = new UnitAttack();
                unitAttack.IncreaseRegeneration(dealer, allies[i], dealer.special.regenerationAura);
            }
        }
    }

    public void CheckRegenerationAuraSummon(Card dealer)
    {
        Tile tile = new Tile();
        List<Card> allies = tile.GetAllOtherAllies(dealer);

        for (int i = 0; i < allies.Count; i++)
        {
            if (allies[i].special.regenerationAura > 0)
            {
                UnitAttack unitAttack = new UnitAttack();
                unitAttack.IncreaseRegeneration(allies[i], dealer, allies[i].special.regenerationAura);
            }
        }
    }

    public int CheckMultistrike(Card dealer, int damage)
    {
        int damageNew = damage;
        for (int i = 0; i < dealer.special.multistrike; i++)
        {
            damageNew += damage;
        }

        return damageNew;
    }

    public void CheckHeavyWeapon(Card dealer)
    {
        if (dealer.special.heavyWeapon)
        {
            dealer.canAttackThisTurn = false;
        }
    }

    public int CheckDragonSlayer(Card dealer, Card target, int damage)
    {
        if (dealer.special.dragonSlayer)
        {
            if (target.cd >= 5)
            {
                damage *= 2;
            }
        }
        return damage;
    }

    public void CheckKnockBack(Card dealer, Card target)
    {
        if (dealer.special.knockBack)
        {
            Tile tile = new Tile();
            int tileNew = tile.GetTileInFront(target, 2, true);
            

            if (tileNew != target.tile)
            {
                AnimaCard animaCard = new AnimaCard();
                animaCard.MoveBfBf(target, target.tile, tileNew);
            }
        }
    }

    public void CheckReanimate(Card target)
    {
        if (target.special.reanimate)
        {
            CardStat cardStat = new CardStat();
            Card card = cardStat.SetStats(target.title);
            card.special.reanimate = false;
            AnimaCard animaCard = new AnimaCard();
            animaCard.MoveBfBf(card, target.tile, target.tile, true);
            AnimaText animaText = new AnimaText();
            animaText.ShowText(Bf.Bfs[target.tile], "Reanimated", Hue.cyan);
        }
    }

    public void CheckCallOfTheUndeadKing(Card target)
    {
        if (!Bf.occupied[target.tile])
        {
            Tile tile = new Tile();
            List<Card> enemies = tile.GetAllEnemies(target);

            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].special.callOfTheUndeadKing)
                {
                    CardStat cardStat = new CardStat();
                    Card card = cardStat.SetStats(Card.Title.PlaceHolder);
                    AnimaCard animaCard = new AnimaCard();
                    animaCard.MoveBfBf(card, enemies[i].tile, target.tile, true);
                    break;
                }
            }
        }
    }

    public void CheckLifeSteal(Card dealer, int damage)
    {
        if (dealer.special.lifeSteal)
        {
            if (dealer.health < dealer.healthMax)
            {
                UnitAttack unitAttack = new UnitAttack();
                unitAttack.Heal(dealer, dealer, damage);
            }
        }
    }

    public void CheckWeaken(Card dealer, Card target)
    {
        if (dealer.special.weaken > 0)
        {
            if (target.attack > 0)
            {
                target.attack -= dealer.special.weaken;
            }
        }
    }

    public void CheckWitheringAuraBattlecry(Card dealer)
    {
        if (dealer.special.witheringAura > 0)
        {
            Tile tile = new Tile();
            List<Card> enemies = tile.GetAllEnemies(dealer);

            for (int i = 0; i < enemies.Count; i++)
            {
                UnitAttack unitAttack = new UnitAttack();
                unitAttack.DecreaseHealth(dealer, enemies[i], dealer.special.witheringAura);
            }
        }
    }

    public void CheckWitheringAuraSummon(Card dealer)
    {
        Tile tile = new Tile();
        List<Card> enemies = tile.GetAllEnemies(dealer);

        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].special.witheringAura > 0)
            {
                UnitAttack unitAttack = new UnitAttack();
                unitAttack.DecreaseHealth(enemies[i], dealer, enemies[i].special.witheringAura);
            }
        }
    }

    public void CheckSoulBound(Card target)
    {
        if (target.special.soulBound)
        {
            CardStat cardStat = new CardStat();
            Card card = cardStat.SetStats(target.title);
            card.special.soulBound = false;

            Hand hand = new Hand();
            hand.AddCardFromBf(card, target.tile);
        }
    }

    public int CheckShadowBolt(Card dealer, int damage)
    {
        if (dealer.special.shadowBolt > 0)
        {
            Rng rng = new Rng();
            damage = rng.Range(0, damage * dealer.special.shadowBolt);
        }
        return damage;
    }
}
