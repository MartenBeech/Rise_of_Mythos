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
        special.CheckWitheringAuraBattlecry(card);
        special.CheckWitheringAuraSummon(card);
    }

    public void OnDeath(Card card)
    {
        special.CheckReanimate(card);
        special.CheckSoulBound(card);
        special.CheckCallOfTheUndeadKing(card);
    }

    public bool OnTurnEnd(Card dealer)
    {
        bool externalAttackAnimation = false;
        if (special.CheckCure(dealer))
        {
            externalAttackAnimation = true;
        }
        if (special.CheckRegeneration(dealer))
        {
            externalAttackAnimation = true;
        }
        if (special.CheckSummonUnitEndTurn(dealer))
        {
            externalAttackAnimation = true;
        }
        return externalAttackAnimation;
    }

    public int OnDamageDealt(Card dealer, Card target, int damage)
    {
        damage = special.CheckArmor(dealer, target, damage);
        damage = special.CheckResistance(dealer, target, damage);
        damage = special.CheckChargeAttack(dealer, target, damage);
        damage = special.CheckShadowBolt(dealer, damage);
        damage = special.CheckCombatMaster(dealer, target, damage);
        damage = special.CheckDragonSlayer(dealer, target, damage);

        special.CheckDispel(dealer, target);

        if (damage > 0)
        {
            special.CheckLifeSteal(dealer, damage);
            special.CheckHeroic(dealer);
            special.CheckWeaken(dealer, target);
        }

        return damage;
    }
}
