using System;
namespace RPG.Classes.Armor
{
    public class Helmet : Armor
    {
        public Helmet()
        {
        }

        public override int ReduceDamage(int incomingDamage)
        {
            return incomingDamage - 1;
        }

    }
}
