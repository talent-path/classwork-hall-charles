using System;
namespace VendingMachine
{
    public interface IInventoryDao
    {

        int AddVendingMachineItem(VendingMachineItem item);

        VendingMachineItem GetVendingMachineItemById(int id); 

        void UpdateVendingMachineItem(VendingMachineItem item);

        decimal PurchaseCandyById(int id, decimal userFunds);

        void DeleteVendingMachineItemById(int id);
    }
}
