package com.tp.rpg;

public class Witch extends NonPlayerCharacter {

    public Witch() {
        this.name = "Witch";
        this.healthPoints = 50;
        this.attackPoints = 50;
        this.armorPoints = 0;
        this.potionCount = 2;
    }

    @Override
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
