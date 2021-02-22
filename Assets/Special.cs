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

    public int armor = 0;
    public int resistance = 0;
    public int charge = 0;
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
    public int inspiration = 0;
    public int herosBane = 0;
    public int embered = 0;
    public int lightningBolt = 0;
    public int rage = 0;
    public int carnivore = 0;
    public int bloodPrice = 0;
    public int maim = 0;
    public int maimed = 0;
    public int battleSpirit = 0;
    public int knockback = 0;

    public int lifeAura = 0;
    public int regenerationAura = 0;
    public int witheringAura = 0;
    public int rangeAura = 0;
    public int speedAura = 0;
    public int attackAura = 0;
    public bool blizzardAura = false;
    public int herosBaneAura = 0;
    public bool penetrateAura = false;
    public int poisonAura = 0;
    public int armorAura = 0;

    public bool pierce = false;
    public bool whirlwind = false;
    public bool counterattack = false;
    public bool firstStrike = false;
    public bool dispel = false;
    public bool faith = false;
    public bool martyrdom = false;
    public bool heavyWeapon = false;
    public bool dragonSlayer = false;
    public bool reanimate = false;
    public bool lifeSteal = false;
    public bool soulbound = false;
    public bool frostBolt = false;
    public bool incorporeal = false;
    public bool fear = false;
    public bool skeletal = false;
    public bool boneHeap = false;
    public bool vengefulCurse = false;
    public bool vengefulCursed = false;
    public bool panicStrike = false;
    public bool sniper = false;
    public bool ember = false;
    public bool nimble = false;
    public bool conjure = false;
    public bool donor = false;
    public bool stun = false;
    public bool stunned = false;
    public bool permaStun = false;
    public bool distraction = false;
    public bool spear = false;
    public bool ambush = false;
    public bool cleave = false;
    public bool charm = false;
    public bool hitAndRun = false;
    public bool bleedingAttack = false;
    public bool bleeding = false;
    public bool influence = false;
    public bool headbutt = false;

    public bool kingsCommand = false;
    public bool combatMaster = false;
    public bool callOfTheUndeadKing = false;
    public bool blackIce = false;
    public bool soulHarvest = false;
    public bool multiShot = false;
    public bool reinforcement = false;
    public int disdain = 0;
    public bool crushDefenses = false;
    public bool cheif = false;

    public bool krush = false;
    public int thunderStorm = 0;


    public int CheckArmor(Card dealer, Card target, int damage, Card.DamageType damageType)
    {
        if (target.special.armor > 0)
        {
            if (damageType == Card.DamageType.Physical && !dealer.special.penetrate)
            {
                damage -= target.special.armor;
            }
        }
        if (damage < 0)
            damage = 0;

        return damage;
    }

    public int CheckResistance(Card dealer, Card target, int damage, Card.DamageType damageType)
    {
        if (target.special.resistance > 0)
        {
            if (damageType == Card.DamageType.Magical && !dealer.special.penetrate)
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
                    unitAttack.DealDamage(dealer, enemies[0], dealer.attack, dealer.damageType, true);
                    Special special = new Special();
                    special.CheckCleave(dealer, enemies[0]);
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
                UnitSpecial unitSpecial = new UnitSpecial();
                unitSpecial.Heal(dealer, mostDamageCard, dealer.special.cure);
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
                UnitSpecial unitSpecial = new UnitSpecial();
                unitSpecial.IncreaseHealth(dealer, allies[i], dealer.special.lifeAura);
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
                UnitSpecial unitSpecial = new UnitSpecial();
                unitSpecial.IncreaseHealth(allies[i], dealer, allies[i].special.lifeAura);
            }
        }
    }

    public bool CheckKingsCommand(Card dealer)
    {
        if (dealer.special.kingsCommand)
        {
            CardStat cardStat = new CardStat();
            Card card = new Card();
            List<Card> cards = card.GetCardsByCD(1);
            Rng rng = new Rng();
            card = cardStat.GetStats(cards[rng.Range(0, cards.Count)].title, dealer.alignment);

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
                animaCard.MoveBfBf(card, dealer.tile, summonTile, true);
                return true;
            }
        }
        return false;
    }

    public void CheckChargeMove(Card dealer, int tileFrom, int tileTo)
    {
        if (dealer.special.charge > 0)
        {
            dealer.bonusAttackNextTurn += Mathf.Abs((tileTo - tileFrom) / 3) * dealer.special.charge;
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
                    unitAttack.DealDamage(dealer, Bf.Cards[tileCheck], dealer.attack, dealer.damageType, true);
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
                        unitAttack.DealDamage(dealer, enemies[i], dealer.attack, dealer.damageType, true);
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
            Tile tile = new Tile();
            if (tile.GetDistanceBetweenUnits(dealer, target) <= target.range)
            {
                for (int i = 0; i < target.special.multistrike + 1; i++)
                {
                    if (CheckWhirlwind(target)) 
                    { }
                    else
                    {
                        UnitAttack unitAttack = new UnitAttack();
                        unitAttack.DealDamage(target, dealer, target.attack, target.damageType, true);
                        CheckPierce(target, dealer);
                        CheckCleave(target, dealer);
                    }
                }
            }
        }
    }

    public bool CheckFirstStrike(Card dealer, Card target)
    {
        if (target.special.firstStrike)
        {
            Tile tile = new Tile();
            if (tile.GetDistanceBetweenUnits(dealer, target) <= target.range)
            {
                for (int i = 0; i < target.special.multistrike + 1; i++)
                {
                    if (CheckWhirlwind(target))
                    { }
                    else
                    {
                        UnitAttack unitAttack = new UnitAttack();
                        unitAttack.DealDamage(target, dealer, target.attack, target.damageType, true);
                        CheckPierce(target, dealer);
                        CheckCleave(target, dealer);
                    }
                }
            }
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
                UnitSpecial unitSpecial = new UnitSpecial();
                unitSpecial.Heal(dealer, dealer, dealer.special.regeneration);
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
                UnitSpecial unitSpecial = new UnitSpecial();
                unitSpecial.IncreaseRegeneration(dealer, allies[i], dealer.special.regenerationAura);
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
                UnitSpecial unitSpecial = new UnitSpecial();
                unitSpecial.IncreaseRegeneration(allies[i], dealer, allies[i].special.regenerationAura);
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
        if (dealer.special.knockback > 0)
        {
            Tile tile = new Tile();
            int tileNew = tile.GetTileInFront(target, dealer.special.knockback, true);
            

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
            Card card = cardStat.GetStats(target.title, target.alignment);
            card.special.reanimate = false;
            card.special.soulbound = target.special.soulbound;
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
                Card.Alignment alignment = (target.alignment == Card.Alignment.Ally ? Card.Alignment.Enemy : Card.Alignment.Ally);
                Card card = cardStat.GetStats(Card.Title.RaisedDead, alignment);
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
                UnitSpecial unitSpecial = new UnitSpecial();
                unitSpecial.Heal(dealer, dealer, damage);
            }
        }
    }

    public void CheckWeaken(Card dealer, Card target)
    {
        if (dealer.special.weaken > 0)
        {
            
            if (!target.special.nimble)
            {
                target.attack -= dealer.special.weaken;
                
                if (target.attack <= 0)
                    target.attack = 0;
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
                UnitSpecial unitSpecial = new UnitSpecial();
                unitSpecial.DecreaseHealth(dealer, enemies[i], dealer.special.witheringAura);
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
                UnitSpecial unitSpecial = new UnitSpecial();
                unitSpecial.DecreaseHealth(enemies[i], dealer, enemies[i].special.witheringAura);
            }
        }
    }

    public void CheckSoulbound(Card target)
    {
        if (target.special.soulbound)
        {
            CardStat cardStat = new CardStat();
            Card card = cardStat.GetStats(target.title, target.alignment);
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

    public void CheckFrostBolt(Card dealer, Card target)
    {
        if (dealer.special.frostBolt)
        {
            if (target.speed > 1)
            {
                if (!target.special.nimble)
                {
                    target.speed = 1;
                }
            }
        }
    }

    public int CheckIncorporeal(Card dealer, Card target, int damage, Card.DamageType damageType)
    {
        if (target.special.incorporeal)
        {
            if (damageType == Card.DamageType.Physical && !dealer.special.penetrate)
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
            Card card = cardStat.GetStats(target.title, target.alignment);
            dealer.special.fear = false;

            Hand hand = new Hand();
            hand.AddCardFromBf(card, target.tile, target.alignment);
            target.health = 0;
        }
    }

    public void CheckBlackIce(Card dealer, Card target)
    {
        if (target.special.blackIce)
        {
            if (!target.special.nimble)
            {
                dealer.speed = 0;
            }
        }
    }

    public void CheckSkeletal(Card target)
    {
        if (target.special.skeletal)
        {
            CardStat cardStat = new CardStat();
            Card card = cardStat.GetStats(Card.Title.BoneHeap, target.alignment);
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
            Card card = cardStat.GetStats(dealer.title, dealer.alignment);
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
            unitAttack.DealDamage(dealer, dealer, dealer.special.poisoned, Card.DamageType.Magical, false);
            damageTaken = true;
        }
        if (dealer.special.immolate > 0)
        {
            UnitAttack unitAttack = new UnitAttack();
            unitAttack.DealDamage(dealer, dealer, dealer.special.immolate, Card.DamageType.Magical, false);
            damageTaken = true;
        }
        if (dealer.special.embered > 0)
        {
            UnitAttack unitAttack = new UnitAttack();
            unitAttack.DealDamage(dealer, dealer, dealer.special.embered, Card.DamageType.Magical, false);
            dealer.special.embered = 0;
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
                hero.DealDamage(target, Card.Alignment.Enemy, target.special.reapingCurse);
            }
            else
            {
                hero.DealDamage(target, Card.Alignment.Ally, target.special.reapingCurse);
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
            unitAttack.DealDamage(dealer, dealer, dealer.attack, Card.DamageType.Magical, false);
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

    public int CheckSpellCursed(Card dealer, Card target, int damage, Card.DamageType damageType)
    {
        if (target.special.spellCursed > 0)
        {
            if (damageType == Card.DamageType.Magical)
            {
                damage += target.special.spellCursed;
            }
        }

        return damage;
    }

    public void CheckSpellFeed(Card dealer, Card target, Card.DamageType damageType)
    {
        if (target.special.spellFeed > 0)
        {
            if (damageType == Card.DamageType.Magical)
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

    public bool CheckSniper(Card dealer)
    {
        if (dealer.special.sniper)
        {
            Tile tile = new Tile();
            List<Card> enemies = tile.GetEnemiesInFront(dealer, dealer.tile, dealer.range);
            if (enemies.Count > 0)
            {
                int lowestHealth = 256;
                int lowestHealthTile = Bf.SIZE;
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (enemies[i].health < lowestHealth)
                    {
                        lowestHealth = enemies[i].health;
                        lowestHealthTile = enemies[i].tile;
                    }
                }
                UnitAttack unitAttack = new UnitAttack();
                unitAttack.DealDamage(dealer, Bf.Cards[lowestHealthTile], dealer.attack, dealer.damageType);
                return true;
            }
        }
        return false;
    }

    public void CheckRangeAuraBattlecry(Card dealer)
    {
        if (dealer.special.rangeAura > 0)
        {
            Tile tile = new Tile();
            List<Card> allies = tile.GetAllOtherAllies(dealer);

            for (int i = 0; i < allies.Count; i++)
            {
                UnitSpecial unitSpecial = new UnitSpecial();
                unitSpecial.IncreaseRange(dealer, allies[i], dealer.special.rangeAura);
            }
        }
    }

    public void CheckRangeAuraSummon(Card dealer)
    {
        Tile tile = new Tile();
        List<Card> allies = tile.GetAllOtherAllies(dealer);

        for (int i = 0; i < allies.Count; i++)
        {
            if (allies[i].special.rangeAura > 0)
            {
                UnitSpecial unitSpecial = new UnitSpecial();
                unitSpecial.IncreaseRange(allies[i], dealer, allies[i].special.rangeAura);
            }
        }
    }

    public void CheckSpeedAuraBattlecry(Card dealer)
    {
        if (dealer.special.speedAura > 0)
        {
            Tile tile = new Tile();
            List<Card> allies = tile.GetAllOtherAllies(dealer);

            for (int i = 0; i < allies.Count; i++)
            {
                UnitSpecial unitSpecial = new UnitSpecial();
                unitSpecial.IncreaseSpeed(dealer, allies[i], dealer.special.speedAura);
            }
        }
    }

    public void CheckSpeedAuraSummon(Card dealer)
    {
        Tile tile = new Tile();
        List<Card> allies = tile.GetAllOtherAllies(dealer);

        for (int i = 0; i < allies.Count; i++)
        {
            if (allies[i].special.speedAura > 0)
            {
                UnitSpecial unitSpecial = new UnitSpecial();
                unitSpecial.IncreaseSpeed(allies[i], dealer, allies[i].special.speedAura);
            }
        }
    }

    public bool CheckMultiShot(Card dealer)
    {
        if (dealer.special.multiShot)
        {
            Tile tile = new Tile();
            List<Card> enemies = tile.GetEnemiesInFront(dealer, dealer.tile, dealer.range);
            if (enemies.Count > 0)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    UnitAttack unitAttack = new UnitAttack();
                    unitAttack.DealDamage(dealer, enemies[i], dealer.attack, dealer.damageType);
                }
                if (tile.GetDistanceToEnemyHero(dealer, dealer.tile) <= dealer.range)
                {
                    Hero hero = new Hero();
                    if (dealer.alignment == Card.Alignment.Ally)
                        hero.AttackHero(dealer, Card.Alignment.Enemy);
                    else
                        hero.AttackHero(dealer, Card.Alignment.Ally);
                }
                return true;
            }
        }
        return false;
    }

    public void CheckInspiration(Card dealer)
    {
        if (dealer.special.inspiration > 0)
        {
            int iMin = 0;
            int iMax = Hand.SIZE;
            if (dealer.alignment == Card.Alignment.Enemy)
            {
                iMin = Hand.SIZE;
                iMax = Hand.SIZE * 2;
            }

            for (int j = 0; j < dealer.special.inspiration; j++)
            {
                List<Card> occupied = new List<Card>();
                for (int i = iMin; i < iMax; i++)
                {
                    if (Hand.occupied[i])
                    {
                        occupied.Add(Hand.Cards[i]);
                    }
                }

                if (occupied.Count > 0)
                {
                    int highestCD = 0;
                    for (int i = 0; i < occupied.Count; i++)
                    {
                        if (occupied[i].cd > highestCD)
                        {
                            highestCD = occupied[i].cd;
                        }
                    }
                    if (highestCD > 0)
                    {
                        List<int> highestCDTiles = new List<int>();
                        for (int i = 0; i < occupied.Count; i++)
                        {
                            if (occupied[i].cd == highestCD)
                                highestCDTiles.Add(occupied[i].tile);
                        }

                        Rng rng = new Rng();
                        int rnd = rng.Range(0, highestCDTiles.Count);
                        Hand.Cards[highestCDTiles[rnd]].cd -= 1;
                        if (highestCDTiles[rnd] < Hand.SIZE)
                        {
                            dealer.DisplayCard(Hand.Hands[highestCDTiles[rnd]], Hand.Cards[highestCDTiles[rnd]]);
                        }
                    }
                }
            }
        }
    }

    public bool CheckHerosBane(Card dealer)
    {
        if (dealer.special.herosBane > 0)
        {
            Hero hero = new Hero();
            if (dealer.alignment == Card.Alignment.Ally)
                hero.DealDamage(dealer, Card.Alignment.Enemy, dealer.special.herosBane);
            else
                hero.DealDamage(dealer, Card.Alignment.Ally, dealer.special.herosBane);
            return true;
        }
        return false;
    }

    public int CheckEmber(Card dealer, Card target, int damage)
    {
        if (dealer.special.ember)
        {
            target.special.embered += dealer.attack;
            damage = 0;
        }
        return damage;
    }

    public void CheckBlizzardAuraBattlecry(Card dealer)
    {
        if (dealer.special.blizzardAura)
        {
            Tile tile = new Tile();
            List<Card> enemies = tile.GetAllEnemies(dealer);

            for (int i = 0; i < enemies.Count; i++)
            {
                UnitSpecial unitSpecial = new UnitSpecial();
                unitSpecial.DecreaseSpeed(dealer, enemies[i]);
                unitSpecial.DecreaseRange(dealer, enemies[i]);
            }
        }
    }

    public void CheckBlizzardAuraSummon(Card dealer)
    {
        Tile tile = new Tile();
        List<Card> enemies = tile.GetAllEnemies(dealer);

        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].special.blizzardAura)
            {
                UnitSpecial unitSpecial = new UnitSpecial();
                unitSpecial.DecreaseSpeed(enemies[i], dealer);
                unitSpecial.DecreaseRange(enemies[i], dealer);
            }
        }
    }

    public void CheckAttackAuraBattlecry(Card dealer)
    {
        if (dealer.special.attackAura > 0)
        {
            Tile tile = new Tile();
            List<Card> allies = tile.GetAllOtherAllies(dealer);

            for (int i = 0; i < allies.Count; i++)
            {
                UnitSpecial unitSpecial = new UnitSpecial();
                unitSpecial.IncreaseAttack(dealer, allies[i], dealer.special.attackAura);
            }
        }
    }

    public void CheckAttackAuraSummon(Card dealer)
    {
        Tile tile = new Tile();
        List<Card> allies = tile.GetAllOtherAllies(dealer);

        for (int i = 0; i < allies.Count; i++)
        {
            if (allies[i].special.attackAura > 0)
            {
                UnitSpecial unitSpecial = new UnitSpecial();
                unitSpecial.IncreaseAttack(allies[i], dealer, allies[i].special.attackAura);
            }
        }
    }

    public void CheckReinforcement(Card dealer)
    {
        if (dealer.special.reinforcement)
        {
            CardStat cardStat = new CardStat();
            Card _card; 

            Tile tile = new Tile();
            List<int> tiles = tile.GetTilesOnSameColumn(dealer);

            for (int i = 0; i < tiles.Count; i++)
            {
                if (!Bf.occupied[tiles[i]])
                {
                    _card = cardStat.GetStats(dealer.title, dealer.alignment);
                    AnimaCard animaCard = new AnimaCard();
                    animaCard.MoveBfBf(_card, dealer.tile, tiles[i], true);
                }
            }
        }
    }

    public void CheckConjure(Card dealer)
    {
        Tile tile = new Tile();
        List<Card> allies = tile.GetAllOtherAllies(dealer);

        for (int i = 0; i < allies.Count; i++)
        {
            if (allies[i].special.conjure)
            {
                Deck deck = new Deck();
                deck.DrawCard(allies[i].alignment);
                allies[i].special.conjure = false;

                AnimaText animaText = new AnimaText();
                animaText.ShowText(Bf.Bfs[allies[i].tile], "Conjure", Hue.cyan);
            }
        }
    }

    public void CheckCheif(Card dealer)
    {
        if (dealer.special.cheif)
        {
            Tile tile = new Tile();
            List<Card> allies = tile.GetAllOtherAllies(dealer);
            dealer.attack += allies.Count * 1;
            dealer.health += allies.Count * 3;
            dealer.healthMax += allies.Count * 3;

            dealer.DisplayCard(Bf.Bfs[dealer.tile], dealer);
        }
    }

    public void CheckDonor(Card dealer)
    {
        if (dealer.special.donor)
        {
            Deck deck = new Deck();
            deck.DrawCard(dealer.alignment);
        }
    }

    public bool CheckLightningBolt(Card dealer)
    {
        if (dealer.special.lightningBolt > 0)
        {
            Tile tile = new Tile();
            List<Card> enemies = tile.GetAllEnemies(dealer);
            if (enemies.Count > 0)
            {
                Rng rng = new Rng();
                Card target = enemies[rng.Range(0, enemies.Count)];
                UnitAttack unitAttack = new UnitAttack();
                unitAttack.DealDamage(dealer, target, dealer.special.lightningBolt, Card.DamageType.Magical, false);

                return true;
            }
        }
        return false;
    }

    public void CheckStun(Card dealer, Card target)
    {
        if (dealer.special.stun)
        {
            target.special.stunned = true;
            dealer.special.stun = false;
        }
    }

    public void CheckPermaStun(Card dealer, Card target)
    {
        if (dealer.special.permaStun)
        {
            target.special.stunned = true;
        }
    }

    public void CheckHerosBaneAuraBattlecry(Card dealer)
    {
        if (dealer.special.herosBaneAura > 0)
        {
            Tile tile = new Tile();
            List<Card> allies = tile.GetAllOtherAllies(dealer);

            for (int i = 0; i < allies.Count; i++)
            {
                UnitSpecial unitSpecial = new UnitSpecial();
                unitSpecial.IncreaseHerosBane(dealer, allies[i], dealer.special.herosBaneAura);
            }
        }
    }

    public void CheckHerosBaneAuraSummon(Card dealer)
    {
        Tile tile = new Tile();
        List<Card> allies = tile.GetAllOtherAllies(dealer);

        for (int i = 0; i < allies.Count; i++)
        {
            if (allies[i].special.herosBaneAura > 0)
            {
                UnitSpecial unitSpecial = new UnitSpecial();
                unitSpecial.IncreaseHerosBane(allies[i], dealer, allies[i].special.herosBaneAura);
            }
        }
    }

    public void CheckDistraction(Card dealer)
    {
        if (dealer.special.distraction)
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

    public int CheckSpear(Card dealer, Card target, int damage)
    {
        if (dealer.special.spear)
        {
            if (target.speed >= 4)
            {
                damage *= 2;
            }
        }
        return damage;
    }

    public void CheckDisdain(Card dealer, Card target)
    {
        if (dealer.special.disdain > 0)
        {
            if (target.cdDefault <= dealer.special.disdain)
            {
                target.health = 0;
            }
        }
    }

    public int CheckAmbush(Card dealer, int damage)
    {
        if (dealer.special.ambush)
        {
            dealer.special.ambush = false;
            damage *= 2;
        }
        return damage;
    }

    public void CheckRage(Card target)
    {
        if (target.special.rage > 0)
        {
            target.attack += target.special.rage;
        }
    }

    public void CheckCarnivore(Card dealer)
    {
        if (dealer.special.carnivore > 0)
        {
            dealer.healthMax += dealer.special.carnivore;
            dealer.health += dealer.special.carnivore;
        }
    }

    public bool CheckBloodPrice(Card dealer)
    {
        if (dealer.special.bloodPrice > 0)
        {
            Hero hero = new Hero();
            hero.DealDamage(dealer, dealer.alignment, dealer.special.bloodPrice);
            return true;
        }
        return false;
    }

    public void CheckMaim(Card dealer, Card target)
    {
        if (dealer.special.maim > 0)
        {
            if (target.special.maimed < dealer.special.maim)
            {
                target.special.maimed = dealer.special.maim;
            }
        }
    }

    public int CheckMaimed(Card dealer, Card target, int damage, Card.DamageType damageType)
    {
        if (target.special.maimed > 0)
        {
            if (damageType == Card.DamageType.Physical)
            {
                damage += target.special.maimed;
            }
        }
        return damage;
    }

    public int CheckCrushDefenses(Card dealer, Card target, int damage)
    {
        if (dealer.special.crushDefenses)
        {
            if (target.special.armor > 0 || target.special.resistance > 0)
            {
                damage *= 2;
            }
        }
        return damage;
    }

    public void CheckPenetrateAuraBattlecry(Card dealer)
    {
        if (dealer.special.penetrateAura)
        {
            Tile tile = new Tile();
            List<Card> allies = tile.GetAllOtherAllies(dealer);

            for (int i = 0; i < allies.Count; i++)
            {
                UnitSpecial unitSpecial = new UnitSpecial();
                unitSpecial.IncreasePenetrate(dealer, allies[i]);
            }
        }
    }

    public void CheckPenetrateAuraSummon(Card dealer)
    {
        Tile tile = new Tile();
        List<Card> allies = tile.GetAllOtherAllies(dealer);

        for (int i = 0; i < allies.Count; i++)
        {
            if (allies[i].special.penetrateAura)
            {
                UnitSpecial unitSpecial = new UnitSpecial();
                unitSpecial.IncreasePenetrate(allies[i], dealer);
            }
        }
    }

    public void CheckCleave(Card dealer, Card target)
    {
        if (dealer.special.cleave)
        {
            Tile tile = new Tile();
            List<int> tiles = tile.GetTilesOnSameColumn(target);
            for (int i = 0; i < tiles.Count; i++)
            {
                if (Bf.occupied[tiles[i]])
                {
                    UnitAttack unitAttack = new UnitAttack();
                    unitAttack.DealDamage(dealer, Bf.Cards[tiles[i]], dealer.attack, dealer.damageType, true);
                }
            }
        }
    }

    public void CheckPoisonAuraBattlecry(Card dealer)
    {
        if (dealer.special.poisonAura > 0)
        {
            Tile tile = new Tile();
            List<Card> allies = tile.GetAllOtherAllies(dealer);

            for (int i = 0; i < allies.Count; i++)
            {
                UnitSpecial unitSpecial = new UnitSpecial();
                unitSpecial.IncreasePoison(dealer, allies[i], dealer.special.poisonAura);
            }
        }
    }

    public void CheckPoisonAuraSummon(Card dealer)
    {
        Tile tile = new Tile();
        List<Card> allies = tile.GetAllOtherAllies(dealer);

        for (int i = 0; i < allies.Count; i++)
        {
            if (allies[i].special.poisonAura > 0)
            {
                UnitSpecial unitSpecial = new UnitSpecial();
                unitSpecial.IncreasePoison(allies[i], dealer, allies[i].special.poisonAura);
            }
        }
    }

    public void CheckCharm(Card dealer, Card target)
    {
        if (dealer.special.charm)
        {
            if (target.cd <= 3)
            {
                if (target.alignment == Card.Alignment.Ally)
                    target.alignment = Card.Alignment.Enemy;
                else
                    target.alignment = Card.Alignment.Ally;
                dealer.special.charm = false;
            }
        }
    }

    public void CheckKrush(Card dealer, Card target)
    {
        if (dealer.special.krush)
        {
            target.health = 0;
            dealer.special.krush = false;
        }
    }

    public void CheckBattleSpirit(Card dealer, Card target, Card.DamageType damageType)
    {
        if (target.special.battleSpirit > 0)
        {
            if (damageType == Card.DamageType.Physical)
            {
                target.attack += target.special.battleSpirit;
                target.healthMax += target.special.battleSpirit;
                target.health += target.special.battleSpirit;
            }
        }
    }

    public void CheckHitAndRun(Card dealer)
    {
        if (dealer.special.hitAndRun)
        {
            if (dealer.attackedThisTurn)
            {
                int tileNew = dealer.tile;
                int tileCheck = dealer.tile;

                for (int i = 0; i < dealer.speed; i++)
                {
                    if (dealer.alignment == Card.Alignment.Enemy)
                    {
                        tileCheck += 3;
                        if (tileCheck >= Bf.SIZE)
                        {
                            break;
                        }
                    }
                    else
                    {
                        tileCheck -= 3;
                        if (tileCheck < 0)
                        {
                            break;
                        }
                    }

                    if (!Bf.occupied[tileCheck])
                    {
                        tileNew = tileCheck;
                    }
                    else
                    {
                        Card target = Bf.Cards[tileCheck];
                        if (target.alignment != dealer.alignment)
                        {
                            if (!dealer.special.flying || target.special.flying)
                            {
                                break;
                            }
                        }
                    }
                }

                AnimaCard animaCard = new AnimaCard();
                if (tileNew != dealer.tile)
                {
                    animaCard.MoveBfBf(dealer, dealer.tile, tileNew);
                }
            }
        }
    }

    public void CheckArmorAuraBattlecry(Card dealer)
    {
        if (dealer.special.armorAura > 0)
        {
            Tile tile = new Tile();
            List<Card> allies = tile.GetAllOtherAllies(dealer);

            for (int i = 0; i < allies.Count; i++)
            {
                UnitSpecial unitSpecial = new UnitSpecial();
                unitSpecial.IncreaseArmor(dealer, allies[i], dealer.special.armorAura);
            }
        }
    }

    public void CheckArmorAuraSummon(Card dealer)
    {
        Tile tile = new Tile();
        List<Card> allies = tile.GetAllOtherAllies(dealer);

        for (int i = 0; i < allies.Count; i++)
        {
            if (allies[i].special.armorAura > 0)
            {
                UnitSpecial unitSpecial = new UnitSpecial();
                unitSpecial.IncreaseArmor(allies[i], dealer, allies[i].special.armorAura);
            }
        }
    }

    public void CheckBleedingAttack(Card dealer, Card target)
    {
        if (dealer.special.bleedingAttack)
        {
            target.special.bleeding = true;
        }
    }

    public void CheckInfluence(Card dealer)
    {
        if (dealer.special.influence)
        {
            int iMin = 0;
            int iMax = Hand.SIZE;
            if (dealer.alignment == Card.Alignment.Enemy)
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
                Hand.Cards[rnd].attack += 1;
                Hand.Cards[rnd].health += 1;
                Hand.Cards[rnd].healthMax += 1;

                if (rnd < Hand.SIZE)
                {
                    dealer.DisplayCard(Hand.Hands[rnd], Hand.Cards[rnd]);
                }
            }
        }
    }

    public void CheckHeadbuttAttack(Card dealer, Card target)
    {
        if (dealer.special.headbutt)
        {
            Tile tile = new Tile();
            int tileNew = tile.GetTileInFront(target, 1, true);

            if (tileNew != target.tile)
            {
                AnimaCard animaCard = new AnimaCard();
                animaCard.MoveBfBf(target, target.tile, tileNew);
            }
        }
    }

    public void CheckHeadbuttMove(Card dealer)
    {
        if (dealer.special.headbutt)
        {
            if (dealer.attackedThisTurn)
            {
                Tile tile = new Tile();
                int tileNew = tile.GetTileInFront(dealer, 1);

                if (tileNew != dealer.tile)
                {
                    AnimaCard animaCard = new AnimaCard();
                    animaCard.MoveBfBf(dealer, dealer.tile, tileNew);
                }
            }
        }
    }

    public bool CheckThunderstorm(Card dealer)
    {
        if (dealer.special.thunderStorm > 0)
        {
            Tile tile = new Tile();
            List<Card> enemies = tile.GetAllEnemies(dealer);
            if (enemies.Count > 0)
            {
                UnitAttack unitAttack = new UnitAttack();
                for (int i = 0; i < enemies.Count; i++)
                {
                    unitAttack.DealDamage(dealer, enemies[i], dealer.special.thunderStorm, Card.DamageType.Magical, false);
                }

                return true;
            }
        }
        return false;
    }
}
