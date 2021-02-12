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
            "<b>" + "Attack: " + "</b>" + card.attack + " " + card.damageType + "\n" +
            "<b>" + "Health: " + "</b>" + card.health + "/" + card.healthMax + "\n" +
            "<b>" + "Range/Speed: " + "</b>" + card.range + "/" + card.speed + "\n\n" +

            (card.special.wall ? "<b>" + "Wall: " + "</b>" + "Can't move or attack" + "\n" : "") +
            (card.special.flying ? "<b>" + "Flying: " + "</b>" + "Can fly over non-flying enemies" + "\n" : "") +
            (card.special.vigilance ? "<b>" + "Vigilance: " + "</b>" + "Can attack adjacent enemies and won't move if any. Attacks backwards in preference" + "\n" : "") +
            (card.special.penetrate ? "<b>" + "Penetrate: " + "</b>" + "Your damage dealt cannot be reduced" + "\n" : "") +
            (card.special.armor > 0 ? "<b>" + "Armor " + card.special.armor + ": " + "</b>" + "Take reduced physical damage" + "\n" : "") +
            (card.special.resistance > 0 ? "<b>" + "Resistance " + card.special.resistance + ": " + "</b>" + "Take reduced magical damage" + "\n" : "") +
            (card.special.cure > 0 ? "<b>" + "Cure " + card.special.cure + ": " + "</b>" + "Heal the most damaged ally each turn" + "\n" : "") +
            (card.special.heroic > 0 ? "<b>" + "Heroic " + card.special.heroic + ": " + "</b>" + "Gain attack after dealing damage" + "\n" : "") +
            (card.special.regeneration > 0 ? "<b>" + "Regeneration " + card.special.regeneration + ": " + "</b>" + "Heal yourself each turn" + "\n" : "") +
            (card.special.multistrike > 0 ? "<b>" + "Multistrike " + card.special.multistrike + ": " + "</b>" + "Attacks hit additional times" + "\n" : "") +
            (card.special.weaken > 0 ? "<b>" + "Weaken " + card.special.weaken + ": " + "</b>" + "Attacks reduce the target's attack value" + "\n" : "") +
            (card.special.shadowBolt > 0 ? "<b>" + "Shadow Bolt " + card.special.shadowBolt + ": " + "</b>" + "Attacks deal 0-" + card.special.shadowBolt + "00% damage" + "\n" : "") +
            (card.special.poison > 0 ? "<b>" + "Poison " + card.special.poison + ": " + "</b>" + "Attacks causes the target to take magical damage each turn" + "\n" : "") +
            (card.special.poisoned > 0 ? "<b>" + "Poisoned " + card.special.poisoned + ": " + "</b>" + "You take magical damage each turn" + "\n" : "") +
            (card.special.immolate > 0 ? "<b>" + "Immolate " + card.special.immolate + ": " + "</b>" + "You take magical damage each turn" + "\n" : "") +
            (card.special.reapingCurse > 0 ? "<b>" + "Reaping Curse " + card.special.reapingCurse + ": " + "</b>" + "Upon dying, deal damage to the enemy hero" + "\n" : "") +
            (card.special.soulEater > 0 ? "<b>" + "Soul Eater " + card.special.soulEater + ": " + "</b>" + "Gain +" + card.special.soulEater + "/+" + card.special.soulEater + " whenever you attack the enemy hero" + "\n" : "") +
            (card.special.spellCurse > 0 ? "<b>" + "Spell Curse " + card.special.spellCurse + ": " + "</b>" + "Attacks curse the enemy to take increased magical damage" + "\n" : "") +
            (card.special.spellCursed > 0 ? "<b>" + "Spell Cursed " + card.special.spellCursed + ": " + "</b>" + "You take increased magical damage" + "\n" : "") +
            (card.special.spellFeed > 0 ? "<b>" + "Spell Feed " + card.special.spellFeed + ": " + "</b>" + "Gain +" + card.special.spellFeed + "/+" + card.special.spellFeed + " whenever you take magical damage" + "\n" : "") +
            (card.special.inspiration > 0 ? "<b>" + "Inspiration " + card.special.inspiration + ": " + "</b>" + "Reduce the countdown of the card in your hand with the highest countdown" + "\n" : "") +
            (card.special.herosBane > 0 ? "<b>" + "Hero's Bane " + card.special.herosBane + ": " + "</b>" + "Deal damage to the enemy hero each turn" + "\n" : "") +
            (card.special.embered > 0 ? "<b>" + "Embered " + card.special.embered + ": " + "</b>" + "You take magical damage next turn" + "\n" : "") +
            (card.special.lightningBolt > 0 ? "<b>" + "Lightning Bolt " + card.special.lightningBolt + ": " + "</b>" + "Deal damage to a random enemy unit each turn" + "\n" : "") +
            (card.special.rage > 0 ? "<b>" + "Rage " + card.special.rage + ": " + "</b>" + "Gain attack whenever you take damage" + "\n" : "") +
            (card.special.carnivore > 0 ? "<b>" + "Carnivore " + card.special.carnivore + ": " + "</b>" + "Gain health whenever you kill a unit" + "\n" : "") +
            (card.special.bloodPrice > 0 ? "<b>" + "Blood Price " + card.special.bloodPrice + ": " + "</b>" + "Deal damage to your own hero each turn" + "\n" : "") +
            (card.special.maim > 0 ? "<b>" + "Maim " + card.special.maim + ": " + "</b>" + "Attacks causes the enemy to take increased physical damage" + "\n" : "") +
            (card.special.maimed > 0 ? "<b>" + "Maimed " + card.special.maimed + ": " + "</b>" + "You take increased physical damage" + "\n" : "") +


            (card.special.lifeAura > 0 ? "<b>" + "Life Aura " + card.special.lifeAura + ": " + "</b>" + "Allied units get bonus health" + "\n" : "") +
            (card.special.regenerationAura > 0 ? "<b>" + "Regeneration Aura " + card.special.regenerationAura + ": " + "</b>" + "Allied units get Regeneration" + "\n" : "") +
            (card.special.witheringAura > 0 ? "<b>" + "Withering Aura " + card.special.witheringAura + ": " + "</b>" + "Enemy units get decreased health" + "\n" : "") +
            (card.special.rangeAura > 0 ? "<b>" + "Range Aura " + card.special.rangeAura + ": " + "</b>" + "Allied units get bonus range" + "\n" : "") +
            (card.special.attackAura > 0 ? "<b>" + "Attack Aura " + card.special.rangeAura + ": " + "</b>" + "Allied units get bonus attack" + "\n" : "") +
            (card.special.blizzardAura ? "<b>" + "Blizzard Aura: " + "</b>" + "Enemy units have -1 Range and Speed" + "\n" : "") +
            (card.special.herosBaneAura > 0 ? "<b>" + "Hero's Bane Aura " + card.special.herosBaneAura + ": " + "</b>" + "Allied units get Hero's Bane" + "\n" : "") +
            (card.special.penetrateAura ? "<b>" + "Penetrate Aura: " + "</b>" + "Allied units get Penetrate" + "\n" : "") +


            (card.special.charge ? "<b>" + "Charge: " + "</b>" + "For each tile moved, deal +1 damage on the next attack" + "\n" : "") +
            (card.special.pierce ? "<b>" + "Pierce: " + "</b>" + "Also deals damage to the enemy behind the target" + "\n" : "") +
            (card.special.whirlwind ? "<b>" + "Whirlwind: " + "</b>" + "Attack all adjacent enemies" + "\n" : "") +
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
            (card.special.freezing ? "<b>" + "Freezing: " + "</b>" + "Damaged targets have their speed reduced by 1, but not less than 1" + "\n" : "") +
            (card.special.incorporeal ? "<b>" + "Incorporeal: " + "</b>" + "Physical damage you receive is reduced to 1" + "\n" : "") +
            (card.special.fear ? "<b>" + "Fear: " + "</b>" + "First unit attacked returns to it's owner's hand" + "\n" : "") +
            (card.special.skeletal ? "<b>" + "Skeletal: " + "</b>" + "Upon dying, turn into a Bone Heap which reanimates this unit next turn" + "\n" : "") +
            (card.special.boneHeap ? "<b>" + "Bone Heap: " + "</b>" + "Reanimate the collapsed body at the end of your turn" + "\n" : "") +
            (card.special.vengefulCurse ? "<b>" + "Vengeful Curse: " + "</b>" + "Attacking curses the target's next attack to also damage itself" + "\n" : "") +
            (card.special.vengefulCursed ? "<b>" + "Vengeful Cursed: " + "</b>" + "Your next attack also damages yourself" + "\n" : "") +
            (card.special.panicStrike ? "<b>" + "Panic Strike: " + "</b>" + "Attacking the enemy hero causes a random enemy card to gain +1 CD" + "\n" : "") +
            (card.special.sniper ? "<b>" + "Sniper: " + "</b>" + "Always attack the lowest health enemy in range" + "\n" : "") +
            (card.special.ember ? "<b>" + "Ember: " + "</b>" + "Attacks deal magical damage next turn instead of immediately" + "\n" : "") +
            (card.special.nimble ? "<b>" + "Nimble: " + "</b>" + "Your core stats cannot be reduced" + "\n" : "") +
            (card.special.conjure ? "<b>" + "Conjure: " + "</b>" + "Draw a card when summoned" + "\n" : "") +
            (card.special.donor ? "<b>" + "Donor: " + "</b>" + "Draw a card upon death" + "\n" : "") +
            (card.special.stun ? "<b>" + "Stun: " + "</b>" + "Your first attack stuns the target, skipping its next turn" + "\n" : "") +
            (card.special.stunned ? "<b>" + "Stunned: " + "</b>" + "Your next turn is skipped" + "\n" : "") +
            (card.special.distraction ? "<b>" + "Distraction: " + "</b>" + "Increase the countdown of a random enemy card each turn" + "\n" : "") +
            (card.special.spear ? "<b>" + "Spear: " + "</b>" + "Deal double damage to units with 4+ Speed" + "\n" : "") +
            (card.special.ambush ? "<b>" + "Ambush: " + "</b>" + "Your first attack deals double damage" + "\n" : "") +
            (card.special.crushArmor ? "<b>" + "Crush Armor: " + "</b>" + "Deal double damage to units with Armor or Resistance" + "\n" : "") +

            (card.special.kingsCommand ? "<b>" + "King's Command: " + "</b>" + "Summons a Horseman of same rank each turn" + "\n" : "") +
            (card.special.combatMaster ? "<b>" + "Combat Master: " + "</b>" + "Deals double damage to enemies with 4+ Range, 4+ Speed, Armor, Wall or Flying" + "\n" : "") +
            (card.special.callOfTheUndeadKing ? "<b>" + "Call of the Undead King: " + "</b>" + "Whenever an enemy dies, a zombie is summoned in its place" + "\n" : "") +
            (card.special.frostSuit ? "<b>" + "Frost Suit: " + "</b>" + "Upon taking damage, reduced the attacker's speed to 0" + "\n" : "") +
            (card.special.soulHarvest ? "<b>" + "Soul Harvest: " + "</b>" + "Whenever an enemy dies, gain half its Attack and Health" + "\n" : "") +
            (card.special.multiShot ? "<b>" + "Multishot: " + "</b>" + "Attack all enemy units and heroes inside range" + "\n" : "") +
            (card.special.reinforcement ? "<b>" + "Reinforcement: " + "</b>" + "On summon, also summon 2 copies of this unit on the same column" + "\n" : "") +
            (card.special.disdain > 0 ? "<b>" + "Disdain " + card.special.disdain + ": " + "</b>" + "Damagine units with " + card.special.disdain + " or less countdown instantly kills them" + "\n" : "") +
            (card.special.cheif ? "<b>" + "Cheif: " + "</b>" + "On summon, gain +1/+3 for each other allied unit" + "\n" : "") +


            "";

        return text;
    }
}
