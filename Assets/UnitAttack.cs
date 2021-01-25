using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitAttack : MonoBehaviour
{
    public void Attack(Card card)
    {
        int tileCheck = card.tile;

        Special special = new Special();
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
                UnitAction.counter -= UI.TIMER;
            }
        }
    }

    public void DealDamage(Card dealer, Card target, int damage, Card.DamageType damageType = Card.DamageType.Physical)
    {
        Special special = new Special();
        damage = special.CheckArmor(dealer, target, damage);
        damage = special.CheckResistance(dealer, target, damage);

        AnimaText animaText = new AnimaText();
        animaText.ShowText(Bf.Bfs[target.tile], damage.ToString(), Hue.red);
    }
}
