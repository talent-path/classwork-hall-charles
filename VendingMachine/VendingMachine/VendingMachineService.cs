using System;
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

        public int AddVendingMachineItem(VendingMachineItem item)
        {
            if (item.Name == string.Empty || item.Name == null) throw new ArgumentException("Name cannot be empty or null.");
            if (item.Quantity < 0) throw new ArgumentException("Quantity cannot be less than 0.");

            return _invDao.AddVendingMachineItem(item);
        }

        public VendingMachineItem GetVendingMachineItemById(int id)
        {
            if (id < 1) throw new ArgumentException("ID cannot be less than 1.");

            return _invDao.GetVendingMachineItemById(id);
        }

        public void UpdateVendingMachineItem(VendingMachineItem item)
        {
            if (item.Name == string.Empty || item.Name == null) throw new ArgumentException("Name cannot be empty or null.");
            if (item.Quantity < 0) throw new ArgumentException("Quantity cannot be less than 0.");

            _invDao.UpdateVendingMachineItem(item);
        }

        public decimal PurchaseCandyById(int id, decimal funds)
        {
            if (id < 1) throw new ArgumentException("ID cannot be less than 1.");

            VendingMachineItem item = GetVendingMachineItemById(id);

            if (item.Price > funds) throw new ArgumentException("Cannot purchase, not enough funds,");

            return _invDao.PurchaseCandyById(id, funds);
        }

        public void DeleteVendingMachineItemById(int id)
        {
            if (id < 1) throw new ArgumentException("ID cannot be less than 1.");

            _invDao.DeleteVendingMachineItemById(id);
        }
    }
}
