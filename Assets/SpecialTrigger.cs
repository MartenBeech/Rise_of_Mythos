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
        special.CheckWitheringAuraBattlecry(card);
        special.CheckWitheringAuraSummon(card);
    }

    public void OnDeath(Card target)
    {
        special.CheckReanimate(target);
        special.CheckSkeletal(target);
        special.CheckReapingCurse(target);
        special.CheckSoulbound(target);
        if (!Bf.occupied[target.tile])
        {
            special.CheckCallOfTheUndeadKing(target);
            special.CheckSoulHarvest(target);
        }
            
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

        special.CheckInspiration(dealer);

        return externalAttackAnimation;
    }

    public int OnDamageDealt(Card dealer, Card target, int damage, bool basicAttack = true)
    {
        damage = special.CheckArmor(dealer, target, damage);
        damage = special.CheckSpellCursed(dealer, target, damage);
        damage = special.CheckResistance(dealer, target, damage);
        if (basicAttack)
        {
            damage = special.CheckShadowBolt(dealer, damage);
            damage = special.CheckCombatMaster(dealer, target, damage);
            damage = special.CheckDragonSlayer(dealer, target, damage);
            damage = special.CheckEmber(dealer, target, damage);
        }
        damage = special.CheckIncorporeal(dealer, target, damage);

        if (basicAttack)
        {
            special.CheckDispel(dealer, target);
        }

        if (damage > 0)
        {
            special.CheckSpellFeed(dealer, target);

            if (basicAttack)
            {
                special.CheckLifeSteal(dealer, damage);
                special.CheckHeroic(dealer);
                special.CheckWeaken(dealer, target);
                special.CheckFreezing(dealer, target);
                special.CheckFrostSuit(dealer, target);
                special.CheckPoison(dealer, target);
                special.CheckVengefulCurse(dealer, target);
                special.CheckVengefulCursed(dealer);
                special.CheckSpellCurse(dealer, target);

                special.CheckFear(dealer, target, damage);
            }
        }
        

        return damage;
    }
}
