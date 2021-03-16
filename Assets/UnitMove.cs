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
        if (special.CheckBackstabMove(dealer)) { }
        else if (special.CheckVigilanceMove(dealer)) { }
        else
        {
            for (int i = 0; i < dealer.speed; i++)
            {
                if (!Bf.occupied[tileCheck] || tileCheck == dealer.tile)
                {
                    if (dealer.range >= 4)
                    {
                        Tile tile = new Tile();
                        if (tile.GetEnemiesInFront(dealer, tileCheck, dealer.range).Count > 0)
                        {
                            break;
                        }
                        if (tile.GetDistanceToEnemyHero(dealer, tileCheck) <= dealer.range)
                        {
                            break;
                        }
                    }
                }

                if (dealer.alignment == Card.Alignment.Ally)
                {
                    tileCheck += 2;
                    if (tileCheck >= Bf.SIZE)
                    {
                        break;
                    }
                }
                else
                {
                    tileCheck -= 2;
                    if (tileCheck < 0)
                    {
                        break;
                    }
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
                        if (!dealer.special.flying || target.special.flying || target.special.levitate)
                        {
                            break;
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
