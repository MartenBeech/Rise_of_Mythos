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

        SpecialTrigger trigger = new SpecialTrigger();
        
        if (trigger.OnTurnEnd(dealer))
        {
            externalAttackAnimation = true;
        }

        Special special = new Special();
        if (special.CheckWhirlwind(dealer))
        { }
        else if (special.CheckVililanceAttack(dealer)) 
        { }
        else
        {
            if (dealer.alignment == Card.Alignment.Ally)
            {
                for (int i = 0; i < dealer.range; i++)
                {
                    tileCheck += 3;
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
                            return;
                        }
                    }
                }
                if (!externalAttackAnimation)
                    UnitAction.counter -= UI.TIMER;
            }
            else
            {
                for (int i = 0; i < dealer.range; i++)
                {
                    tileCheck -= 3;
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
                            return;
                        }
                    }
                }
                if (!externalAttackAnimation)
                    UnitAction.counter -= UI.TIMER;
            }
        }
    }

    public bool AttackAlignment(Card dealer, Card target)
    {
        if (target.alignment != dealer.alignment)
        {
            Special special = new Special();
            target = special.CheckMartyrdom(target);
            for (int i = 0; i < dealer.special.multistrike + 1; i++)
            {
                if (Bf.occupied[dealer.tile] && Bf.occupied[target.tile])
                {
                    special.CheckFirstStrike(dealer, target);
                    if (Bf.occupied[dealer.tile])
                    {
                        DealDamage(dealer, target, dealer.attack);
                        special.CheckPierce(dealer, target);
                        if (Bf.occupied[target.tile])
                        {
                            special.CheckCounterattack(dealer, target);
                            special.CheckKnockback(dealer, target);
                        }
                    }
                }
            }
            return true;
        }
        return false;
    }

    public void DealDamage(Card dealer, Card target, int damage, bool basicAttack = true)
    {
        damage += dealer.bonusAttackNextTurn;

        SpecialTrigger trigger = new SpecialTrigger();
        damage = trigger.OnDamageDealt(dealer, target, damage, basicAttack);

        if (damage >= 0)
        {
            AnimaText animaText = new AnimaText();
            animaText.ShowText(Bf.Bfs[target.tile], damage.ToString(), Hue.red);
        }

        if (damage > 0)
        {
            target.health -= damage;
        }
            
        if (target.health <= 0)
        {
            Bf bf = new Bf();
            bf.RemoveCard(target.tile);

            trigger.OnDeath(target);
        }
        else
        {
            target.DisplayCard(Bf.Bfs[target.tile], target);
        }
        target.DisplayCard(Bf.Bfs[dealer.tile], dealer);

        Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.red;
        
    }

    public void Heal(Card dealer, Card target, int amount)
    {
        AnimaText animaText = new AnimaText();
        animaText.ShowText(Bf.Bfs[target.tile], amount.ToString(), Hue.green);

        Special special = new Special();
        special.CheckFaith(dealer);

        target.health += amount;
        if (target.health > target.healthMax)
        {
            target.health = target.healthMax;
        }
        target.DisplayCard(Bf.Bfs[target.tile], target);
        target.DisplayCard(Bf.Bfs[dealer.tile], dealer);

        Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.green;
    }

    public void IncreaseHealth(Card dealer, Card target, int amount)
    {
        AnimaText animaText = new AnimaText();
        animaText.ShowText(Bf.Bfs[target.tile], amount.ToString(), Hue.green);

        target.health += amount;
        target.healthMax += amount;

        target.DisplayCard(Bf.Bfs[target.tile], target);

        Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.green;
    }

    public void DecreaseHealth(Card dealer, Card target, int amount)
    {
        AnimaText animaText = new AnimaText();
        animaText.ShowText(Bf.Bfs[target.tile], amount.ToString(), Hue.red);

        if (target.health > amount)
            target.health -= amount;
        else
            target.health = 1;

        if (target.healthMax > amount)
            target.healthMax -= amount;
        else
            target.healthMax = 1;

        target.DisplayCard(Bf.Bfs[target.tile], target);

        Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.red;
    }

    public void IncreaseRegeneration(Card dealer, Card target, int amount)
    {
        AnimaText animaText = new AnimaText();
        animaText.ShowText(Bf.Bfs[target.tile], "+" + amount + " Regen", Hue.green);

        target.special.regeneration += amount;

        Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.green;
    }
}
