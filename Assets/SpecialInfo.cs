using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialInfo : MonoBehaviour
{
    public string GetCardInfo(Card card)
    {
        string _title = card.title.ToString();
        for (int j = 1; j < _title.Length; j++)
        {
            if ((int)_title[j] >= 65 && (int)_title[j] <= 90) //Capital Letters
            {
                _title = _title.Insert(j, " ");
                j++;
            }
        }

        string text =
            "<b>" + card.nameTag + "</b>" + " (" + card.cdDefault + ")" + "\n" +
            "<b>" + "Attack: " + "</b>" + card.attack + "\n" +
            "<b>" + "Health: " + "</b>" + card.health + "/" + card.healthMax + "\n" +
            "<b>" + "Range/Speed: " + "</b>" + card.range + "/" + card.speed + "\n\n" +

            (card.special.wall ? "<b>" + "Wall: " + "</b>" + "Can't move or attack" + "\n" : "") +
            (card.special.flying ? "<b>" + "Flying: " + "</b>" + "Can fly over non-flying enemies" + "\n" : "") +
            (card.special.vigilance ? "<b>" + "Vigilance: " + "</b>" + "Can attack adjacent enemies and won't move if any. Attacks backwards in preference" + "\n" : "") +
            (card.special.penetrate ? "<b>" + "Penetrate: " + "</b>" + "Damage can not be reduced" + "\n" : "") +
            (card.special.magical ? "<b>" + "Magical: " + "</b>" + "Attacks deal magical damage" + "\n" : "") +
            (card.special.armor > 0 ? "<b>" + "Armor " + card.special.armor + ": " + "</b>" + "Take reduced physical damage" + "\n" : "") +
            (card.special.resistance > 0 ? "<b>" + "Resistance " + card.special.resistance + ": " + "</b>" + "Take reduced magical damage" + "\n" : "") +
            (card.special.cure > 0 ? "<b>" + "Cure " + card.special.cure + ": " + "</b>" + "Heal the most damaged ally each turn" + "\n" : "") +
            (card.special.heroic > 0 ? "<b>" + "Heroic " + card.special.heroic + ": " + "</b>" + "Gain attack after dealing damage" + "\n" : "") +
            (card.special.regeneration > 0 ? "<b>" + "Regeneration " + card.special.regeneration + ": " + "</b>" + "Heal yourself each turn" + "\n" : "") +
            (card.special.multistrike > 0 ? "<b>" + "Multistrike " + card.special.multistrike + ": " + "</b>" + "Attacks hit additional times" + "\n" : "") +
            (card.special.weaken > 0 ? "<b>" + "Weaken " + card.special.weaken + ": " + "</b>" + "Attacks reduce the target's attack value" + "\n" : "") +
            (card.special.shadowBolt > 0 ? "<b>" + "Shadow Bolt " + card.special.shadowBolt + ": " + "</b>" + "Attacks deal 0-" + card.special.shadowBolt + "00% damage" + "\n" : "") +

            (card.special.lifeAura > 0 ? "<b>" + "Life Aura " + card.special.lifeAura + ": " + "</b>" + "Allied units have bonus health" + "\n" : "") +
            (card.special.regenerationAura > 0 ? "<b>" + "Regeneration Aura " + card.special.regenerationAura + ": " + "</b>" + "Allied units have Regeneration" + "\n" : "") +
            (card.special.witheringAura > 0 ? "<b>" + "Withering Aura " + card.special.witheringAura + ": " + "</b>" + "Enemy units have decreased health" + "\n" : "") +

            (card.special.charge ? "<b>" + "Charge: " + "</b>" + "For each tile moved, deal +1 damage on the next attack" + "\n" : "") +
            (card.special.pierce ? "<b>" + "Pierce: " + "</b>" + "Also deals damage to the enemy behind the target" + "\n" : "") +
            (card.special.whirlwind ? "<b>" + "Whirlwind: " + "</b>" + "Can attack all adjacent enemies" + "\n" : "") +
            (card.special.counterattack ? "<b>" + "Counterattack: " + "</b>" + "Can retaliate if attacked inside its range" + "\n" : "") +
            (card.special.firstStrike ? "<b>" + "First Strike: " + "</b>" + "Can retaliate before being attacked inside its range" + "\n" : "") +
            (card.special.dispel ? "<b>" + "Dispel: " + "</b>" + "Attacking an enemy first reduces their attack and health to their normal values" + "\n" : "") +
            (card.special.faith ? "<b>" + "Faith: " + "</b>" + "Healing a unit grants you +1/+1" + "\n" : "") +
            (card.special.martyrdom ? "<b>" + "Martyrdom: " + "</b>" + "Redirect all damage taken by nearby allies towards yourself" + "\n" : "") +
            (card.special.heavyWeapon ? "<b>" + "Heavy Weapon: " + "</b>" + "Can not attack after moving" + "\n" : "") +
            (card.special.dragonSlayer ? "<b>" + "Dragon Slayer: " + "</b>" + "Deal double damage to units with 5+ CD" + "\n" : "") +
            (card.special.knockback ? "<b>" + "Knockback: " + "</b>" + "Damaged targets will be knocked back 2 tiles" + "\n" : "") +
            (card.special.reanimate ? "<b>" + "Reanimate: " + "</b>" + "This unit is resummoned the first time it dies" + "\n" : "") +
            (card.special.lifeSteal ? "<b>" + "Life Steal: " + "</b>" + "Restore your health equal to damage dealt" + "\n" : "") +
            (card.special.soulbound ? "<b>" + "Soulbound: " + "</b>" + "This unit is returned to it's owner's hand first time it dies" + "\n" : "") +
            (card.special.freezing ? "<b>" + "Freezing: " + "</b>" + "Damaged targets have their speed reduced to 1" + "\n" : "") +
            (card.special.incorporeal ? "<b>" + "Incorporeal: " + "</b>" + "Physical damage you receive is reduced to 1" + "\n" : "") +
            (card.special.fear ? "<b>" + "Fear: " + "</b>" + "First unit attacked returns to it's owner's hand" + "\n" : "") +

            (card.special.kingsCommand ? "<b>" + "King's Command: " + "</b>" + "Summons a Horseman of same rank each turn" + "\n" : "") +
            (card.special.combatMaster ? "<b>" + "Combat Master: " + "</b>" + "Deals double damage to enemies with 4+ Range, 4+ Speed, Armor, Wall or Flying" + "\n" : "") +
            (card.special.callOfTheUndeadKing ? "<b>" + "Call of the Undead King: " + "</b>" + "Whenever an enemy dies, a zombie is summoned in its place" + "\n" : "") +
            (card.special.frostSuit ? "<b>" + "Frost Suit: " + "</b>" + "Upon taking damage, reduced the attacker's speed to 0" + "\n" : "") +

            "";

        return text;
    }
}
