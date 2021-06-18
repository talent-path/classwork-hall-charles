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
            _allItems.Add(new VendingMachineItem { Id = 1, Name = "Hershey's Chocolate Bar", Price = 2.00m, Quantity = 10});
            _allItems.Add(new VendingMachineItem { Id = 2, Name = "Reese's Peanut Butter Cup", Price = 2.50m, Quantity = 13 });
            _allItems.Add(new VendingMachineItem { Id = 3, Name = "Skittles", Price = 2.25m, Quantity = 12 });
            _allItems.Add(new VendingMachineItem { Id = 4, Name = "M&M's", Price = 1.75m, Quantity = 15 });
            _allItems.Add(new VendingMachineItem { Id = 5, Name = "Peanut M&M's", Price = 1.90m, Quantity = 14 });
            _allItems.Add(new VendingMachineItem { Id = 6, Name = "Almond Joy", Price = 1.75m, Quantity = 0 });
        }

        public VendingMachineItem GetVendingMachineItemById(int id)
        {
            var receivedItem = _allItems.SingleOrDefault(w => w.Id == id);

            if (receivedItem == null) throw new ArgumentException("No item with that id was found.");

            return receivedItem;
        }

        public void UpdateVendingMachineItem(VendingMachineItem item)
        {
            //Remove the -- quantity, should just replace with item
            _allItems = _allItems.Select(w => w.Id == item.Id ? item : w).ToList();
        }


    }
}
