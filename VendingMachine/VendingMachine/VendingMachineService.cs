using System;
using System.Collections.Generic;
using VendingMachine.exceptions;

namespace VendingMachine
{
    public class VendingMachineService
    {

        IInventoryDao _invDao;

        public VendingMachineService(IInventoryDao invDao)
        {
            _invDao = invDao;
        }

        public VendingMachineService()
        {
        }

        public VendingMachineItem GetVendingMachineItemById(int id)
        {
            if (id < 1) throw new ArgumentException("ID cannot be less than 1.");

            return _invDao.GetVendingMachineItemById(id);
        }

        public Change UpdateVendingMachineItem(int id, decimal userFunds)
        {
            VendingMachineItem item = GetVendingMachineItemById(id);//Also checks for invalid id bc of exception handling in dao

            if (item.Price > userFunds) throw new InsufficientFundsException("Cannot purchase, not enough funds.");
            if (item.Quantity <= 0) throw new InsufficientStockException("Cannot purchase, none left.");

            _invDao.UpdateVendingMachineItem(item);

            return new Change(userFunds - item.Price);
        }
    }
}
