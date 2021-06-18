using System;
using System.IO;
using NUnit.Framework;
using VendingMachine;

namespace VendingMachineTests
{
    public class VendingMachineFileDaoTests
    {
        FileDao _toTest = new FileDao("../../../../VendingMachine/Test.txt");

        [SetUp]
        public void SetUp()
        {
            File.Delete("../../../../VendingMachine/Test.txt");
            File.Copy("../../../../VendingMachine/Seed.txt", "../../../../VendingMachine/Test.txt");
        }

        [Test]
        public void GetVendingMachineItemByIdTest()
        {
            VendingMachineItem retrievedItem = _toTest.GetVendingMachineItemById(1);

            Assert.AreEqual(1, retrievedItem.Id);
            Assert.AreEqual("Hershey's Chocolate Bar", retrievedItem.Name);
            Assert.AreEqual(2.00m, retrievedItem.Price);
            Assert.AreEqual(10, retrievedItem.Quantity);
        }

        [Test]
        public void GetVendingMachineItemByIdInvalidIdTest()
        {
            Assert.Throws<ArgumentException>(() => _toTest.GetVendingMachineItemById(10000));
        }


        [Test]
        public void UpdateVendingMachineItem()
        {
            VendingMachineItem toUpdate = new VendingMachineItem { Id = 1, Name = "Hershey's Chocolate Bar", Price = 2.00m, Quantity = 5 };

            _toTest.UpdateVendingMachineItem(toUpdate);

            VendingMachineItem retrievedItem = _toTest.GetVendingMachineItemById(1);

            Assert.AreEqual(1, retrievedItem.Id);
            Assert.AreEqual("Hershey's Chocolate Bar", retrievedItem.Name);
            Assert.AreEqual(2.00m, retrievedItem.Price);
            Assert.AreEqual(5, retrievedItem.Quantity);
        }


    }
}
