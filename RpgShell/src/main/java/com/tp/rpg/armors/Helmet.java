package com.tp.rpg.armors;

public class Helmet implements Armor {

    int armorPoints = 10;

    public int reduceDamage(int startingDamage) {
        return startingDamage - armorPoints;
    }

    public int getArmorPoints() {
        return armorPoints;
    }

}
