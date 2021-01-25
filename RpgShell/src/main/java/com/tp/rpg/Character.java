package com.tp.rpg;

//TODO:
//      add a concept of hitpoints
//      add a concept of armor (or maybe multiple pieces of armor)
//      add a concept of a weapon (or maybe multiple weapons)
//Stretch goals:
//      add a potion class/interface that the character can drink instead of attacking
//      let the character "disarm" the opponent instead of attacking
//          base this on the weapons used?
//      let the character choose to "block" or "defend"
//          could stun the opponent if they attack?
//          could give us TWO attacks on the next round?
public abstract class Character implements Chooser {

    public String name;
    public int armorPoints;
    public int attackPoints;
    public int healthPoints;
    public int potionCount;

    //Normal attack handling
    //Guaranteed damage with chance to critically strike
    public void attack( Character defender ){
        if(name.equals("Orc") || name.equals("Goblin")) { //NPC attack handling
            if(isCrit()) { // Critical strike
                System.out.println("The " + name + " critically strikes dealing " + getCritDamage() + " damage!");
                defender.takeDamage(getCritDamage());
            }
            else { // Normal attack
                System.out.println("The " + name + " strikes dealing " + attackPoints + " damage!");
                defender.takeDamage(attackPoints);
            }
        }
        else { // Player attack handling
            if(isCrit()) { // Critical strike
                System.out.println("You critically strike the " + defender.getName() + " for " + getCritDamage() + " damage!");
                defender.takeDamage(getCritDamage());
            }
            else { // Normal attack
                System.out.println("You strike the " + defender.getName() + " for " + attackPoints + " damage!");
                defender.takeDamage(attackPoints);
            }
        }

    }

    //Heavy attack handling
    //Deals a lot of damage, but there is a chance the character can miss
    public void heavyAttack( Character defender) {
        int heavyStrike = attackPoints + (attackPoints/2);

        if(name.equals("Orc") || name.equals("Goblin")) { // NPC heavy attack handling
            if(isMiss()) { // Miss
                System.out.println("The " + name + "tries to strike heavily, but misses!");
            }
            else { // Heavy attack
                System.out.println("The " + name + "strikes heavily, dealing " + heavyStrike + " damage!");
                defender.takeDamage(heavyStrike);
            }
        }
        else { // Player heavy attack handling
            if(isMiss()) { // Miss
                System.out.println("You attempt to heavily strike, but miss!");
            }
            System.out.println("You heavily strike the " + defender.name + " for " + heavyStrike + " damage!");
        }
    }

    //Potion handling
    public void usePotion() {
        if(name.equals("Orc") || name.equals("Goblin")) {
            System.out.println("The " + name + " consumes a potion, healing for 30 hp!" );
        }
        else {
            System.out.println("You strike the consume a potion, healing for 30 hp!");
        }
        healthPoints += 30;
        potionCount -= 1;
    }

    //Damage handling
    public void takeDamage( int damage ){
        healthPoints-= (damage - armorPoints);
    }

    //Method to see if character is alive
    public boolean isAlive(int hp){
        if(hp <= 0)
            return false;
        else
            return true;
    }

    //20% chance to critically strike
    public boolean isCrit() {
        if(Console.randInt(1, 4) == 1)
            return true;
        return false;
    }

    //Critical strike damage calculations
    public int getCritDamage() {
        return attackPoints + (attackPoints/4);
    }

    //25% chance to miss
    public boolean isMiss() {
        if(Console.randInt(1, 5) == 1) {
            return true;
        }
        return false;
    }

    //Getters
    public String getName() {
        return this.name;
    }

    public int getAttackPoints() {
        return this.attackPoints;
    }

    public int getArmorPoints() {
        return this.armorPoints;
    }

    public int getHealthPoints() {
        return this.healthPoints;
    }

    public int getPotionCount() {
        return this.potionCount;
    }
}
