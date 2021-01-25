package com.tp.rpg.armors;

public class LegArmor implements Armor {

    int armorPoints = 20;

    public int reduceDamage(int startingDamage) {
        return startingDamage - armorPoints;
    }

    public int getArmorPoints() {
        return armorPoints;
    }
}
