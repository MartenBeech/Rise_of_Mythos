using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSpecial : MonoBehaviour
{
    public void Heal(Card dealer, Card target, int amount)
    {
        if (dealer.occupied && target.occupied)
        {
            if (target.special.bleeding)
                amount = 0;

            AnimaText animaText = new AnimaText();
            animaText.ShowText(Bf.Bfs[target.tile], amount.ToString(), Hue.green);

            if (amount > 0)
            {
                Special special = new Special();
                special.CheckFaith(dealer);

                target.health[target.rank] += amount;
                if (target.health[target.rank] > target.healthMax[target.rank])
                {
                    target.health[target.rank] = target.healthMax[target.rank];
                }
            }

            target.DisplayCard(Bf.Bfs[target.tile], target);
            target.DisplayCard(Bf.Bfs[dealer.tile], dealer);

            Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.green;
        }
    }

    public void IncreaseHealth(Card dealer, Card target, int amount)
    {
        if (dealer.occupied && target.occupied)
        {
            AnimaText animaText = new AnimaText();
            animaText.ShowText(Bf.Bfs[target.tile], "+" + amount + "Health", Hue.cyan);

            target.health[target.rank] += amount;
            target.healthMax[target.rank] += amount;

            target.DisplayCard(Bf.Bfs[target.tile], target);

            Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.cyan;
        }
    }

    public void IncreaseAttack(Card dealer, Card target, int amount)
    {
        if (dealer.occupied && target.occupied)
        {
            AnimaText animaText = new AnimaText();
            animaText.ShowText(Bf.Bfs[target.tile], "+" + amount + "Attack", Hue.cyan);

            target.attack[target.rank] += amount;

            target.DisplayCard(Bf.Bfs[target.tile], target);

            Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.cyan;
        }
    }

    public void DecreaseHealth(Card dealer, Card target, int amount)
    {
        if (dealer.occupied && target.occupied)
        {
            if (!target.special.nimble)
            {
                AnimaText animaText = new AnimaText();
                animaText.ShowText(Bf.Bfs[target.tile], "-" + amount + " Health", Hue.magenta);

                if (target.health[target.rank] > amount)
                    target.health[target.rank] -= amount;
                else
                    target.health[target.rank] = 1;

                if (target.healthMax[target.rank] > amount)
                    target.healthMax[target.rank] -= amount;
                else
                    target.healthMax[target.rank] = 1;

                target.DisplayCard(Bf.Bfs[target.tile], target);

                Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.magenta;
            }
        }
    }

    public void IncreaseRegeneration(Card dealer, Card target, int amount)
    {
        if (dealer.occupied && target.occupied)
        {
            AnimaText animaText = new AnimaText();
            animaText.ShowText(Bf.Bfs[target.tile], "+" + amount + " Regen", Hue.cyan);

            target.special.regeneration[target.rank] += amount;

            Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.cyan;
        }
    }

    public void IncreaseRange(Card dealer, Card target, int amount)
    {
        if (dealer.occupied && target.occupied)
        {
            AnimaText animaText = new AnimaText();
            animaText.ShowText(Bf.Bfs[target.tile], "+" + amount + " Range", Hue.cyan);

            if (target.range > 0)
                target.range += amount;

            Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.cyan;
        }
    }

    public void IncreaseSpeed(Card dealer, Card target, int amount)
    {
        if (dealer.occupied && target.occupied)
        {
            AnimaText animaText = new AnimaText();
            animaText.ShowText(Bf.Bfs[target.tile], "+" + amount + " Speed", Hue.cyan);

            if (target.speed > 0)
                target.speed += amount;

            Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.cyan;
        }
    }

    public void DecreaseSpeed(Card dealer, Card target)
    {
        if (dealer.occupied && target.occupied)
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
    }

    public void DecreaseRange(Card dealer, Card target)
    {
        if (dealer.occupied && target.occupied)
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
    }

    public void IncreaseHerosBane(Card dealer, Card target, int amount)
    {
        if (dealer.occupied && target.occupied)
        {
            AnimaText animaText = new AnimaText();
            animaText.ShowText(Bf.Bfs[target.tile], "+" + amount + " Hero's Bane", Hue.cyan);

            target.special.herosBane[target.rank] += amount;

            Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.cyan;
        }
    }

    public void IncreasePenetrate(Card dealer, Card target)
    {
        if (dealer.occupied && target.occupied)
        {
            AnimaText animaText = new AnimaText();
            animaText.ShowText(Bf.Bfs[target.tile], "Penetrate", Hue.cyan);

            target.special.penetrate = true;

            Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.cyan;
        }
    }

    public void IncreasePoison(Card dealer, Card target, int amount)
    {
        if (dealer.occupied && target.occupied)
        {
            AnimaText animaText = new AnimaText();
            animaText.ShowText(Bf.Bfs[target.tile], "+" + amount + " Poison", Hue.cyan);

            target.special.poison[target.rank] += amount;

            Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.cyan;
        }
    }

    public void IncreaseArmor(Card dealer, Card target, int amount)
    {
        if (dealer.occupied && target.occupied)
        {
            AnimaText animaText = new AnimaText();
            animaText.ShowText(Bf.Bfs[target.tile], "+" + amount + " Armor", Hue.cyan);

            target.special.armor[target.rank] += amount;

            Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.cyan;
        }
    }

    public void IncreaseResistance(Card dealer, Card target, int amount)
    {
        if (dealer.occupied && target.occupied)
        {
            AnimaText animaText = new AnimaText();
            animaText.ShowText(Bf.Bfs[target.tile], "+" + amount + " Resistance", Hue.cyan);

            target.special.resistance[target.rank] += amount;

            Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.cyan;
        }
    }

    public void IncreaseFlying(Card dealer, Card target)
    {
        if (dealer.occupied && target.occupied)
        {
            AnimaText animaText = new AnimaText();
            animaText.ShowText(Bf.Bfs[target.tile], "Flying", Hue.cyan);

            target.special.flying = true;

            Bf.Bfs[dealer.tile].GetComponentInChildren<Image>().color = Hue.cyan;
        }
    }
}
