using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitAttack : MonoBehaviour
{
    public void Attack(Card card)
    {
        int tileCheck = card.tile;

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
                        DealDamage(card.tile, tileCheck, card.attack);
                        break;
                    }
                }

                UnitAction.counter -= UI.TIMER;
            }
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
                        DealDamage(card.tile, tileCheck, card.attack);
                        break;
                    }
                }

                UnitAction.counter -= UI.TIMER;
            }
        }
    }

    public void DealDamage(int from, int to, int damage, Card.DamageType damageType = Card.DamageType.Physical)
    {
        if (Bf.occupied[from] && Bf.occupied[to])
        {
            Card dealer = Bf.Cards[from];
            Card target = Bf.Cards[to];

            AnimaText animaText = new AnimaText();
            animaText.ShowText(Bf.Bfs[to], damage.ToString(), Hue.red);
        }
    }
}
