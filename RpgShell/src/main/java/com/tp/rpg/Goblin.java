package com.tp.rpg;

//goblins always attack?
public class Goblin extends NonPlayerCharacter {

    public Goblin() {
        this.name = "Goblin";
        this.healthPoints = 80;
        this.attackPoints = 20;
        this.armorPoints = 0;
        this.potionCount = 0;
    }

    public String makeChoice() {
        return "attack";
    }


}
