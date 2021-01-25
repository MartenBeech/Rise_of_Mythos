using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Special : MonoBehaviour
{
    public int armor = 0;
    public int resistance = 0;
    public bool vigilance = false;
    public int cure = 0;

    public int CheckArmor(Card dealer, Card target, int damage)
    {
        if (target.special.armor > 0)
        {
            if (dealer.damageType == Card.DamageType.Physical)
            {
                damage -= target.special.armor;
            }
        }
        if (damage < 0)
            damage = 0;

        return damage;
    }

    public int CheckResistance(Card dealer, Card target, int damage)
    {
        if (target.special.resistance > 0)
        {
            if (dealer.damageType == Card.DamageType.Magical)
            {
                damage -= target.special.resistance;
            }
        }
        if (damage < 0)
            damage = 0;

        return damage;
    }

    public bool CheckVililanceMove(Card dealer)
    {
        if (dealer.special.vigilance)
        {
            Tile tile = new Tile();
            if (tile.GetNearbyEnemies(dealer).Count > 0)
            {
                return false;
            }
        }
        return true;
    }

    public bool CheckVililanceAttack(Card dealer)
    {
        if (dealer.special.vigilance)
        {
            Tile tile = new Tile();
            List<Card> enemies = tile.GetNearbyEnemies(dealer);
            if (enemies.Count > 0)
            {
                UnitAttack unitAttack = new UnitAttack();
                unitAttack.DealDamage(dealer, enemies[0], dealer.attack);
                return false;
            }
        }
        return true;
    }

    public void CheckCure(Card dealer)
    {
        Tile tile = new Tile();
        List<Card> allies = tile.GetAllAllies(dealer);
        int mostDamage = 0;
        int mostDamageTile;

        for (int i = 0; i < allies.Count; i++)
        {

        }
    }
}
