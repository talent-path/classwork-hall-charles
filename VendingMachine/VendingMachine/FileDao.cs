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
            File.Delete(filePath);
            File.Copy("../../../Seed.txt", filePath);

            FilePath = filePath;
            GetItemsFromFile(FilePath);
        }

        public void GetItemsFromFile(string FilePath)
        {
            using(StreamReader reader = new StreamReader(FilePath))
            {
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] arr = line.Split(',');
                    _allItems.Add(new VendingMachineItem
                    {
                        Id = int.Parse(arr[0]),
                        Name = arr[1],
                        Price = decimal.Parse(arr[2]),
                        Quantity = int.Parse(arr[3])
                    });
                }
            }
        }

        public VendingMachineItem GetVendingMachineItemById(int id)
        {
            var receivedItem = _allItems.SingleOrDefault(w => w.Id == id);

            if (receivedItem == null) throw new ArgumentException("No item with that id was found.");

            return receivedItem;
        }

        public void UpdateVendingMachineItem(VendingMachineItem item)
        {
            _allItems = _allItems.Select(w => w.Id == item.Id ? item : w).ToList();

            WriteToFile(_allItems);
        }

        private void WriteToFile(List<VendingMachineItem> allItems)
        {
            string newText = "";

            foreach (VendingMachineItem item in allItems)
            {
                newText += item.Id + "," + item.Name + "," + item.Price + "," + item.Quantity + "\n";
            }

            File.WriteAllText("../../../Prod.txt", newText);
        }

    }
}
