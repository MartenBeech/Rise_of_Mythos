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
        if (special.CheckCure(dealer))
        {
            externalAttackAnimation = true;
        }
        if (special.CheckSummonUnitEndTurn(dealer))
        {
            externalAttackAnimation = true;
        }

        if (special.CheckWhirlwind(dealer)) { }

        else if (special.CheckVililanceAttack(dealer)) { }

        else
        {
            if (dealer.alignment == Card.Alignment.Ally)
            {
                for (int i = 0; i < dealer.range; i++)
                {
                    tileCheck += 3;
                    if (tileCheck >= Bf.SIZE)
                    {
                        break;
                    }

                    if (Bf.occupied[tileCheck])
                    {
                        Card target = Bf.Cards[tileCheck];
                        if (target.alignment != dealer.alignment)
                        {
                            special.CheckPierce(dealer, target);
                            DealDamage(dealer, target, dealer.attack);
                            if (special.CheckCounterattack(dealer, Bf.Cards[tileCheck]))
                            {

                            }
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
                    if (tileCheck < 0)
                    {
                        break;
                    }

                    if (Bf.occupied[tileCheck])
                    {
                        Card target = Bf.Cards[tileCheck];
                        if (target.alignment != dealer.alignment)
                        {
                            special.CheckPierce(dealer, target);
                            DealDamage(dealer, target, dealer.attack);
                            return;
                        }
                    }
                }
                if (!externalAttackAnimation)
                    UnitAction.counter -= UI.TIMER;
            }
        }
    }

    public void DealDamage(Card dealer, Card target, int damage)
    {
        damage += dealer.bonusAttackNextTurn;

        if (damage > 0)
        {
            Special special = new Special();
            damage = special.CheckArmor(dealer, target, damage);
            damage = special.CheckResistance(dealer, target, damage);
            damage = special.CheckChargeAttack(dealer, target, damage);
            damage = special.CheckCombatMaster(dealer, target, damage);

            AnimaText animaText = new AnimaText();
            animaText.ShowText(Bf.Bfs[target.tile], damage.ToString(), Hue.red);

            special.CheckHeroic(dealer);

            target.health -= damage;
            if (target.health <= 0)
            {
                Bf bf = new Bf();
                bf.RemoveCard(target.tile);
            }
            else
            {
                target.DisplayCard(Bf.Bfs[target.tile], target);
            }
            target.DisplayCard(Bf.Bfs[dealer.tile], dealer);

            Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.red;
        }
    }

    public void Heal(Card dealer, Card target, int amount)
    {
        AnimaText animaText = new AnimaText();
        animaText.ShowText(Bf.Bfs[target.tile], amount.ToString(), Hue.green);

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
        target.DisplayCard(Bf.Bfs[dealer.tile], dealer);

        Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.green;
    }
}
