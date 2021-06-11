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

            while(!done)
            {
                int input = _view.MainMenu();

                switch(input)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        done = true;
                        break;
                }
            }

        }
    }
}
