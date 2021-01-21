using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitMove : MonoBehaviour
{
    public void Move(Card card)
    {
        int tileNew = card.tile;
        int tileCheck = card.tile;

        if (card.alignment == Card.Alignment.Ally)
        {
            for (int i = 0; i < card.speed; i++)
            {
                tileCheck += 3;

                if (!Bf.occupied[tileCheck])
                {
                    tileNew += 3;
                }
                else
                {
                    if (Bf.Cards[tileCheck].alignment != card.alignment)
                    {
                        break;
                    }
                }
            }
        }
        else
        {

        }

        AnimaCard animaCard = new AnimaCard();
        animaCard.MoveBfBf(card, card.tile, tileNew);
    }
}
