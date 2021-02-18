using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialTrigger : MonoBehaviour
{
    Special special = new Special();
    public void OnSummon(Card card)
    {
        special.CheckLifeAuraBattlecry(card);
        special.CheckLifeAuraSummon(card);
        special.CheckRegenerationAuraBattlecry(card);
        special.CheckRegenerationAuraSummon(card);
        special.CheckRangeAuraBattlecry(card);
        special.CheckRangeAuraSummon(card);
        special.CheckSpeedAuraBattlecry(card);
        special.CheckSpeedAuraSummon(card);
        special.CheckWitheringAuraBattlecry(card);
        special.CheckWitheringAuraSummon(card);
        special.CheckBlizzardAuraBattlecry(card);
        special.CheckBlizzardAuraSummon(card);
        special.CheckAttackAuraBattlecry(card);
        special.CheckAttackAuraSummon(card);
        special.CheckHerosBaneAuraBattlecry(card);
        special.CheckHerosBaneAuraSummon(card);
        special.CheckPenetrateAuraBattlecry(card);
        special.CheckPenetrateAuraSummon(card);
        special.CheckPoisonAuraBattlecry(card);
        special.CheckPoisonAuraSummon(card);
        special.CheckArmorAuraBattlecry(card);
        special.CheckArmorAuraSummon(card);

        special.CheckReinforcement(card);
        special.CheckConjure(card);
        special.CheckCheif(card);
    }

    public void OnDeath(Card target)
    {
        special.CheckReanimate(target);
        special.CheckSkeletal(target);
        special.CheckReapingCurse(target);
        special.CheckSoulbound(target);
        if (!Bf.occupied[target.tile])
        {
            special.CheckDonor(target);
            special.CheckCallOfTheUndeadKing(target);
            special.CheckSoulHarvest(target);
        } 
    }

    public void OnKill(Card dealer)
    {
        special.CheckCarnivore(dealer);
    }

    public bool OnTurnEnd(Card dealer)
    {
        bool externalAttackAnimation = false;
        if (special.CheckCure(dealer))
            externalAttackAnimation = true;
        if (special.CheckRegeneration(dealer))
            externalAttackAnimation = true;
        if (special.CheckSummonUnitEndTurn(dealer))
            externalAttackAnimation = true;
        if (special.CheckBoneHeap(dealer))
            externalAttackAnimation = true;
        if (special.CheckDamageTakenEachTurn(dealer))
            externalAttackAnimation = true;
        if (special.CheckHerosBane(dealer))
            externalAttackAnimation = true;
        if (special.CheckLightningBolt(dealer))
            externalAttackAnimation = true;
        if (special.CheckBloodPrice(dealer))
            externalAttackAnimation = true;

        special.CheckInspiration(dealer);
        special.CheckDistraction(dealer);

        return externalAttackAnimation;
    }

    public int OnDamageDealt(Card dealer, Card target, int damage, Card.DamageType damageType, bool basicAttack = true)
    {
        damage = special.CheckMaimed(dealer, target, damage, damageType);
        damage = special.CheckArmor(dealer, target, damage, damageType);
        damage = special.CheckSpellCursed(dealer, target, damage, damageType);
        damage = special.CheckResistance(dealer, target, damage, damageType);
        if (basicAttack)
        {
            damage = special.CheckShadowBolt(dealer, damage);
            damage = special.CheckCombatMaster(dealer, target, damage);
            damage = special.CheckDragonSlayer(dealer, target, damage);
            damage = special.CheckSpear(dealer, target, damage);
            damage = special.CheckAmbush(dealer, damage);
            damage = special.CheckCrushDefenses(dealer, target, damage);

            damage = special.CheckEmber(dealer, target, damage);
        }
        damage = special.CheckIncorporeal(dealer, target, damage, damageType);

        if (basicAttack)
        {
            special.CheckDispel(dealer, target);
        }

        if (damage > 0)
        {
            special.CheckSpellFeed(dealer, target, damageType);
            special.CheckBattleSpirit(dealer, target, damageType);
            special.CheckRage(target);

            if (basicAttack)
            {
                special.CheckLifeSteal(dealer, damage);
                special.CheckHeroic(dealer);
                special.CheckWeaken(dealer, target);
                special.CheckFrostBolt(dealer, target);
                special.CheckFrostSuit(dealer, target);
                special.CheckPoison(dealer, target);
                special.CheckVengefulCurse(dealer, target);
                special.CheckVengefulCursed(dealer);
                special.CheckSpellCurse(dealer, target);
                special.CheckMaim(dealer, target);
                special.CheckStun(dealer, target);
                special.CheckPermaStun(dealer, target);
                special.CheckCharm(dealer, target);
                special.CheckInfluence(dealer);

                special.CheckFear(dealer, target, damage);
                special.CheckDisdain(dealer, target);
                special.CheckKrush(dealer, target);
            }
        }

        return damage;
    }
}
