using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTurn : MonoBehaviour
{
    public static float counter;
    public static int cardRunThrough = Hand.SIZE;
    private void Update()
    {
        if (counter > 0)
        {
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                PlayHand();
            }
        }
    }

    public void PlayHand()
    {
        for (int i = cardRunThrough; i < Hand.SIZE * 2; i++)
        {
            if (Hand.occupied[i])
            {
                if (Hand.Cards[i].cd == 0)
                {
                    if (SummonCard(i, GetPreferredColumn(Hand.Cards[i])))
                    {
                        cardRunThrough = i + 1;
                        counter = UI.TIMER * 1.04f;
                        return;
                    }
                }
            }
        }
        Turn turn = new Turn();
        turn.EndTurn();
    }

    public bool SummonCard(int handSpace, Bf.Column preferredColumn)
    {
        List<int> summonTiles = new List<int>();
        Rng rng = new Rng();
        int iMin, iMax;
        switch(preferredColumn)
        {
            case Bf.Column.Back:
                iMin = Bf.SIZE - 2;
                iMax = Bf.SIZE;
                break;

            case Bf.Column.Middle:
                iMin = Bf.SIZE - 4;
                iMax = Bf.SIZE - 2;
                break;

            case Bf.Column.Front:
                iMin = Bf.SIZE - 6;
                iMax = Bf.SIZE - 4;
                break;

            case Bf.Column.Wall:
                iMin = Bf.SIZE - 10;
                iMax = Bf.SIZE - 6;
                break;

            case Bf.Column.Random:
                iMin = Bf.SIZE - 6;
                iMax = Bf.SIZE;
                for (int i = Bf.SIZE - 6; i < Bf.SIZE; i++)
                {
                    if (!Bf.occupied[i])
                        summonTiles.Add(i);
                }
                if (summonTiles.Count > 0)
                {
                    SummonCard(handSpace, summonTiles[rng.Range(0, summonTiles.Count)]);
                    return true;
                }
                return false;

            default:
                return SummonCard(handSpace, Bf.Column.Random);
        }

        for (int i = iMin; i < iMax; i++)
        {
            if (!Bf.occupied[i])
                summonTiles.Add(i);
        }
        if (summonTiles.Count > 0)
        {
            SummonCard(handSpace, summonTiles[rng.Range(0, summonTiles.Count)]);
            return true;
        }
        return SummonCard(handSpace, Bf.Column.Random);
    }

    public void SummonCard(int from, int to)
    {
        AnimaCard animaCard = new AnimaCard();
        animaCard.MoveEnemyBf(Hand.Cards[from], from, to);
    }

    public Bf.Column GetPreferredColumn(Card card)
    {
        if (card.special.wall)
            return Bf.Column.Wall;
        if (card.speed >= 4)
            return Bf.Column.Front;
        if (card.range >= 4)
            return Bf.Column.Back;
        if (card.speed <= 1)
            return Bf.Column.Front;

        return Bf.Column.Random;
    }
}
