using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VendingMachine
{
    public class FileDao : IInventoryDao
    {

        List<VendingMachineItem> _allItems = new List<VendingMachineItem>();
        string FilePath { get; set; }

        public FileDao(string filePath)
        {
            FilePath = filePath;
            GetItems(FilePath);
        }

        public void GetItems(string FilePath)
        {
            using(StreamReader reader = new StreamReader(FilePath))
            {
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] arr = line.Split(',');
                    AddVendingMachineItem(new VendingMachineItem
                    {
                        Name = arr[0],
                        Price = decimal.Parse(arr[1]),
                        Quantity = int.Parse(arr[2])
                    });
                }
            }

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

        public decimal PurchaseCandyById(int id, decimal userFunds)
        {
            var receivedItem = _allItems.SingleOrDefault(w => w.Id == id);

            if (receivedItem == null) throw new ArgumentException("No item with that id was found.");

            receivedItem.Quantity--;
            return userFunds - receivedItem.Price;
        }

        public void DeleteVendingMachineItemById(int id)
        {
            _allItems = _allItems.Where(w => w.Id != id).ToList();
        }
    }
}
