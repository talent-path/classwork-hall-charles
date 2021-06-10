using System;
namespace VendingMachine
{
    public interface IInventoryDao
    {

        int Add(VendingMachineItem item);

        VendingMachineItem GetById(int id); 

        void UpdateVendingMachineItem(VendingMachineItem item);

        void DeleteVendingMachineItemById(int id);
    }
}
