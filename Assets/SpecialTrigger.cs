using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialTrigger : MonoBehaviour
{
    Special special = new Special();
    public void Battlecry(Card card)
    {
        special.CheckLifeAuraBattlecry(card);
        special.CheckLifeAuraSummon(card);
        special.CheckRegenerationAuraBattlecry(card);
        special.CheckRegenerationAuraSummon(card);
    }
}
