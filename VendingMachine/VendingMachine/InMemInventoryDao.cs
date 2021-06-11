using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    public class InMemInventoryDao : IInventoryDao
    {

        private List<VendingMachineItem> _allItems = new List<VendingMachineItem>();

        public InMemInventoryDao()
        {
        }

        public int AddVendingMachineItem(VendingMachineItem item)
        {
            if (item == null) throw new ArgumentNullException("Cannot add a null item.");

            item.Id = _allItems.Count() + 1;
            _allItems.Add(new VendingMachineItem(item));

            return item.Id;
        }

        public VendingMachineItem GetVendingMachineItemById(int id)
        {
            var receivedItem = _allItems.SingleOrDefault(w => w.Id == id);

            if (receivedItem == null) throw new ArgumentException("No item with that id was found.");

            return receivedItem;
        }

        public void UpdateVendingMachineItem(VendingMachineItem item)
        {
            if (item == null) throw new ArgumentNullException("Cannot update a null item.");
            _allItems = _allItems.Select(w => w.Id == item.Id ? item : w).ToList();
        }

        public void PurchaseCandyById(int id)
        {
            var receivedItem = _allItems.SingleOrDefault(w => w.Id == id);

            if (receivedItem == null) throw new ArgumentException("No item with that id was found.");

            receivedItem.Quantity--;
        }

        public void DeleteVendingMachineItemById(int id)
        {
            _allItems = _allItems.Where(w => w.Id != id).ToList();
        }
    }
}
