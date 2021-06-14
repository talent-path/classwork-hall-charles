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

            Console.WriteLine("Enter how much money you would like to enter.");
            decimal userFunds = decimal.Parse(Console.ReadLine());
            Change change = new Change(userFunds);

            int input = _view.MainMenu();
            switch (input)
            {
                case 1:
                    change = _service.UpdateVendingMachineItem(1, userFunds);
                    break;
                case 2:
                    change = _service.UpdateVendingMachineItem(2, userFunds);
                    break;
                case 3:
                    change = _service.UpdateVendingMachineItem(3, userFunds);
                    break;
                case 4:
                    change = _service.UpdateVendingMachineItem(4, userFunds);
                    break;
                case 5:
                    change = _service.UpdateVendingMachineItem(5, userFunds);
                    break;
            }

            Console.WriteLine("Your change is " + change.dollars + " dollars, " + change.quarters + " quarters, "
                + change.dimes + " dimes, " + change.nickels + " nickels, and " + change.pennies + " pennies.");

        }
    }
}
