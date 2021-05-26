using System;
using RPG.Classes.Armor;
using RPG.Classes.Weapon;
using RPG.Interfaces;

namespace RPG.Classes.Fighter
{
    public class Brute : Fighter
    {
        public Brute()
        {
            Name = "Brute";
            Health = 10;
            Weapon = new Fists();
            Armor = new Helmet();
        }

        public Brute(string name, int health, string weapon, string armor, int potion)
        {
            Name = name;
            Health = health;
            Weapon = GetWeapon(weapon);
            Armor = GetArmor(armor);
            Potion = potion;
        }

        public override void Attack(IFighter toAttack)
        {
            toAttack.Defend(Weapon.Damage + 1);
        }

        public override void Defend(int dmg)
        {
            Health -= Armor.ReduceDamage(dmg);
        }

    }
}
