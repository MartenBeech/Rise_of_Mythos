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
    public int poison = 0;
    public int poisoned = 0;
    public int immolate = 0;
    public int reapingCurse = 0;
    public int soulEater = 0;
    public int spellCurse = 0;
    public int spellCursed = 0;
    public int spellFeed = 0;

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
    public bool knockback = false;
    public bool reanimate = false;
    public bool lifeSteal = false;
    public bool soulbound = false;
    public bool freezing = false;
    public bool incorporeal = false;
    public bool fear = false;
    public bool skeletal = false;
    public bool boneHeap = false;
    public bool vengefulCurse = false;
    public bool vengefulCursed = false;
    public bool panicStrike = false;

    public bool kingsCommand = false;
    public bool combatMaster = false;
    public bool callOfTheUndeadKing = false;
    public bool frostSuit = false;
    public bool soulHarvest = false;


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
                    unitAttack.DealDamage(dealer, enemies[0], dealer.attack, true);
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
            Card _card = cardStat.SetStats(Card.Title.PlaceHolder, dealer.alignment);

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

    public void CheckChargeMove(Card dealer, int tileFrom, int tileTo)
    {
        if (dealer.special.charge)
        {
            dealer.bonusAttackNextTurn += Mathf.Abs((tileTo - tileFrom) / 3);
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
            if (dealer.alignment == Card.Alignment.Ally)
            {
                if (target.tile < Bf.SIZE - 3)
                {
                    tileCheck = target.tile + 3;
                }
                else
                {
                    Hero hero = new Hero();
                    hero.AttackHero(dealer, Card.Alignment.Enemy);
                }
            }
            else if (dealer.alignment == Card.Alignment.Enemy && target.tile >= 3)
            {
                if (target.tile >= 3)
                {
                    tileCheck = target.tile - 3;
                }
                else
                {
                    Hero hero = new Hero();
                    hero.AttackHero(dealer, Card.Alignment.Ally);
                }
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
                    unitAttack.DealDamage(dealer, Bf.Cards[tileCheck], dealer.attack, true);
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
                        unitAttack.DealDamage(dealer, enemies[i], dealer.attack, true);
                    }
                }

                if (dealer.alignment == Card.Alignment.Ally && dealer.tile >= 27)
                {
                    Hero hero = new Hero();
                    hero.AttackHero(dealer, Card.Alignment.Enemy);
                }
                else if (dealer.alignment == Card.Alignment.Enemy && dealer.tile < 3)
                {
                    Hero hero = new Hero();
                    hero.AttackHero(dealer, Card.Alignment.Ally);
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
            unitAttack.DealDamage(target, dealer, target.attack, true);
        }
    }

    public bool CheckFirstStrike(Card dealer, Card target)
    {
        if (target.special.firstStrike)
        {
            UnitAttack unitAttack = new UnitAttack();
            unitAttack.DealDamage(target, dealer, target.attack, true);
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
            if (target.cdDefault >= 5)
            {
                damage *= 2;
            }
        }
        return damage;
    }

    public void CheckKnockback(Card dealer, Card target)
    {
        if (dealer.special.knockback)
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
            Card card = cardStat.SetStats(target.title, target.alignment);
            card.special.reanimate = false;
            AnimaCard animaCard = new AnimaCard();
            animaCard.MoveBfBf(card, target.tile, target.tile, true);
            AnimaText animaText = new AnimaText();
            animaText.ShowText(Bf.Bfs[target.tile], "Reanimated", Hue.cyan);
        }
    }

    public void CheckCallOfTheUndeadKing(Card target)
    {
        Tile tile = new Tile();
        List<Card> enemies = tile.GetAllEnemies(target);

        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].special.callOfTheUndeadKing)
            {
                CardStat cardStat = new CardStat();
                Card card = cardStat.SetStats(Card.Title.PlaceHolder, target.alignment);
                AnimaCard animaCard = new AnimaCard();
                animaCard.MoveBfBf(card, enemies[i].tile, target.tile, true);
                break;
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

    public void CheckSoulbound(Card target)
    {
        if (target.special.soulbound)
        {
            CardStat cardStat = new CardStat();
            Card card = cardStat.SetStats(target.title, target.alignment);
            card.special.soulbound = false;

            Hand hand = new Hand();
            hand.AddCardFromBf(card, target.tile, target.alignment);
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

    public void CheckFreezing(Card dealer, Card target)
    {
        if (dealer.special.freezing)
        {
            if (target.speed > 1)
            {
                target.speed = 1;
            }
        }
    }

    public int CheckIncorporeal(Card dealer, Card target, int damage)
    {
        if (target.special.incorporeal)
        {
            if (!dealer.special.penetrate && !dealer.special.magical)
            {
                if (damage > 1)
                {
                    damage = 1;
                }
            }
        }

        return damage;
    }

    public void CheckFear(Card dealer, Card target, int damage)
    {
        if (dealer.special.fear && target.health > damage)
        {
            CardStat cardStat = new CardStat();
            Card card = cardStat.SetStats(target.title, target.alignment);
            dealer.special.fear = false;

            Hand hand = new Hand();
            hand.AddCardFromBf(card, target.tile, target.alignment);
            target.health = 0;
        }
    }

    public void CheckFrostSuit(Card dealer, Card target)
    {
        if (target.special.frostSuit)
        {
            dealer.speed = 0;
        }
    }

    public void CheckSkeletal(Card target)
    {
        if (target.special.skeletal)
        {
            CardStat cardStat = new CardStat();
            Card card = cardStat.SetStats(Card.Title.BoneHeap, target.alignment);
            card.title = target.title;
            card.nameTag = target.nameTag;
            AnimaCard animaCard = new AnimaCard();
            animaCard.MoveBfBf(card, target.tile, target.tile, true);
            AnimaText animaText = new AnimaText();
            animaText.ShowText(Bf.Bfs[target.tile], "Bone Heap", Hue.cyan);
        }
    }

    public bool CheckBoneHeap(Card dealer)
    {
        if (dealer.special.boneHeap)
        {
            CardStat cardStat = new CardStat();
            Card card = cardStat.SetStats(dealer.title, dealer.alignment);
            AnimaCard animaCard = new AnimaCard();
            animaCard.MoveBfBf(card, dealer.tile, dealer.tile, true);
            AnimaText animaText = new AnimaText();
            animaText.ShowText(Bf.Bfs[dealer.tile], "Reassembled", Hue.cyan);
            return true;
        }
        return false;
    }

    public void CheckPoison(Card dealer, Card target)
    {
        if (dealer.special.poison > 0)
        {
            if (target.special.poisoned < dealer.special.poison)
            {
                target.special.poisoned = dealer.special.poison;
            }
        }
    }

    public bool CheckDamageTakenEachTurn(Card dealer)
    {
        bool damageTaken = false;
        if (dealer.special.poisoned > 0)
        {
            UnitAttack unitAttack = new UnitAttack();
            unitAttack.DealDamage(dealer, dealer, dealer.special.poisoned, false);
            damageTaken = true;
        }
        if (dealer.special.immolate > 0)
        {
            UnitAttack unitAttack = new UnitAttack();
            unitAttack.DealDamage(dealer, dealer, dealer.special.immolate, false);
            damageTaken = true;
        }
        return damageTaken;
    }

    public void CheckReapingCurse(Card target)
    {
        if (target.special.reapingCurse > 0)
        {
            Hero hero = new Hero();
            if (target.alignment == Card.Alignment.Ally)
            {
                hero.DamageHero(target, Card.Alignment.Enemy, target.special.reapingCurse);
            }
            else
            {
                hero.DamageHero(target, Card.Alignment.Ally, target.special.reapingCurse);
            }
        }
    }

    public void CheckVengefulCurse(Card dealer, Card target)
    {
        if (dealer.special.vengefulCurse)
        {
            target.special.vengefulCursed = true;
        }
    }

    public void CheckVengefulCursed(Card dealer)
    {
        if (dealer.special.vengefulCursed)
        {
            dealer.special.vengefulCursed = false;
            UnitAttack unitAttack = new UnitAttack();
            unitAttack.DealDamage(dealer, dealer, dealer.attack, false);
        }
    }

    public void CheckSoulHarvest(Card target)
    {
        Tile tile = new Tile();
        List<Card> enemies = tile.GetAllEnemies(target);

        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].special.soulHarvest)
            {
                AnimaText animaText = new AnimaText();
                animaText.ShowText(Bf.Bfs[enemies[i].tile], "+" + target.attackDefault / 2 + "/+" + target.healthDefault / 2, Hue.green);

                enemies[i].attack += target.attackDefault / 2;
                enemies[i].healthMax += target.healthMaxDefault / 2;
                enemies[i].health += target.healthDefault / 2;

                target.DisplayCard(Bf.Bfs[enemies[i].tile], enemies[i]);
            }
        }
    }

    public void CheckSoulEater(Card dealer)
    {
        if (dealer.special.soulEater > 0)
        {
            dealer.attack += dealer.special.soulEater;
            dealer.healthMax += dealer.special.soulEater;
            dealer.health += dealer.special.soulEater;
        }
    }

    public void CheckSpellCurse(Card dealer, Card target)
    {
        if (dealer.special.spellCurse > 0)
        {
            if (target.special.spellCursed < dealer.special.spellCurse)
            {
                target.special.spellCursed = dealer.special.spellCurse;
            }
        }
    }

    public int CheckSpellCursed(Card dealer, Card target, int damage)
    {
        if (target.special.spellCursed > 0)
        {
            if (dealer.special.magical && !dealer.special.penetrate)
            {
                damage += target.special.spellCursed;
            }
        }

        return damage;
    }

    public void CheckSpellFeed(Card dealer, Card target)
    {
        if (target.special.spellFeed > 0)
        {
            if (dealer.special.magical && !dealer.special.penetrate)
            {
                target.attack += target.special.spellFeed;
                target.healthMax += target.special.spellFeed;
                target.health += target.special.spellFeed;
            }
        }
    }

    public void CheckPanicStrike(Card dealer)
    {
        if (dealer.special.panicStrike)
        {
            int iMin = 0;
            int iMax = Hand.SIZE;
            if (dealer.alignment == Card.Alignment.Ally)
            {
                iMin = Hand.SIZE;
                iMax = Hand.SIZE * 2;
            }

            List<int> occupied = new List<int>();
            for (int i = iMin; i < iMax; i++)
            {
                if (Hand.occupied[i])
                {
                    occupied.Add(i);
                }
            }

            if (occupied.Count > 0)
            {
                Rng rng = new Rng();
                int rnd = occupied[rng.Range(0, occupied.Count)];
                Hand.Cards[rnd].cd += 1;

                if (rnd < Hand.SIZE)
                {
                    dealer.DisplayCard(Hand.Hands[rnd], Hand.Cards[rnd]);
                }
            }
        }
    }
}
