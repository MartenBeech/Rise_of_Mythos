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

        Special special = new Special();
        if (!special.CheckVililanceMove(card)) { }

        else
        {
            if (card.alignment == Card.Alignment.Ally)
            {
                for (int i = 0; i < card.speed; i++)
                {
                    tileCheck += 3;
                    if (tileCheck >= Bf.SIZE)
                    {
                        break;
                    }

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
                for (int i = 0; i < card.speed; i++)
                {
                    tileCheck -= 3;
                    if (tileCheck < 0)
                    {
                        break;
                    }

                    if (!Bf.occupied[tileCheck])
                    {
                        tileNew -= 3;
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
        }
        
        AnimaCard animaCard = new AnimaCard();
        if (tileNew != card.tile)
        {
            animaCard.MoveBfBf(card, card.tile, tileNew);
        }
        else
        {
            UnitAction.counter -= UI.TIMER;
        }
    }
}
