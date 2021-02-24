using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public List<int> GetNearbyTiles(Card card)
    {
        int center = card.tile;
        int row = center % 2;
        List<int> tiles = new List<int>();

        if (center >= 2)
        {
            tiles.Add(center - 2);

            if (row == 0)
            {
                tiles.Add(center - 1);
            }
            if (row == 1)
            {
                tiles.Add(center - 3);
            }
        }
        
        if (center < Bf.SIZE - 3)
        {
            tiles.Add(center + 2);

            if (row == 0)
            {
                tiles.Add(center + 3);
            }
            if (row == 1)
            {
                tiles.Add(center + 1);
            }
        }

        if (row == 0)
        {
            tiles.Add(center + 1);
        }
        if (row == 1)
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

    public List<Card> GetAllEnemies(Card card)
    {
        List<Card> enemies = new List<Card>();
        for (int i = 0; i < Bf.SIZE; i++)
        {
            if (Bf.occupied[i])
            {
                if (Bf.Cards[i].alignment != card.alignment)
                {
                    enemies.Add(Bf.Cards[i]);
                }
            }
        }

        return enemies;
    }

    public List<Card> GetAllOtherAllies(Card card)
    {
        List<Card> allies = new List<Card>();
        for (int i = 0; i < Bf.SIZE; i++)
        {
            if (Bf.occupied[i])
            {
                if (i != card.tile)
                {
                    if (Bf.Cards[i].alignment == card.alignment)
                    {
                        allies.Add(Bf.Cards[i]);
                    }
                }
            }
        }
        return allies;
    }

    public List<Card> GetNearbyAllies(Card card)
    {
        List<Card> allies = new List<Card>();
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
                if (Bf.Cards[tiles[i]].alignment == card.alignment)
                {
                    allies.Add(Bf.Cards[tiles[i]]);
                }
            }
        }
        return allies;
    }

    public int GetTileInFront(Card card, int tiles, bool reverseDirection = false)
    {
        int tileNew = card.tile;
        Card.Alignment alignment = card.alignment;
        if (reverseDirection)
        {
            if (card.alignment == Card.Alignment.Ally)
            {
                alignment = Card.Alignment.Enemy;
            }
            else
            {
                alignment = Card.Alignment.Ally;
            }
        }

        if (alignment == Card.Alignment.Ally)
        {
            for (int i = card.tile + 2; i <= card.tile + (tiles * 2); i += 2)
            {
                if (i < Bf.SIZE)
                {
                    if (!Bf.occupied[i])
                    {
                        tileNew = i;
                    }
                }
                else
                {
                    break;
                }
            }
        }
        else
        {
            for (int i = card.tile - 2; i >= card.tile - (tiles * 2); i -= 2)
            {
                if (i >= 0)
                {
                    if (!Bf.occupied[i])
                    {
                        tileNew = i;
                    }
                }
                else
                {
                    break;
                }
            }
        }
        return tileNew;
    }

    public List<Card> GetEnemiesInFront(Card card, int startTile, int tiles, bool reverseDirection = false)
    {
        List<Card> enemies = new List<Card>();
        Card.Alignment alignment = card.alignment;
        if (reverseDirection)
        {
            if (card.alignment == Card.Alignment.Ally)
            {
                alignment = Card.Alignment.Enemy;
            }
            else
            {
                alignment = Card.Alignment.Ally;
            }
        }

        if (alignment == Card.Alignment.Ally)
        {
            for (int i = startTile + 2; i <= startTile + (tiles * 2); i += 2)
            {
                if (i < Bf.SIZE)
                {
                    if (Bf.occupied[i])
                    {
                        if (Bf.Cards[i].alignment != card.alignment)
                        {
                            enemies.Add(Bf.Cards[i]);
                        }
                    }
                }
                else
                {
                    break;
                }
            }
        }
        else
        {
            for (int i = startTile - 2; i >= startTile - (tiles * 2); i -= 2)
            {
                if (i >= 0)
                {
                    if (Bf.occupied[i])
                    {
                        if (Bf.Cards[i].alignment != card.alignment)
                        {
                            enemies.Add(Bf.Cards[i]);
                        }
                    }
                }
                else
                {
                    break;
                }
            }
        }
        return enemies;
    }

    public int GetDistanceToEnemyHero(Card card, int startTile, bool reverseDirection = false)
    {
        Card.Alignment alignment = card.alignment;
        if (reverseDirection)
        {
            if (card.alignment == Card.Alignment.Ally)
            {
                alignment = Card.Alignment.Enemy;
            }
            else
            {
                alignment = Card.Alignment.Ally;
            }
        }

        if (alignment == Card.Alignment.Ally)
        {
            return (((Bf.SIZE + 1) - startTile) / 2);
        }
        else
        {
            return ((2 + startTile) / 2);
        }
    }

    public int GetDistanceBetweenUnits(Card from, Card to)
    {
        return ((Mathf.Abs(from.tile - to.tile) + 1) / 2);
    }

    public List<int> GetTilesOnSameColumn(Card card)
    {
        List<int> tiles = new List<int>();
        if (card.tile % 2 == 0)
        {
            tiles.Add(card.tile + 1);
        }
        else if (card.tile % 2 == 1)
        {
            tiles.Add(card.tile - 1);
        }
        return tiles;
    }
}
