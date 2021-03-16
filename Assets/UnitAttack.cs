using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitAttack : MonoBehaviour
{
    public void Attack(Card dealer)
    {
        int tileCheck = dealer.tile;
        bool externalAttackAnimation = false;

        Special special = new Special();
        if (special.CheckWhirlwind(dealer))
            externalAttackAnimation = true;
        else if (special.CheckBackstabAttack(dealer))
            externalAttackAnimation = true;
        else if (special.CheckVigilanceAttack(dealer))
            externalAttackAnimation = true;
        else if (special.CheckMultiShot(dealer))
            externalAttackAnimation = true;
        else if (special.CheckSniper(dealer))
            externalAttackAnimation = true;
        else
        {
            if (dealer.alignment == Card.Alignment.Ally)
            {
                for (int i = 0; i < dealer.range; i++)
                {
                    tileCheck += 2;
                    if (!dealer.canAttackThisTurn)
                    {
                        break;
                    }

                    else if (tileCheck >= Bf.SIZE)
                    {
                        Hero hero = new Hero();
                        hero.AttackHero(dealer, Card.Alignment.Enemy);
                        externalAttackAnimation = true;
                        break;
                    }

                    else if (Bf.occupied[tileCheck])
                    {
                        if (AttackAlignment(dealer, Bf.Cards[tileCheck]))
                        {
                            externalAttackAnimation = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < dealer.range; i++)
                {
                    tileCheck -= 2;
                    if (!dealer.canAttackThisTurn)
                    {
                        break;
                    }

                    else if (tileCheck < 0)
                    {
                        Hero hero = new Hero();
                        hero.AttackHero(dealer, Card.Alignment.Ally);
                        externalAttackAnimation = true;
                        break;
                    }

                    else if (Bf.occupied[tileCheck])
                    {
                        if (AttackAlignment(dealer, Bf.Cards[tileCheck]))
                        {
                            externalAttackAnimation = true;
                            break;
                        }
                    }
                }
            }
        }
        SpecialTrigger trigger = new SpecialTrigger();
        if (trigger.OnTurnEnd(dealer))
        {
            externalAttackAnimation = true;
        }

        if (!externalAttackAnimation)
            UnitAction.counter -= UI.TIMER;
    }

    public bool AttackAlignment(Card dealer, Card target)
    {
        if (target.alignment != dealer.alignment)
        {
            Special special = new Special();
            target = special.CheckMartyrdom(target);
            for (int i = 0; i < dealer.special.multistrike[dealer.rank] + 1; i++)
            {
                if (Bf.occupied[dealer.tile] && Bf.occupied[target.tile])
                {
                    special.CheckFirstStrike(dealer, target);
                    if (Bf.occupied[dealer.tile])
                    {
                        dealer.attackedThisTurn = true;
                        DealDamage(dealer, target, dealer.attack[dealer.rank], dealer.damageType);
                        special.CheckPierce(dealer, target);
                        special.CheckCleave(dealer, target);
                        if (Bf.occupied[target.tile])
                        {
                            special.CheckCounterattack(dealer, target);
                        }
                    }
                }
            }
            if (Bf.occupied[target.tile])
            {
                special.CheckKnockback(dealer, target);
                special.CheckHeadbuttAttack(dealer, target);
            }
            return true;
        }
        return false;
    }

    public void DealDamage(Card dealer, Card target, int damage, Card.DamageType damageType, bool basicAttack = true)
    {
        damage += dealer.bonusAttackNextTurn;

        SpecialTrigger trigger = new SpecialTrigger();
        damage = trigger.OnDamageDealt(dealer, target, damage, damageType, basicAttack);

        if (damage >= 0)
        {
            AnimaText animaText = new AnimaText();
            animaText.ShowText(Bf.Bfs[target.tile], damage.ToString(), Hue.red);
        }

        if (damage > 0)
        {
            target.health[target.rank] -= damage;
        }
            
        if (target.health[target.rank] <= 0)
        {
            Bf bf = new Bf();
            bf.RemoveCard(target.tile);

            trigger.OnDeath(target);
            trigger.OnKill(dealer);
        }
        else
        {
            target.DisplayCard(Bf.Bfs[target.tile], target);
        }
        target.DisplayCard(Bf.Bfs[dealer.tile], dealer);

        if (Bf.occupied[dealer.tile])
            Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.red;
    }
}
