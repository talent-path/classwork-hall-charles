using System;
namespace VendingMachine
{
    public interface IInventoryDao
    {

        int AddVendingMachineItem(VendingMachineItem item);

        VendingMachineItem GetVendingMachineItemById(int id); 

        void UpdateVendingMachineItem(VendingMachineItem item);

        void PurchaseCandyById(int id);

        void DeleteVendingMachineItemById(int id);
    }
}
