using System;
namespace RPG.Classes.Armor
{
    public class Shirt : Armor
    {
        public Shirt()
        {
        }

        public override int ReduceDamage(int incomingDamage)
        {
            if(Durability > 0)
            {
                return incomingDamage - 1;
            }

            return incomingDamage;
        }
    }
}
