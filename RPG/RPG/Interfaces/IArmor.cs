using System;
namespace RPG.Interfaces
{
    public interface IArmor
    {

        public int ReduceDamage(int incomingDamage);

        int Durability { get; set; }

    }
}
