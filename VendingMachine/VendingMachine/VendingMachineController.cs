using System;
namespace VendingMachine
{
    public class VendingMachineController
    {

        VendingMachineView _view;
        VendingMachineService _service;

        public VendingMachineController(VendingMachineService service, VendingMachineView view)
        {
            _service = service;
            _view = view;
        }

        //Console.WriteLine("1. Hershey's Chocolate Bar - $2.00");
        //Console.WriteLine("2. Reese's Peanut Butter Cup - $2.50");
        //Console.WriteLine("3. Skittles - $2.25");
        //Console.WriteLine("4. M&M's - $1.75");
        //Console.WriteLine("5. Peanut M&M's - $1.90");

        public void Run()
        {
            bool done = false;

            Console.WriteLine("Enter how much money you would like to enter.");
            decimal userFunds = decimal.Parse(Console.ReadLine());

            while(!done || userFunds > 0m)
            {
                int input = _view.MainMenu();
                switch(input)
                {
                    case 1:
                        userFunds = _service.PurchaseCandyById(1, userFunds);
                        break;
                    case 2:
                        userFunds = _service.PurchaseCandyById(2, userFunds);
                        break;
                    case 3:
                        userFunds = _service.PurchaseCandyById(3, userFunds);
                        break;
                    case 4:
                        userFunds = _service.PurchaseCandyById(4, userFunds);
                        break;
                    case 5:
                        userFunds = _service.PurchaseCandyById(5, userFunds);
                        break;
                    case 6:
                        getChange(userFunds);
                        done = true;
                        break;
                }
                Console.WriteLine("You have " + userFunds + " left.");
            }
        }

        public void getChange(decimal amount)
        {
            int dollars = 0;
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;
            int pennies = 0;

            while(amount >= 1)
            {
                dollars++;
                amount -= 1;
            }

            while(amount >= 0.25m)
            {
                quarters++;
                amount -= 0.25m;
            }

            while(amount >= 0.10m)
            {
                dimes++;
                amount -= 0.10m;
            }

            while(amount >= 0.05m)
            {
                nickels++;
                amount -= 0.05m;
            }

            while(amount >= 0.0m)
            {
                pennies++;
                amount -= 0.01m;
            }

            Console.WriteLine("Your change is " + dollars + " dollars, " + quarters + " quarters, "
                + dimes + " dimes, " + nickels + " nickels, and " + pennies + " pennies.");
        }
          
    }
}
