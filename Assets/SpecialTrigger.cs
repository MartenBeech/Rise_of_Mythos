using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialTrigger : MonoBehaviour
{
    Special special = new Special();
    public void OnSummon(Card dealer)
    {
        special.CheckLifeAuraBattlecry(dealer);
        special.CheckLifeAuraSummon(dealer);
        special.CheckRegenerationAuraBattlecry(dealer);
        special.CheckRegenerationAuraSummon(dealer);
        special.CheckRangeAuraBattlecry(dealer);
        special.CheckRangeAuraSummon(dealer);
        special.CheckSpeedAuraBattlecry(dealer);
        special.CheckSpeedAuraSummon(dealer);
        special.CheckWitheringAuraBattlecry(dealer);
        special.CheckWitheringAuraSummon(dealer);
        special.CheckBlizzardAuraBattlecry(dealer);
        special.CheckBlizzardAuraSummon(dealer);
        special.CheckAttackAuraBattlecry(dealer);
        special.CheckAttackAuraSummon(dealer);
        special.CheckHerosBaneAuraBattlecry(dealer);
        special.CheckHerosBaneAuraSummon(dealer);
        special.CheckPenetrateAuraBattlecry(dealer);
        special.CheckPenetrateAuraSummon(dealer);
        special.CheckPoisonAuraBattlecry(dealer);
        special.CheckPoisonAuraSummon(dealer);
        special.CheckArmorAuraBattlecry(dealer);
        special.CheckArmorAuraSummon(dealer);
        special.CheckResistanceAuraBattlecry(dealer);
        special.CheckResistanceAuraSummon(dealer);
        special.CheckFlyingAuraSummon(dealer);
        special.CheckFlyingAuraBattlecry(dealer);
        special.CheckPrayerAuraSummon(dealer);
        special.CheckPrayerAuraBattlecry(dealer);
        special.CheckRageAuraSummon(dealer);
        special.CheckRageAuraBattlecry(dealer);

        special.CheckReinforcement(dealer);
        special.CheckConjure(dealer);
        special.CheckCheif(dealer);
        special.CheckHealingHand(dealer);
    }

    public void OnDeath(Card target)
    {
        if (target.returnedToHand)
        {
            target.returnedToHand = false;
        }
        else
        {
            special.CheckReanimate(target);
            special.CheckSkeletal(target);
            special.CheckReapingCurse(target);
            if (!Bf.occupied[target.tile])
            {
                special.CheckSoulbound(target);
                special.CheckDonor(target);
                special.CheckCallOfTheUndeadKing(target);
                special.CheckSoulHarvest(target);
            }
        }
    }

    public void OnKill(Card dealer)
    {
        special.CheckCarnivore(dealer);
    }

    public bool OnTurnEnd(Card dealer)
    {
        bool externalAttackAnimation = false;
        if (special.CheckBoneHeap(dealer))
            externalAttackAnimation = true;
        if (special.CheckCure(dealer))
            externalAttackAnimation = true;
        if (special.CheckRegeneration(dealer))
            externalAttackAnimation = true;
        if (special.CheckKingsCommand(dealer))
            externalAttackAnimation = true;
        if (special.CheckDamageTakenEachTurn(dealer))
            externalAttackAnimation = true;
        if (special.CheckHerosBane(dealer))
            externalAttackAnimation = true;
        if (special.CheckLightningBolt(dealer))
            externalAttackAnimation = true;
        if (special.CheckBloodPrice(dealer))
            externalAttackAnimation = true;
        if (special.CheckThunderstorm(dealer))
            externalAttackAnimation = true;
        if (special.CheckPrayer(dealer))
            externalAttackAnimation = true;

        special.CheckInspiration(dealer);
        special.CheckDistraction(dealer);

        return externalAttackAnimation;
    }

    public int OnDamageDealt(Card dealer, Card target, int _damage, Card.DamageType damageType, bool basicAttack = true)
    {
        int damage = _damage;

        if (basicAttack)
        {
            damage += dealer.bonusAttackNextTurn;

            damage = special.CheckVengeance(dealer, target, damage);
            damage = special.CheckShadowBolt(dealer, damage);
            damage = special.CheckCombatMaster(dealer, target, damage);
            damage = special.CheckDragonSlayer(dealer, target, damage);
            damage = special.CheckSpear(dealer, target, damage);
            damage = special.CheckAmbush(dealer, damage);
            damage = special.CheckCrushDefenses(dealer, target, damage);
        }

        damage = special.CheckMaimed(dealer, target, damage, damageType);
        damage = special.CheckSpellCursed(dealer, target, damage, damageType);

        if (basicAttack)
        {
            damage = special.CheckEmber(dealer, target, damage);
        }
            
        if (damage > 0)
        {
            damage = special.CheckArmor(dealer, target, damage, damageType);
            damage = special.CheckResistance(dealer, target, damage, damageType);

            damage = special.CheckIncorporeal(dealer, target, damage, damageType);
            damage = special.CheckStoneskin(dealer, target, damage);
        }
        

        if (basicAttack)
        {
            special.CheckDispel(dealer, target);

            special.CheckLifeSteal(dealer, damage);
            special.CheckRetribution(dealer, damage);
            special.CheckLifeAbsorb(dealer, damage);
            special.CheckHeroic(dealer);
            special.CheckWeaken(dealer, target);
            special.CheckFrostBolt(dealer, target);
            special.CheckBlackIce(dealer, target);
            special.CheckPoison(dealer, target);
            special.CheckVengefulCurse(dealer, target);
            special.CheckVengefulCursed(dealer);
            special.CheckSpellCurse(dealer, target);
            special.CheckMaim(dealer, target);
            special.CheckStun(dealer, target);
            special.CheckPermaStun(dealer, target);
            special.CheckInfluence(dealer);
            special.CheckBleedingAttack(dealer, target);

            special.CheckConvert(dealer, target);
            special.CheckFear(dealer, target, damage);
            special.CheckDisdain(dealer, target);
            special.CheckKrush(dealer, target);
        }

        if (damage > 0)
        {
            special.CheckSpellFeed(dealer, target, damageType);
            special.CheckBattleSpirit(dealer, target, damageType);
            special.CheckRage(target);
        }

        return damage;
    }
}
