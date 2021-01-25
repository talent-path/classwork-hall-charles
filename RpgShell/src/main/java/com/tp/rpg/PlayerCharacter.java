package com.tp.rpg;
import com.tp.rpg.weapons.*;

import java.util.Scanner;

public class PlayerCharacter extends Character {
    //use scanner here to get something from the user

    public PlayerCharacter(String name, String weapon, String armor, int potionCount) {
        this.name = name;
        this.healthPoints = 100;
        this.attackPoints = getAttackPoints(weapon);
        this.armorPoints = getArmorPoints(armor);
        this.potionCount = potionCount;
    }

    public String makeChoice() {
        Scanner scan = new Scanner(System.in);

        System.out.println("Choose your next move!");
        System.out.println("___________________________");
        System.out.println("Attack | Block | Use Potion");
        String choice = scan.nextLine();

        return choice;
    }

    public int getAttackPoints(String weapon) {
        if(weapon.equals("axe")) {
            return 50;
        } else if(weapon.equals("spear")) {
            return 30;
        } else if(weapon.equals("short sword")) {
            return 30;
        } else if(weapon.equals("dagger")){
            return 20;
        } else {
            return 10;
        }

    }

    public int getArmorPoints(String armor) {
        if(armor.equals("boots")) {
            return 5;
        } else if(armor.equals("chest plate")) {
            return 30;
        } else if(armor.equals("helmet")) {
            return 10;
        } else {
            return 20;
        }
    }

}
