using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitMove : MonoBehaviour
{
    public void Move(Card dealer)
    {
        int tileNew = dealer.tile;
        int tileCheck = dealer.tile;

        Special special = new Special();
        if (special.CheckVililanceMove(dealer)) { }

        else
        {
            if (dealer.alignment == Card.Alignment.Ally)
            {
                for (int i = 0; i < dealer.speed; i++)
                {
                    tileCheck += 3;
                    if (tileCheck >= Bf.SIZE)
                    {
                        break;
                    }

                    if (!Bf.occupied[tileCheck])
                    {
                        tileNew = tileCheck;
                    }
                    else
                    {
                        Card target = Bf.Cards[tileCheck];
                        if (target.alignment != dealer.alignment)
                        {
                            if (!dealer.special.flying || target.special.flying)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < dealer.speed; i++)
                {
                    tileCheck -= 3;
                    if (tileCheck < 0)
                    {
                        break;
                    }

                    if (!Bf.occupied[tileCheck])
                    {
                        tileNew = tileCheck;
                    }
                    else
                    {
                        Card target = Bf.Cards[tileCheck];
                        if (target.alignment != dealer.alignment)
                        {
                            if (!dealer.special.flying || target.special.flying)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
        
        AnimaCard animaCard = new AnimaCard();
        if (tileNew != dealer.tile)
        {
            special.CheckHeavyWeapon(dealer);
            special.CheckChargeMove(dealer, dealer.tile, tileNew);
            animaCard.MoveBfBf(dealer, dealer.tile, tileNew);
        }
        else
        {
            UnitAction.counter -= UI.TIMER;
        }
    }
}
