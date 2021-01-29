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
            "<b>" + "Health: " + "</b>" + card.health + "/" + card.healthMax + "\n" +
            "<b>" + "Range/Speed: " + "</b>" + card.range + "/" + card.speed + "\n\n" +

            (card.special.wall ? "<b>" + "Wall: " + "</b>" + "Can't move or attack" + "\n" : "") +
            (card.special.flying ? "<b>" + "Flying: " + "</b>" + "Can fly over non-flying enemies" + "\n" : "") +
            (card.special.vigilance ? "<b>" + "Vigilance: " + "</b>" + "Can attack adjacent enemies and won't move if any. Attacks backwards in preference" + "\n" : "") +
            (card.special.penetrate ? "<b>" + "Penetrate: " + "</b>" + "Damage can not be reduced" + "\n" : "") +
            (card.special.armor > 0 ? "<b>" + "Armor " + card.special.armor + ": " + "</b>" + "Take reduced physical damage" + "\n" : "") +
            (card.special.resistance > 0 ? "<b>" + "Resistance " + card.special.resistance + ": " + "</b>" + "Take reduced magical damage" + "\n" : "") +
            (card.special.cure > 0 ? "<b>" + "Cure " + card.special.cure + ": " + "</b>" + "Heal the most damaged ally each turn" + "\n" : "") +
            (card.special.heroic > 0 ? "<b>" + "Heroic " + card.special.heroic + ": " + "</b>" + "Gain attack after dealing damage" + "\n" : "") +
            (card.special.regeneration > 0 ? "<b>" + "Regeneration " + card.special.regeneration + ": " + "</b>" + "Heal yourself each turn" + "\n" : "") +
            (card.special.lifeAura > 0 ? "<b>" + "Life Aura " + card.special.lifeAura + ": " + "</b>" + "Allied units have bonus health" + "\n" : "") +
            (card.special.charge ? "<b>" + "Charge: " + "</b>" + "For each 2 tiles moved, deal +1 damage on the next attack. Deals double damage to enemies with 4+ Range" + "\n" : "") +
            (card.special.pierce ? "<b>" + "Pierce: " + "</b>" + "Also deals damage to the enemy behind the target" + "\n" : "") +
            (card.special.whirlwind ? "<b>" + "Whirlwind: " + "</b>" + "Can attack all adjacent enemies" + "\n" : "") +
            (card.special.counterattack ? "<b>" + "Counterattack: " + "</b>" + "Can retaliate if attacked inside its range" + "\n" : "") +
            (card.special.firstStrike ? "<b>" + "First Strike: " + "</b>" + "Can retaliate before being attacked inside its range" + "\n" : "") +
            (card.special.dispel ? "<b>" + "Dispel: " + "</b>" + "Attacking an enemy first reduces their attack and health to their normal values" + "\n" : "") +
            (card.special.faith ? "<b>" + "Faith: " + "</b>" + "Healing a unit grants you +1/+1" + "\n" : "") +
            (card.special.martyrdom ? "<b>" + "Martyrdom: " + "</b>" + "Redirect all damage taken by nearby allies towards yourself" + "\n" : "") +

            (card.special.kingsCommand ? "<b>" + "King's Command: " + "</b>" + "Summons a Horseman of same rank each turn" + "\n" : "") +
            (card.special.combatMaster ? "<b>" + "Combat Master: " + "</b>" + "Deals double damage to enemies with 4+ Range, 4+ Speed, Armor, Wall or Flying" + "\n" : "");

        return text;
    }
}
