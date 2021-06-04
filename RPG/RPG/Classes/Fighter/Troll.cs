using System;
using RPG.Classes.Armor;
using RPG.Classes.Weapon;
using RPG.Interfaces;

namespace RPG.Classes.Fighter
{
    public class Troll : Fighter
    {
        Random rand = new Random();

        public Troll()
        {
            Name = "Troll";
            Health = 10;
            Weapon = new Crossbow();
            Armor = new Helmet();
        }

        public Troll(string name, int health, string weapon, string armor, int potion)
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
                    Console.WriteLine("The crossbow actually fired!");
                    Weapon.Damage = 20;
                }
                else
                {
                    Console.WriteLine("The crossbow missed!");
                    Weapon.Damage = 0;
                }
            }
            Console.WriteLine("The dang troll regenerated 1 hp!");
            Health += 1;

            toAttack.Defend(Weapon.Damage);
        }

        public override void Defend(int dmg)
        {
            Health -= Armor.ReduceDamage(dmg);
            if (Name != "Troll" && Potion != 0 && Health <= 6)
            {
                Console.WriteLine("You healed 4 hp with a potion!");
                Health += 4;
                Potion--;
            }
        }
    }
}
