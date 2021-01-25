package com.tp.rpg.armors;

public class ChestPlate implements Armor {

    int armorPoints = 30;

    public int reduceDamage(int startingDamage) {
        return startingDamage - armorPoints;
    }

    public int getArmorPoints() {
        return armorPoints;
    }
}
