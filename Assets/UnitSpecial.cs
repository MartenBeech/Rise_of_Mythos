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
        animaText.ShowText(Bf.Bfs[target.tile], "+" + amount + "Health", Hue.cyan);

        target.health += amount;
        target.healthMax += amount;

        target.DisplayCard(Bf.Bfs[target.tile], target);

        Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.cyan;
    }

    public void IncreaseAttack(Card dealer, Card target, int amount)
    {
        AnimaText animaText = new AnimaText();
        animaText.ShowText(Bf.Bfs[target.tile], "+" + amount + "Attack", Hue.cyan);

        target.attack += amount;

        target.DisplayCard(Bf.Bfs[target.tile], target);

        Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.cyan;
    }

    public void DecreaseHealth(Card dealer, Card target, int amount)
    {
        if (!target.special.nimble)
        {
            AnimaText animaText = new AnimaText();
            animaText.ShowText(Bf.Bfs[target.tile], "-" + amount + "Health", Hue.magenta);

            if (target.health > amount)
                target.health -= amount;
            else
                target.health = 1;

            if (target.healthMax > amount)
                target.healthMax -= amount;
            else
                target.healthMax = 1;

            target.DisplayCard(Bf.Bfs[target.tile], target);

            Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.magenta;
        }
    }

    public void IncreaseRegeneration(Card dealer, Card target, int amount)
    {
        AnimaText animaText = new AnimaText();
        animaText.ShowText(Bf.Bfs[target.tile], "+" + amount + " Regen", Hue.cyan);

        target.special.regeneration += amount;

        Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.cyan;
    }

    public void IncreaseRange(Card dealer, Card target, int amount)
    {
        AnimaText animaText = new AnimaText();
        animaText.ShowText(Bf.Bfs[target.tile], "+" + amount + " Range", Hue.cyan);

        target.range += amount;

        Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.cyan;
    }

    public void DecreaseSpeed(Card dealer, Card target)
    {
        if (!target.special.nimble)
        {
            AnimaText animaText = new AnimaText();
            animaText.ShowText(Bf.Bfs[target.tile], "-Speed", Hue.magenta);

            if (target.speed > 1)
                target.speed -= 1;

            target.DisplayCard(Bf.Bfs[target.tile], target);

            Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.magenta;
        }
    }

    public void DecreaseRange(Card dealer, Card target)
    {
        if (!target.special.nimble)
        {
            AnimaText animaText = new AnimaText();
            animaText.ShowText(Bf.Bfs[target.tile], "-Range", Hue.magenta);

            if (target.range > 1)
                target.range -= 1;

            target.DisplayCard(Bf.Bfs[target.tile], target);

            Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.magenta;
        }
    }

    public void IncreaseHerosBane(Card dealer, Card target, int amount)
    {
        AnimaText animaText = new AnimaText();
        animaText.ShowText(Bf.Bfs[target.tile], "+" + amount + " Hero's Bane", Hue.cyan);

        target.special.herosBane += amount;

        Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.cyan;
    }

    public void IncreasePenetrate(Card dealer, Card target)
    {
        AnimaText animaText = new AnimaText();
        animaText.ShowText(Bf.Bfs[target.tile], "Penetrate", Hue.cyan);

        target.special.penetrate = true;

        Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.cyan;
    }

    public void IncreasePoison(Card dealer, Card target, int amount)
    {
        AnimaText animaText = new AnimaText();
        animaText.ShowText(Bf.Bfs[target.tile], "+" + amount + " Poison", Hue.cyan);

        target.special.poison += amount;

        Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.cyan;
    }
}
