using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialInfo : MonoBehaviour
{
    public string GetCardInfo(Card card)
    {
        string text =
            "<b>" + "Attack: " + "</b>" + card.attack + "\n" +
            "<b>" + "Health: " + "</b>" + card.health + "/" + card.healthMax + "\n\n" +

            (card.special.wall ? "<b>" + "Wall: " + "</b>" + "Can't move or attack" + "\n" : "") +
            (card.special.archer ? "<b>" + "Archer: " + "</b>" + "+2 Range" + "\n" : "") +
            (card.special.cavalry ? "<b>" + "Cavalry: " + "</b>" + "+2 Speed" + "\n" : "") +
            (card.special.flying ? "<b>" + "Flying: " + "</b>" + "Can fly over non-flying enemies" + "\n" : "") +
            (card.special.vigilance ? "<b>" + "Vigilance: " + "</b>" + "Can attack adjacent enemies, attacking backwards in preference" + "\n" : "") +
            (card.special.armor > 0 ? "<b>" + "Armor " + card.special.armor + ": " + "</b>" + "Take reduced physical damage" + "\n" : "") +
            (card.special.resistance > 0 ? "<b>" + "Resistance " + card.special.resistance + ": " + "</b>" + "Take reduced magical damage" + "\n" : "") +
            (card.special.cure > 0 ? "<b>" + "Cure " + card.special.cure + ": " + "</b>" + "Heal the most damaged ally each turn" + "\n" : "") +
            (card.special.heroic > 0 ? "<b>" + "Heroic " + card.special.heroic + ": " + "</b>" + "Gain attack after dealing damage" + "\n" : "") +
            (card.special.lifeHuman > 0 ? "<b>" + "Life Human " + card.special.lifeHuman + ": " + "</b>" + "Allied Humans have +3 health" + "\n" : "") +
            (card.special.lifeUndead > 0 ? "<b>" + "Life Undead " + card.special.lifeUndead + ": " + "</b>" + "Allied Undeads have +3 health" + "\n" : "") +
            (card.special.charge ? "<b>" + "Charge: " + "</b>" + "For each 2 tiles moved, deal +1 damage on the next attack. Deals double damage to Archers" + "\n" : "") +
            (card.special.pierce ? "<b>" + "Pierce: " + "</b>" + "Also deals damage to the enemy behind the target" + "\n" : "") +
            (card.special.penetrate ? "<b>" + "Penetrate: " + "</b>" + "Damage can not be reduced" + "\n" : "") +
            (card.special.kingsCommand ? "<b>" + "King's Command: " + "</b>" + "Summons a Horseman of same rank each turn" + "\n" : "") +
            (card.special.combatMaster ? "<b>" + "Combat Master: " + "</b>" + "Deals double damage to enemies with Archer, Cavalry, Armor, Wall or Flying" + "\n" : "");

        return text;
    }
}
