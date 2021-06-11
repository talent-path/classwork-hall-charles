using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachineController controller = new VendingMachineController(
                new VendingMachineService(
                    new InMemInventoryDao()
                ),
                new VendingMachineView()
            );

            controller.Run();
        }
    }
}
