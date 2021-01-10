using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private int attack = 5, attackStart = 5;
    private int health = 10, healthStart = 10;
    private int cost = 3, costStart = 3;
    private int speed = 2, speedStart = 2;
    private int range = 2, rangeStart = 2;

    private Sprite sprite = Resources.Load<Sprite>("Units/Paladin");

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
