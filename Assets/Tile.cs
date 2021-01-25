using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public List<int> GetNearbyTiles(Card card)
    {
        int center = card.tile;
        int row = center % 3;
        List<int> tiles = new List<int>();

        if (center >= 3)
        {
            tiles.Add(center - 3);

            if (row == 0 || row == 1)
            {
                tiles.Add(center - 2);
            }
            if (row == 2 || row == 1)
            {
                tiles.Add(center - 4);
            }
        }
        
        if (center < Bf.SIZE - 3)
        {
            tiles.Add(center + 3);

            if (row == 0 || row == 1)
            {
                tiles.Add(center + 4);
            }
            if (row == 2 || row == 1)
            {
                tiles.Add(center + 2);
            }
        }

        if (row == 0 || row == 1)
        {
            tiles.Add(center + 1);
        }
        if (row == 2 || row == 1)
        {
            tiles.Add(center - 1);
        }

        return tiles;
    }

    public List<Card> GetNearbyEnemies(Card card)
    {
        List<Card> enemies = new List<Card>();
        List<int> tiles = GetNearbyTiles(card);
        if (card.alignment == Card.Alignment.Ally)
        {
            tiles.Sort();
        }
        else
        {
            tiles.Sort();
            tiles.Reverse();
        }

        for (int i = 0; i < tiles.Count; i++)
        {
            if (Bf.occupied[tiles[i]])
            {
                if (Bf.Cards[tiles[i]].alignment != card.alignment)
                {
                    enemies.Add(Bf.Cards[tiles[i]]);
                }
            }
        }
        return enemies;
    }

    public List<Card> GetAllAllies(Card card)
    {
        List<Card> allies = new List<Card>();
        for (int i = 0; i < Bf.SIZE; i++)
        {
            if (Bf.occupied[i])
            {
                if (Bf.Cards[i].alignment == card.alignment)
                {
                    allies.Add(Bf.Cards[i]);
                }
            }
        }

        return allies;
    }
}
