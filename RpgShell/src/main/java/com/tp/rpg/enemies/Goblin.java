package com.tp.rpg.enemies;

import com.tp.rpg.Console;
import com.tp.rpg.NonPlayerCharacter;

//goblins always attack?
public class Goblin extends NonPlayerCharacter {

    public Goblin() {
        this.name = "Goblin";
        this.healthPoints = 50;
        this.attackPoints = 20;
        this.armorPoints = 0;
        this.potionCount = 0;
    }

    public String makeChoice() {
        int random = Console.randInt(1,2);

        if(random == 1) {
            return "attack";
        }
        else if(random == 2) {
            return "heavy attack";
        }

        return "attack";
    }


}
