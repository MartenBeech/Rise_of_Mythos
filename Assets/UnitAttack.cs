using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitAttack : MonoBehaviour
{
    public void Attack(Card card)
    {
        int tileCheck = card.tile;
        bool externalDamageDealt = false;

        Special special = new Special();
        if (special.CheckCure(card))
        {
            externalDamageDealt = true;
        }
        if (special.CheckSummonUnitEndTurn(card))
        {
            externalDamageDealt = true;
        }

        if (!special.CheckVililanceAttack(card)) { }

        else
        {
            if (card.alignment == Card.Alignment.Ally)
            {
                for (int i = 0; i < card.range; i++)
                {
                    tileCheck += 3;
                    if (tileCheck >= Bf.SIZE)
                    {
                        break;
                    }

                    if (Bf.occupied[tileCheck])
                    {
                        if (Bf.Cards[tileCheck].alignment != card.alignment)
                        {
                            DealDamage(card, Bf.Cards[tileCheck], card.attack);
                            return;
                        }
                    }
                }
                if (!externalDamageDealt)
                    UnitAction.counter -= UI.TIMER;
            }
            else
            {
                for (int i = 0; i < card.range; i++)
                {
                    tileCheck -= 3;
                    if (tileCheck < 0)
                    {
                        break;
                    }

                    if (Bf.occupied[tileCheck])
                    {
                        if (Bf.Cards[tileCheck].alignment != card.alignment)
                        {
                            DealDamage(card, Bf.Cards[tileCheck], card.attack);
                            return;
                        }
                    }
                }
                if (!externalDamageDealt)
                    UnitAction.counter -= UI.TIMER;
            }
        }
    }

    public void DealDamage(Card dealer, Card target, int damage, Card.DamageType damageType = Card.DamageType.Physical)
    {
        if (damage > 0)
        {
            Special special = new Special();
            damage = special.CheckArmor(dealer, target, damage);
            damage = special.CheckResistance(dealer, target, damage);

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
