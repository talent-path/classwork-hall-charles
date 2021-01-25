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

    //TODO: add fields for armor(s) and weapon(s)
    public String name;
    public int armorPoints;
    public int attackPoints;
    public int healthPoints;
    public int potionCount;


    public void attack( Character defender ){
        if(name.equals("Orc") || name.equals("Goblin")) {
            System.out.println("The " + name + " strikes dealing " + attackPoints + " damage!" );
        }
        else {
            System.out.println("You strike the " + defender.name + " for " + attackPoints + " damage!");
        }
        defender.takeDamage(attackPoints);
    }

    public void block( Character attacker ) {
        throw new UnsupportedOperationException();
    }

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

    public void takeDamage( int damage ){
        healthPoints-= (damage - armorPoints);
    }

    public boolean isAlive(int hp){
        if(hp <= 0)
            return false;
        else
            return true;
    }

}
