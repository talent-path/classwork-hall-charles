using System;
using NUnit.Framework;
using VendingMachine;

namespace VendingMachineTests
{
    public class VendingMachineInMemDaoTests
    {

        InMemInventoryDao _toTest;

        [SetUp]
        public void Setup()
        {
            _toTest = new InMemInventoryDao();
        }

        //********
        //GET
        //********

        [Test]
        public void GetByIdTest()
        {
            VendingMachineItem retrievedItem = _toTest.GetVendingMachineItemById(1);

            //Assert
            Assert.AreEqual(1, retrievedItem.Id);
            Assert.AreEqual("Hershey's Chocolate Bar", retrievedItem.Name);
            Assert.AreEqual(2.00m, retrievedItem.Price);
            Assert.AreEqual(10, retrievedItem.Quantity);
        }

        [Test]
        public void GetByInvalidIdTest()
        {
            Assert.Throws<ArgumentException>(() => _toTest.GetVendingMachineItemById(10000));
        }

        //********
        //UPDATE
        //********
        [Test]
        public void UpdateVendingMachineItemTest()
        {

        }
    }
}