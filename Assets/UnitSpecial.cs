using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSpecial : MonoBehaviour
{
    public void Heal(Card dealer, Card target, int amount)
    {
        AnimaText animaText = new AnimaText();
        animaText.ShowText(Bf.Bfs[target.tile], amount.ToString(), Hue.green);

        Special special = new Special();
        special.CheckFaith(dealer);

        target.health += amount;
        if (target.health > target.healthMax)
        {
            target.health = target.healthMax;
        }
        target.DisplayCard(Bf.Bfs[target.tile], target);
        target.DisplayCard(Bf.Bfs[dealer.tile], dealer);

        Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.green;
    }

    public void IncreaseHealth(Card dealer, Card target, int amount)
    {
        AnimaText animaText = new AnimaText();
        animaText.ShowText(Bf.Bfs[target.tile], amount.ToString(), Hue.green);

        target.health += amount;
        target.healthMax += amount;

        target.DisplayCard(Bf.Bfs[target.tile], target);

        Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.green;
    }

    public void DecreaseHealth(Card dealer, Card target, int amount)
    {
        AnimaText animaText = new AnimaText();
        animaText.ShowText(Bf.Bfs[target.tile], amount.ToString(), Hue.red);

        if (target.health > amount)
            target.health -= amount;
        else
            target.health = 1;

        if (target.healthMax > amount)
            target.healthMax -= amount;
        else
            target.healthMax = 1;

        target.DisplayCard(Bf.Bfs[target.tile], target);

        Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.red;
    }

    public void IncreaseRegeneration(Card dealer, Card target, int amount)
    {
        AnimaText animaText = new AnimaText();
        animaText.ShowText(Bf.Bfs[target.tile], "+" + amount + " Regen", Hue.green);

        target.special.regeneration += amount;

        Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.green;
    }

    public void IncreaseRange(Card dealer, Card target, int amount)
    {
        AnimaText animaText = new AnimaText();
        animaText.ShowText(Bf.Bfs[target.tile], "+" + amount + " Range", Hue.green);

        target.range += amount;

        Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.green;
    }
}
