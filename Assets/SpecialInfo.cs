using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialInfo : MonoBehaviour
{
    public string GetCardInfo(Card card)
    {
        string rangeDiff = "";
        if (card.range != 2)
            rangeDiff = "<b>" + card.range + " Range" + "</b>" + "\n";

        string speedDiff = "";
        if (card.speed != 2)
            speedDiff = "<b>" + card.speed + " Speed" + "</b>" + "\n";


        string text =
            "<b>" + card.nameTag + "</b>" + " (" + (card.rank + 1) + ")" + "\n" +
            "<b>" + "Attack: " + "</b>" + card.attack[card.rank] + " " + card.damageType + "\n" +
            "<b>" + "Health: " + "</b>" + card.health[card.rank] + "/" + card.healthMax[card.rank] + "\n" +
            "<b>" + "CD: " + "</b>" + card.cdDefault + "\n\n" +

            rangeDiff + 
            speedDiff +

            (card.special.flying ? "<b>" + "Flying: " + "</b>" + "Can fly over non-flying enemies" + "\n" : "") +
            (card.special.vigilance ? "<b>" + "Vigilance: " + "</b>" + "Can attack adjacent enemies without moving first. Attacks backwards in preference" + "\n" : "") +
            (card.special.penetrate ? "<b>" + "Penetrate: " + "</b>" + "Damage dealt cannot be reduced" + "\n" : "") +
            (card.special.armor[card.rank] > 0 ? "<b>" + "Armor " + card.special.armor[card.rank] + ": " + "</b>" + "Take reduced physical damage" + "\n" : "") +
            (card.special.resistance[card.rank] > 0 ? "<b>" + "Resistance " + card.special.resistance[card.rank] + ": " + "</b>" + "Take reduced magical damage" + "\n" : "") +
            (card.special.charge[card.rank] > 0 ? "<b>" + "Charge " + card.special.charge[card.rank] + ": " + "</b>" + "For each tile moved, deal +" + card.special.charge[card.rank] + " damage on the next attack" + "\n" : "") +
            (card.special.cure[card.rank] > 0 ? "<b>" + "Cure " + card.special.cure[card.rank] + ": " + "</b>" + "Heal the most damaged ally each turn" + "\n" : "") +
            (card.special.heroic[card.rank] > 0 ? "<b>" + "Heroic " + card.special.heroic[card.rank] + ": " + "</b>" + "Gain attack after dealing damage" + "\n" : "") +
            (card.special.regeneration[card.rank] > 0 ? "<b>" + "Regeneration " + card.special.regeneration[card.rank] + ": " + "</b>" + "Heal this unit each turn" + "\n" : "") +
            (card.special.multistrike[card.rank] > 0 ? "<b>" + "Multistrike " + card.special.multistrike[card.rank] + ": " + "</b>" + "Attacks hit additional times" + "\n" : "") +
            (card.special.weaken[card.rank] > 0 ? "<b>" + "Weaken " + card.special.weaken[card.rank] + ": " + "</b>" + "Attacks reduce the target's attack value" + "\n" : "") +
            (card.special.shadowBolt[card.rank] > 0 ? "<b>" + "Shadow Bolt " + card.special.shadowBolt[card.rank] + ": " + "</b>" + "Attacks randomly deal between 0-" + card.special.shadowBolt[card.rank] + "00% damage" + "\n" : "") +
            (card.special.poison[card.rank] > 0 ? "<b>" + "Poison " + card.special.poison[card.rank] + ": " + "</b>" + "Attacks causes the target to take magical damage each turn" + "\n" : "") +
            (card.special.poisoned[card.rank] > 0 ? "<b>" + "Poisoned " + card.special.poisoned[card.rank] + ": " + "</b>" + "Take magical damage each turn" + "\n" : "") +
            (card.special.immolate[card.rank] > 0 ? "<b>" + "Immolate " + card.special.immolate[card.rank] + ": " + "</b>" + "Take magical damage each turn" + "\n" : "") +
            (card.special.reapingCurse[card.rank] > 0 ? "<b>" + "Reaping Curse " + card.special.reapingCurse[card.rank] + ": " + "</b>" + "Upon dying, deal damage to the enemy hero" + "\n" : "") +
            (card.special.soulEater[card.rank] > 0 ? "<b>" + "Soul Eater " + card.special.soulEater[card.rank] + ": " + "</b>" + "Gain +" + card.special.soulEater[card.rank] + "/+" + card.special.soulEater[card.rank] + " whenever this attacks the enemy hero" + "\n" : "") +
            (card.special.spellCurse[card.rank] > 0 ? "<b>" + "Spell Curse " + card.special.spellCurse[card.rank] + ": " + "</b>" + "Attacks curse the enemy to take increased magical damage" + "\n" : "") +
            (card.special.spellCursed[card.rank] > 0 ? "<b>" + "Spell Cursed " + card.special.spellCursed[card.rank] + ": " + "</b>" + "Take increased magical damage" + "\n" : "") +
            (card.special.spellFeed[card.rank] > 0 ? "<b>" + "Spell Feed " + card.special.spellFeed[card.rank] + ": " + "</b>" + "Gain +" + card.special.spellFeed[card.rank] + "/+" + card.special.spellFeed[card.rank] + " whenever this takes magical damage" + "\n" : "") +
            (card.special.inspiration[card.rank] > 0 ? "<b>" + "Inspiration " + card.special.inspiration[card.rank] + ": " + "</b>" + "Reduce the countdown of the highest countdown card in your hand" + "\n" : "") +
            (card.special.herosBane[card.rank] > 0 ? "<b>" + "Hero's Bane " + card.special.herosBane[card.rank] + ": " + "</b>" + "Deal damage to the enemy hero each turn" + "\n" : "") +
            (card.special.embered[card.rank] > 0 ? "<b>" + "Embered " + card.special.embered[card.rank] + ": " + "</b>" + "Take magical damage next turn" + "\n" : "") +
            (card.special.lightningBolt[card.rank] > 0 ? "<b>" + "Lightning Bolt " + card.special.lightningBolt[card.rank] + ": " + "</b>" + "Deal damage to a random enemy unit each turn" + "\n" : "") +
            (card.special.rage[card.rank] > 0 ? "<b>" + "Rage " + card.special.rage[card.rank] + ": " + "</b>" + "Gain attack whenever this takes damage" + "\n" : "") +
            (card.special.carnivore[card.rank] > 0 ? "<b>" + "Carnivore " + card.special.carnivore[card.rank] + ": " + "</b>" + "Gain health whenever this kills a unit" + "\n" : "") +
            (card.special.bloodPrice[card.rank] > 0 ? "<b>" + "Blood Price " + card.special.bloodPrice[card.rank] + ": " + "</b>" + "Deal damage to its own hero each turn" + "\n" : "") +
            (card.special.maim[card.rank] > 0 ? "<b>" + "Maim " + card.special.maim[card.rank] + ": " + "</b>" + "Attacks causes the enemy to take increased physical damage" + "\n" : "") +
            (card.special.maimed[card.rank] > 0 ? "<b>" + "Maimed " + card.special.maimed[card.rank] + ": " + "</b>" + "Take increased physical damage" + "\n" : "") +
            (card.special.battleSpirit[card.rank] > 0 ? "<b>" + "Battle Spirit " + card.special.battleSpirit[card.rank] + ": " + "</b>" + "Gain +" + card.special.battleSpirit[card.rank] + "/+" + card.special.battleSpirit[card.rank] + " whenever this takes physical damage" + "\n" : "") +
            (card.special.knockback[card.rank] > 0 ? "<b>" + "Knockback " + card.special.knockback[card.rank] + ": " + "</b>" + "Damaged targets will be knocked back " + card.special.knockback[card.rank] + " tiles" + "\n" : "") +

            (card.special.lifeAura[card.rank] > 0 ? "<b>" + "Life Aura " + card.special.lifeAura[card.rank] + ": " + "</b>" + "Allied units get bonus health" + "\n" : "") +
            (card.special.regenerationAura[card.rank] > 0 ? "<b>" + "Regeneration Aura " + card.special.regenerationAura[card.rank] + ": " + "</b>" + "Allied units get Regeneration" + "\n" : "") +
            (card.special.witheringAura[card.rank] > 0 ? "<b>" + "Withering Aura " + card.special.witheringAura[card.rank] + ": " + "</b>" + "Enemy units get reduced health, but not less than 1" + "\n" : "") +
            (card.special.rangeAura[card.rank] > 0 ? "<b>" + "Range Aura " + card.special.rangeAura[card.rank] + ": " + "</b>" + "Allied units get bonus range" + "\n" : "") +
            (card.special.speedAura[card.rank] > 0 ? "<b>" + "Speed Aura " + card.special.speedAura[card.rank] + ": " + "</b>" + "Allied units get bonus speed" + "\n" : "") +
            (card.special.attackAura[card.rank] > 0 ? "<b>" + "Attack Aura " + card.special.attackAura[card.rank] + ": " + "</b>" + "Allied units get bonus attack" + "\n" : "") +
            (card.special.blizzardAura ? "<b>" + "Blizzard Aura: " + "</b>" + "Enemy units have -1 Range and Speed" + "\n" : "") +
            (card.special.herosBaneAura[card.rank] > 0 ? "<b>" + "Hero's Bane Aura " + card.special.herosBaneAura[card.rank] + ": " + "</b>" + "Allied units get Hero's Bane" + "\n" : "") +
            (card.special.penetrateAura ? "<b>" + "Penetrate Aura: " + "</b>" + "Allied units get Penetrate" + "\n" : "") +
            (card.special.poisonAura[card.rank] > 0 ? "<b>" + "Poison Aura " + card.special.poisonAura[card.rank] + ": " + "</b>" + "Allied units get Poison" + "\n" : "") +
            (card.special.armorAura[card.rank] > 0 ? "<b>" + "Armor Aura " + card.special.armorAura[card.rank] + ": " + "</b>" + "Allied units get Armor" + "\n" : "") +

            (card.special.pierce ? "<b>" + "Pierce: " + "</b>" + "Also deals damage to the enemy behind the target" + "\n" : "") +
            (card.special.whirlwind ? "<b>" + "Whirlwind: " + "</b>" + "Attack all adjacent enemies" + "\n" : "") +
            (card.special.counterattack ? "<b>" + "Counterattack: " + "</b>" + "Retaliate if attacked inside its range" + "\n" : "") +
            (card.special.firstStrike ? "<b>" + "First Strike: " + "</b>" + "Retaliate before being attacked inside its range" + "\n" : "") +
            (card.special.dispel ? "<b>" + "Dispel: " + "</b>" + "Attacking an enemy first reduces their attack and health to their normal values" + "\n" : "") +
            (card.special.faith ? "<b>" + "Faith: " + "</b>" + "Healing a unit grants this unit +1/+1" + "\n" : "") +
            (card.special.martyrdom ? "<b>" + "Martyrdom: " + "</b>" + "Redirect all damage taken by nearby allies towards this unit" + "\n" : "") +
            (card.special.heavyWeapon ? "<b>" + "Heavy Weapon: " + "</b>" + "Cannot attack after moving" + "\n" : "") +
            (card.special.dragonSlayer ? "<b>" + "Dragon Slayer: " + "</b>" + "Deal double damage to units with 5+ countdown" + "\n" : "") +
            (card.special.reanimate ? "<b>" + "Reanimate: " + "</b>" + "Resummon this unit the first time it dies" + "\n" : "") +
            (card.special.lifeSteal ? "<b>" + "Life Steal: " + "</b>" + "Restore this unit's health equal to damage dealt" + "\n" : "") +
            (card.special.soulbound ? "<b>" + "Soulbound: " + "</b>" + "Return this unit to your hand the first time it dies" + "\n" : "") +
            (card.special.frostBolt ? "<b>" + "Frost Bolt: " + "</b>" + "Damaged targets have their speed reduced to 1" + "\n" : "") +
            (card.special.incorporeal ? "<b>" + "Incorporeal: " + "</b>" + "Physical damage received is reduced to 1" + "\n" : "") +
            (card.special.fear ? "<b>" + "Fear: " + "</b>" + "The first unit this attacks flees to it's owner's hand" + "\n" : "") +
            (card.special.skeletal ? "<b>" + "Skeletal: " + "</b>" + "Upon dying, turn into a Bone Heap which reanimates this unit next turn" + "\n" : "") +
            (card.special.boneHeap ? "<b>" + "Bone Heap: " + "</b>" + "Reanimate the collapsed body at the end of your turn" + "\n" : "") +
            (card.special.vengefulCurse ? "<b>" + "Vengeful Curse: " + "</b>" + "Attacking curses the target's next attack to also damage itself" + "\n" : "") +
            (card.special.vengefulCursed ? "<b>" + "Vengeful Cursed: " + "</b>" + "This unit's next attack also damages itself" + "\n" : "") +
            (card.special.panicStrike ? "<b>" + "Panic Strike: " + "</b>" + "Attacking the enemy hero causes a random enemy card to gain +1 CD" + "\n" : "") +
            (card.special.sniper ? "<b>" + "Sniper: " + "</b>" + "Always attack the lowest health enemy in range" + "\n" : "") +
            (card.special.ember ? "<b>" + "Ember: " + "</b>" + "Attacks deal magical damage next turn instead of immediately" + "\n" : "") +
            (card.special.nimble ? "<b>" + "Nimble: " + "</b>" + "Attack, Health, Range and Speed cannot be reduced" + "\n" : "") +
            (card.special.conjure ? "<b>" + "Conjure: " + "</b>" + "The next card you summon draws you a card" + "\n" : "") +
            (card.special.donor ? "<b>" + "Donor: " + "</b>" + "Draw a card when this unit fully dies" + "\n" : "") +
            (card.special.stun ? "<b>" + "Stun: " + "</b>" + "This unit's first attack stuns the target, skipping its next turn" + "\n" : "") +
            (card.special.stunned ? "<b>" + "Stunned: " + "</b>" + "This unit's next turn is skipped" + "\n" : "") +
            (card.special.permaStun ? "<b>" + "Perma Stun: " + "</b>" + "This unit's attacks stuns the target, skipping its next turn" + "\n" : "") +
            (card.special.distraction ? "<b>" + "Distraction: " + "</b>" + "Increase the countdown of a random enemy card each turn" + "\n" : "") +
            (card.special.spear ? "<b>" + "Spear: " + "</b>" + "Deal double damage to units with 4+ Speed" + "\n" : "") +
            (card.special.ambush ? "<b>" + "Ambush: " + "</b>" + "This unit's first attack deals double damage" + "\n" : "") +
            (card.special.cleave ? "<b>" + "Cleave: " + "</b>" + "Damage all enemies on the same column as the target" + "\n" : "") +
            (card.special.charm ? "<b>" + "Charm: " + "</b>" + "Take control over the first unit attacked with 3 or less cd" + "\n" : "") +
            (card.special.bleedingAttack ? "<b>" + "Bleeding Attack: " + "</b>" + "Attacks make the target unable to be healed" + "\n" : "") +
            (card.special.bleeding ? "<b>" + "Bleeding: " + "</b>" + "This unit cannot be healed" + "\n" : "") +
            (card.special.influence ? "<b>" + "Influence: " + "</b>" + "Upon attacking, give a card in your hand +1/+1" + "\n" : "") +
            (card.special.hitAndRun ? "<b>" + "Hit and Run: " + "</b>" + "After attacking, move backwards" + "\n" : "") +
            (card.special.headbutt ? "<b>" + "Headbutt: " + "</b>" + "After attacking, push the target back 1 tile and move with it" + "\n" : "") +

            (card.special.kingsCommand ? "<b>" + "King's Command: " + "</b>" + "Summons a random 1-countdown unit each turn" + "\n" : "") +
            (card.special.combatMaster ? "<b>" + "Combat Master: " + "</b>" + "Deals double damage to enemies with 4+ Range, 4+ Speed, Armor, Wall or Flying" + "\n" : "") +
            (card.special.callOfTheUndeadKing ? "<b>" + "Call of the Undead King: " + "</b>" + "Whenever an enemy unit dies, raise a Zombie with Reanimate in its place" + "\n" : "") +
            (card.special.blackIce ? "<b>" + "Black Ice: " + "</b>" + "Upon taking damage, reduced the attacker's speed to 0" + "\n" : "") +
            (card.special.soulHarvest ? "<b>" + "Soul Harvest: " + "</b>" + "Whenever an enemy dies, gain half its Attack and Health" + "\n" : "") +
            (card.special.multiShot ? "<b>" + "Multishot: " + "</b>" + "Attack all enemy units and heroes inside range" + "\n" : "") +
            (card.special.reinforcement ? "<b>" + "Reinforcement: " + "</b>" + "On summon, also summon 2 copies of this unit on the same column" + "\n" : "") +
            (card.special.disdain[card.rank] > 0 ? "<b>" + "Disdain " + card.special.disdain[card.rank] + ": " + "</b>" + "Damagine units with " + card.special.disdain[card.rank] + " or less countdown instantly kills them" + "\n" : "") +
            (card.special.crushDefenses ? "<b>" + "Crush Defenses: " + "</b>" + "Deal double damage to units with Armor or Resistance" + "\n" : "") +
            (card.special.cheif ? "<b>" + "Cheif: " + "</b>" + "On summon, gain +1/+3 for each other allied unit" + "\n" : "") +
            (card.special.krush ? "<b>" + "Krush: " + "</b>" + "Destroy the first unit attacked" + "\n" : "") +
            (card.special.thunderStorm[card.rank] > 0 ? "<b>" + "Thunderstorm " + card.special.thunderStorm[card.rank] + ": " + "</b>" + "Deal damage to all enemy units each turn" + "\n" : "") +
            (card.special.lifeAbsorb ? "<b>" + "Life Absorb: " + "</b>" + "Restore this unit's health equal to double the damage dealt" + "\n" : "") +

            "";

        return text;
    }
}
