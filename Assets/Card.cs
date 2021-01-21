using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public enum Title
    {
        Paladin
    }

    public enum Alignment
    {
        Ally, Enemy
    }
    public Alignment alignment;

    public int attack,  attackDefault;
    public int health,  healthDefault;
    public int cd,      cdDefault;
    public int speed,   speedDefault;
    public int range,   rangeDefault;

    public int tile;

    public Sprite sprite = Resources.Load<Sprite>("Cards/Paladin");

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
