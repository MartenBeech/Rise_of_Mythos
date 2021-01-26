using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public enum Title
    {
        Paladin, Captain
    }

    public enum Alignment
    {
        Ally, Enemy
    }
    public Alignment alignment;

    public enum DamageType
    {
        Physical, Magical, True
    }
    public DamageType damageType;

    public enum Race
    {
        Human, Undead, Elf, Halfblood
    }
    public Race race;

    public int attack,      attackDefault;
    public int health,      healthDefault;
    public int healthMax,   healthMaxDefault;
    public int cd,          cdDefault;

    public int speed;
    public int range;
    public int tile;

    public bool readyToAttack = false;
    public Sprite sprite;
    public Special special = new Special();

    public void DisplayCard(GameObject gameObject, Card card)
    {
        gameObject.GetComponentInChildren<Text>().text = "<color=red>" + card.attack + "</color>" + " / " + "<color=green>" + card.health + "</color>";
        gameObject.GetComponentInChildren<Image>().sprite = card.sprite;
    }

    public void DisplayNull(GameObject gameObject)
    {
        gameObject.GetComponentInChildren<Text>().text = null;
        gameObject.GetComponentInChildren<Image>().sprite = null;
    }
}
