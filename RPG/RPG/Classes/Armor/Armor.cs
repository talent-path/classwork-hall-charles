using System;
using RPG.Interfaces;

namespace RPG.Classes.Armor
{
    public abstract class Armor : IArmor
    {
        public Armor()
        {
        }

        public Armor(int durability)
        {
            Durability = durability;
        }

        public int Durability { get; set; }

        public abstract int ReduceDamage(int incomingDamage);
    }
}
