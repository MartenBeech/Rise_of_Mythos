using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCopy : MonoBehaviour
{
    public Card GetCopyOfCard(Card card)
    {
        Card copy = new Card();

        copy.title = card.title;
        copy.alignment = card.alignment;
        copy.damageType = card.damageType;

        for (int i = 0; i < 6; i++)
        {
            copy.attack[i] = card.attack[i];
            copy.attackDefault[i] = card.attackDefault[i];
            copy.health[i] = card.health[i];
            copy.healthDefault[i] = card.healthDefault[i];
            copy.healthMax[i] = card.healthMax[i];
            copy.healthMaxDefault[i] = card.healthMaxDefault[i];
        }
        
        copy.cd = card.cd;
        copy.cdDefault = card.cdDefault;

        copy.speed = card.speed;
        copy.speedDefault = card.speedDefault;
        copy.range = card.range;
        copy.rangeDefault = card.rangeDefault;
        copy.tile = card.tile;
        copy.rarity = card.rarity;
        copy.rank = card.rank;
        copy.upgraded = card.upgraded;
        copy.nameTag = card.nameTag;

        copy.sprite = card.sprite;


        copy.special.wall = card.special.wall;
        copy.special.flying = card.special.flying;
        copy.special.levitate = card.special.levitate;
        copy.special.vigilance = card.special.vigilance;
        copy.special.penetrate = card.special.penetrate;

        for (int i = 0; i < 6; i++)
        {
            copy.special.armor[i] = card.special.armor[i];
            copy.special.resistance[i] = card.special.resistance[i];
            copy.special.charge[i] = card.special.charge[i];
            copy.special.cure[i] = card.special.cure[i];
            copy.special.heroic[i] = card.special.heroic[i];
            copy.special.regeneration[i] = card.special.regeneration[i];
            copy.special.multistrike[i] = card.special.multistrike[i];
            copy.special.weaken[i] = card.special.weaken[i];
            copy.special.shadowBolt[i] = card.special.shadowBolt[i];
            copy.special.poison[i] = card.special.poison[i];
            copy.special.poisoned[i] = card.special.poisoned[i];
            copy.special.immolate[i] = card.special.immolate[i];
            copy.special.reapingCurse[i] = card.special.reapingCurse[i];
            copy.special.soulEater[i] = card.special.soulEater[i];
            copy.special.spellCurse[i] = card.special.spellCurse[i];
            copy.special.spellCursed[i] = card.special.spellCursed[i];
            copy.special.spellFeed[i] = card.special.spellFeed[i];
            copy.special.inspiration[i] = card.special.inspiration[i];
            copy.special.herosBane[i] = card.special.herosBane[i];
            copy.special.embered[i] = card.special.embered[i];
            copy.special.lightningBolt[i] = card.special.lightningBolt[i];
            copy.special.rage[i] = card.special.rage[i];
            copy.special.carnivore[i] = card.special.carnivore[i];
            copy.special.bloodPrice[i] = card.special.bloodPrice[i];
            copy.special.maim[i] = card.special.maim[i];
            copy.special.maimed[i] = card.special.maimed[i];
            copy.special.battleSpirit[i] = card.special.battleSpirit[i];
            copy.special.knockback[i] = card.special.knockback[i];
            copy.special.prayer[i] = card.special.prayer[i];
            copy.special.healingHand[i] = card.special.healingHand[i];
            copy.special.backstab[i] = card.special.backstab[i];
        }

        for (int i = 0; i < 6; i++)
        {
            copy.special.lifeAura[i] = card.special.lifeAura[i];
            copy.special.regenerationAura[i] = card.special.regenerationAura[i];
            copy.special.witheringAura[i] = card.special.witheringAura[i];
            copy.special.rangeAura[i] = card.special.rangeAura[i];
            copy.special.speedAura[i] = card.special.speedAura[i];
            copy.special.attackAura[i] = card.special.attackAura[i];
            copy.special.herosBaneAura[i] = card.special.herosBaneAura[i];
            copy.special.poisonAura[i] = card.special.poisonAura[i];
            copy.special.armorAura[i] = card.special.armorAura[i];
            copy.special.resistanceAura[i] = card.special.resistanceAura[i];
            copy.special.prayerAura[i] = card.special.prayerAura[i];
            copy.special.rageAura[i] = card.special.rageAura[i];
        }

            copy.special.blizzardAura = card.special.blizzardAura;
            copy.special.penetrateAura = card.special.penetrateAura;
            copy.special.flyingAura = card.special.flyingAura;


        copy.special.pierce = card.special.pierce;
        copy.special.whirlwind = card.special.whirlwind;
        copy.special.counterattack = card.special.counterattack;
        copy.special.firstStrike = card.special.firstStrike;
        copy.special.dispel = card.special.dispel;
        copy.special.faith = card.special.faith;
        copy.special.martyrdom = card.special.martyrdom;
        copy.special.heavyWeapon = card.special.heavyWeapon;
        copy.special.dragonSlayer = card.special.dragonSlayer;
        copy.special.reanimate = card.special.reanimate;
        copy.special.lifeSteal = card.special.lifeSteal;
        copy.special.soulbound = card.special.soulbound;
        copy.special.frostBolt = card.special.frostBolt;
        copy.special.incorporeal = card.special.incorporeal;
        copy.special.fear = card.special.fear;
        copy.special.skeletal = card.special.skeletal;
        copy.special.boneHeap = card.special.boneHeap;
        copy.special.vengefulCurse = card.special.vengefulCurse;
        copy.special.vengefulCursed = card.special.vengefulCursed;
        copy.special.panicStrike = card.special.panicStrike;
        copy.special.sniper = card.special.sniper;
        copy.special.ember = card.special.ember;
        copy.special.nimble = card.special.nimble;
        copy.special.conjure = card.special.conjure;
        copy.special.donor = card.special.donor;
        copy.special.stun = card.special.stun;
        copy.special.stunned = card.special.stunned;
        copy.special.permaStun = card.special.permaStun;
        copy.special.distraction = card.special.distraction;
        copy.special.spear = card.special.spear;
        copy.special.ambush = card.special.ambush;
        copy.special.cleave = card.special.cleave;
        copy.special.convert = card.special.convert;
        copy.special.hitAndRun = card.special.hitAndRun;
        copy.special.bleedingAttack = card.special.bleedingAttack;
        copy.special.bleeding = card.special.bleeding;
        copy.special.influence = card.special.influence;
        copy.special.headbutt = card.special.headbutt;
        copy.special.stoneskin = card.special.stoneskin;

        copy.special.kingsCommand = card.special.kingsCommand;
        copy.special.combatMaster = card.special.combatMaster;
        copy.special.callOfTheUndeadKing = card.special.callOfTheUndeadKing;
        copy.special.blackIce = card.special.blackIce;
        copy.special.soulHarvest = card.special.soulHarvest;
        copy.special.multiShot = card.special.multiShot;
        copy.special.reinforcement = card.special.reinforcement;
        copy.special.crushDefenses = card.special.crushDefenses;
        copy.special.cheif = card.special.cheif;
        copy.special.krush = card.special.krush;
        copy.special.lifeAbsorb = card.special.lifeAbsorb;
        copy.special.vengeance = card.special.vengeance;
        copy.special.retribution = card.special.retribution;
        for (int i = 0; i < 6; i++)
        {
            copy.special.disdain[i] = card.special.disdain[i];
            copy.special.thunderStorm[i] = card.special.thunderStorm[i];
            copy.special.convert[i] = card.special.convert[i];
        }

        return copy;
    }
}
