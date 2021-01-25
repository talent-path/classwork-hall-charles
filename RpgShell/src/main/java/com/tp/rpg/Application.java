package com.tp.rpg;

import java.util.Scanner;

public class Application {
    public static void main(String[] args) {

        PlayerCharacter pc = setUpPlayer();

        while( pc.isAlive(pc.healthPoints) ){
            NonPlayerCharacter enemy = setUpEnemy();

            if(enemy.getName().equals("Orc"))
                System.out.println("\nLook out! An Orc appears!");
            else
                System.out.println("\nLook out! A " + enemy.getName() + " appears!");
            battle(pc, enemy);

        }

        gameOverScreen(pc);

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

        int random = Console.randInt(1,2);

        if(random == 1) {
            return new Goblin();
        }
        else if(random == 2) {
            return new Orc();
        }

        return new Goblin();
    }

    //a and b battle until one is dead
    private static void battle(Character a, Character b) {
        Character attacker = a;
        Character defender = b;
        int kills = 0;

        while( a.isAlive(a.healthPoints) && b.isAlive(b.healthPoints) ){
            String choice = attacker.makeChoice();

            if( choice.equals("attack")) {
                attacker.attack(defender);
            } else if (choice.equals("block")) {
                attacker.block(defender);
            }
            else if (choice.equals("use potion") && attacker.potionCount > 0) {
                attacker.usePotion();
            }


            Character temp = attacker;
            attacker = defender;
            defender = temp;

            System.out.println("Current Health: " + a.healthPoints);
            System.out.println("Enemy Health: " + b.healthPoints);
        }

        if(b.healthPoints <= 0) {
            System.out.println("Excellent, you have defeated the enemy!");
        }
    }

    //display some message
    private static void gameOverScreen(Character player) {
        System.out.println("\nGAME OVER");
        System.out.println("Congratulations, " + player.name + ",you tried your best and slayed many enemies.");
    }
}
