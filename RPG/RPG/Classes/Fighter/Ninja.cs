using System;
using RPG.Classes.Armor;
using RPG.Classes.Weapon;
using RPG.Interfaces;

namespace RPG.Classes.Fighter
{
    public class Ninja : Fighter
    {
        Random rand = new Random();

        public Ninja()
        {
            Name = "Ninja";
            Health = 8;
            Weapon = new Fists();
            Armor = new Shirt();
        }

        public Ninja(string name, int health, string weapon, string armor, int potion)
        {
            Name = name;
            Health = health;
            Weapon = GetWeapon(weapon);
            Armor = GetArmor(armor);
            Potion = potion;
        }

        public override void Attack(IFighter toAttack)
        {
            if (Weapon.Name == "Crossbow")
            {
                if (rand.Next(0, 2) == 0)
                {
                    Console.WriteLine("The crossbow actually hit!");
                    Weapon.Damage = 20;
                }
                else
                {
                    Console.WriteLine("The crossbow missed!");
                    Weapon.Damage = 0;
                }
            }
            toAttack.Defend(Weapon.Damage);
        }

        public override void Defend(int dmg)
        {
            Random rand = new Random();

            if (rand.Next(0, 5) != 0)
            {
                Health -= Armor.ReduceDamage(dmg);
                if (Name != "Ninja" && Potion != 0 && Health <= 6)
                {
                    Console.WriteLine("You healed 4 hp with a potion!");
                    Health += 4;
                    Potion--;
                }
            }
            else
            {
                Console.WriteLine("Attack dodged!");
            }
        }
    }
}
