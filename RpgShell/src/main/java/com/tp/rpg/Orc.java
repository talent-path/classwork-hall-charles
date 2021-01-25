package com.tp.rpg;

public class Orc extends NonPlayerCharacter {

    public Orc() {
        this.name = "Orc";
        this.healthPoints = 100;
        this.attackPoints = 40;
        this.armorPoints = 10;
        this.potionCount = 1;
    }

    public String makeChoice() {

        int random = Console.randInt(1,2);

        if(random == 1) {
            return "attack";
        }
        else if(random == 2) {
            return "use potion";
        }

        return "attack";
    }
}
