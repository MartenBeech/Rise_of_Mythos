using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialTrigger : MonoBehaviour
{
    Special special = new Special();
    public void OnSummon(Card card)
    {
        special.CheckLifeAuraBattlecry(card);
        special.CheckLifeAuraSummon(card);
        special.CheckRegenerationAuraBattlecry(card);
        special.CheckRegenerationAuraSummon(card);
    }

    public void OnDeath(Card card)
    {
        special.CheckReanimate(card);
        special.CheckCallOfTheUndeadKing(card);
    }

    public void OnTurnEnd(Card card)
    {

    }
}
