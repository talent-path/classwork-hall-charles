using System;
namespace VendingMachine
{
    public class VendingMachineView
    {
        public VendingMachineView()
        {
        }

        internal int MainMenu()
        {
            int choice = -1;
            bool valid = false;
            while (!valid)
            {
                Console.WriteLine("1. Hershey's Chocolate Bar - $2.00");
                Console.WriteLine("2. Reese's Peanut Butter Cup - $2.50");
                Console.WriteLine("3. Skittles - $2.25");
                Console.WriteLine("4. M&M's - $1.75");
                Console.WriteLine("5. Peanut M&M's - $1.90");

                valid = int.TryParse(Console.ReadLine(), out choice);
                if (valid) valid = choice > 0 && choice < 6;
            }

            return choice;
        }
    }
}
