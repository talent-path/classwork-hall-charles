using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachineController controller = new VendingMachineController(
                new VendingMachineService(
                    new FileDao("../../../Seed.txt")
                ),
                new VendingMachineView()
            );

            controller.Run();
        }
    }
}
