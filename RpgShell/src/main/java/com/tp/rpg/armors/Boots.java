package com.tp.rpg.armors;

public class Boots implements Armor {

    int armorPoints = 5;

    public int reduceDamage(int startingDamage) {
        return startingDamage - armorPoints;
    }

    public int getArmorPoints() {
        return armorPoints;
    }


}
