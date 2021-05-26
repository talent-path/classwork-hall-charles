using System;
using RPG.Interfaces;

namespace RPG.Classes.Weapon
{
    public abstract class Weapon : IWeapon
    {
        public Weapon()
        {
        }

        public Weapon(string name, int damage, int durability)
        {
            Name = name;
            Damage = damage;
            Durability = durability;
        }

        public string Name { get; set; }

        public int Damage { get; set; }

        public int Durability { get; set; }
    }
}
