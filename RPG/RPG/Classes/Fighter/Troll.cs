using System;
using RPG.Classes.Armor;
using RPG.Classes.Weapon;
using RPG.Interfaces;

namespace RPG.Classes.Fighter
{
    public class Troll : Fighter
    {
        public Troll()
        {
            Name = "Troll";
            Health = 10;
            Weapon = new Crossbow();
            Armor = new Helmet();
        }

        public Troll(string name, int health, string weapon, string armor)
        {
            Name = name;
            Health = health;
            Weapon = GetWeapon(weapon);
            Armor = GetArmor(armor);
        }

        public override void Attack(IFighter toAttack)
        {
            toAttack.Defend(Weapon.Damage);
        }

        public override void Defend(int dmg)
        {
            Health -= Armor.ReduceDamage(dmg);
        }
    }
}
