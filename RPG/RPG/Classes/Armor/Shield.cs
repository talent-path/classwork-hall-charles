using System;
namespace RPG.Classes.Armor
{
    public class Shield : Armor
    {
        public Shield()
        {
        }

        public override int ReduceDamage(int incomingDamage)
        {
            Random rand = new Random();

            if (Durability > 0)
            {
                if (rand.Next(0, 2) == 0)
                {
                    incomingDamage = 0;
                }

                if (rand.Next(0, 20) == 0)
                {
                    Durability -= 1;
                }
            }

            return incomingDamage;
        }

    }
}
