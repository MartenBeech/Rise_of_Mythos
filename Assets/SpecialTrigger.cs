using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialTrigger : MonoBehaviour
{
    Special special = new Special();
    public void Battlecry(Card card)
    {
        special.CheckLifeBonusBattlecry(card);
        special.CheckLifeBonusAura(card);
    }
}
