using System;
namespace VendingMachine
{
    public interface IInventoryDao
    {

        VendingMachineItem GetVendingMachineItemById(int id); 

        void UpdateVendingMachineItem(VendingMachineItem item);

    }
}
