package com.tp.rpg.enemies;

import com.tp.rpg.Console;
import com.tp.rpg.NonPlayerCharacter;

public class Orc extends NonPlayerCharacter {

    public Orc() {
        this.name = "Orc";
        this.healthPoints = 80;
        this.attackPoints = 30;
        this.armorPoints = 10;
        this.potionCount = 1;
    }

    public String makeChoice() {

        int random = Console.randInt(1,3);

        if(random == 1) {
            return "attack";
        }
        else if(random == 2) {
            return "use potion";
        }
        else if(random == 3) {
            return "heavy attack";
        }

        return "attack";
    }
}
