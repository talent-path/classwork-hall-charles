using System;
namespace VendingMachine
{
    public class Change
    {

        public int dollars = 0;
        public int quarters = 0;
        public int dimes = 0;
        public int nickels = 0;
        public int pennies = 0;

        public Change(decimal amount)
        {
            while (amount >= 1)
            {
                dollars++;
                amount -= 1;
            }

            while (amount >= 0.25m)
            {
                quarters++;
                amount -= 0.25m;
            }

            while (amount >= 0.10m)
            {
                dimes++;
                amount -= 0.10m;
            }

            while (amount >= 0.05m)
            {
                nickels++;
                amount -= 0.05m;
            }

            while (amount > 0.0m)
            {
                pennies++;
                amount -= 0.01m;
            }
        }

    }
}
