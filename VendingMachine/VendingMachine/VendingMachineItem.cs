using System;
namespace VendingMachine
{
    public class VendingMachineItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public VendingMachineItem()
        {
        }

        public VendingMachineItem(VendingMachineItem item)
        {
            Id = item.Id;
            Name = item.Name;
            Quantity = item.Quantity;
        }
    }
}
