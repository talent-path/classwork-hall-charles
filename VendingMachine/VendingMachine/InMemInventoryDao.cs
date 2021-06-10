using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    public class InMemInventoryDao : IInventoryDao
    {

        List<VendingMachineItem> _allItems = new List<VendingMachineItem>();

        public InMemInventoryDao()
        {
        }

        public int Add(VendingMachineItem item)
        {
            if (item == null) throw new ArgumentNullException("Cannot add a null item.");

            item.Id = _allItems.Count() + 1;
            _allItems.Add(new VendingMachineItem(item));

            return item.Id;
        }

        public VendingMachineItem GetById(int id)
        {
            return _allItems.SingleOrDefault(w => w.Id == id);
        }

        public void UpdateVendingMachineItem(VendingMachineItem item)
        {
            _allItems = _allItems.Select(w => w.Id == item.Id ? item : w).ToList();
        }

        public void DeleteVendingMachineItemById(int id)
        {
            _allItems = _allItems.Where(w => w.Id != id).ToList();
        }
    }
}
