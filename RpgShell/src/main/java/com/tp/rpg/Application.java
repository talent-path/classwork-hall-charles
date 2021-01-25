package com.tp.rpg;

import com.tp.rpg.enemies.Goblin;
import com.tp.rpg.enemies.Orc;
import com.tp.rpg.enemies.Witch;

import java.util.Locale;
import java.util.Scanner;

public class Application {
    public static void main(String[] args) {

        PlayerCharacter pc = setUpPlayer();
        int kills = 0;

        while( pc.isAlive(pc.healthPoints) ){
            NonPlayerCharacter enemy = setUpEnemy();

            if(enemy.getName().equals("Orc"))
                System.out.println("\nLook out! An Orc appears!");
            else
                System.out.println("\nLook out! A " + enemy.getName() + " appears!");

            kills = battle(pc, enemy, kills);

        }

        gameOverScreen(pc, kills);

    }

    //walk the user through setting up their character
    private static PlayerCharacter setUpPlayer() {

        Scanner scan = new Scanner(System.in);

        System.out.println("Hello warrior, let's get you ready for battle!");
        System.out.println("Let's start by choosing your title! What shall we call you?");
        String name = scan.nextLine();

        System.out.println("Now, lets choose your weapon. We have quite a selection here!");
        System.out.println("__________________________________________");
        System.out.println("Fists | Dagger | Short Sword | Spear | Axe");
        String weapon = scan.nextLine();

        System.out.println("Great choice! Next, lets choose your armor. Only one, we don't have enough" +
                " to go around here...");
        System.out.println("________________________________________");
        System.out.println("Chest Plate | Helmet | Leg Armor | Boots");
        String armor = scan.nextLine();

        System.out.println("Finally, let's get you some potions so you can survive out there a little longer!");
        System.out.println("How many do you want?");
        System.out.println("________________________________________");
        System.out.println("1 | 2 | 3 ");
        int potionCount = scan.nextInt();

        System.out.println("Perfect! You are prepared for battle, best of luck to you!");
        return new PlayerCharacter(name, weapon, armor, potionCount);
    }

    //create some NPC object (with armor & weapons?)
    private static NonPlayerCharacter setUpEnemy() {

        int random = Console.randInt(1,3);

        if(random == 1) {
            return new Goblin();
        }
        else if(random == 2) {
            return new Orc();
        }
        else if(random == 3) {
            return new Witch();
        }

        return new Goblin();
    }

    //a and b battle until one is dead
    private static int battle(Character a, Character b, int kills) {
        Character attacker = a;
        Character defender = b;

        while(a.isAlive(a.getHealthPoints()) && b.isAlive(b.getHealthPoints())){
            String choice = attacker.makeChoice();

            if (choice.toLowerCase().equals("attack")) {
                attacker.attack(defender);
            } else if (choice.toLowerCase().equals("use potion") && attacker.getPotionCount() > 0) {
                attacker.usePotion();
            } else if (choice.toLowerCase().equals("heavy attack")) {
                attacker.heavyAttack(defender);
            }

            Character temp = attacker;
            attacker = defender;
            defender = temp;

            System.out.println("Current Health: " + a.getHealthPoints());
            System.out.println("Enemy Health: " + b.getHealthPoints());
        }

        if(b.getHealthPoints() <= 0) {
            System.out.println("Excellent, you have defeated the enemy!");
            kills++;
        }

        return kills;
    }

    //display some message
    private static void gameOverScreen(Character player, int kills) {
        System.out.println("\nGAME OVER");
        if(kills == 0) {
            System.out.println("Impressive, " + player.getName() + ", you managed to kill absolutely " + kills + "enemies.");
        }
        else if(kills == 1)
            System.out.println("Uh, " + player.getName() + ", you only killed " + kills + " enemy. Disappointing performance.");
        System.out.println("Congratulations, " + player.getName() + ", you defeated " + kills + " enemies.");
    }
}
