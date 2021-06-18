using System;
using NUnit.Framework;
using VendingMachine;
using VendingMachine.exceptions;

namespace VendingMachineTests
{
    public class VendingMachineServiceTests
    {
        
        VendingMachineService _toTest;
        InMemInventoryDao _testDao;

        [SetUp]
        public void Setup()
        {
            _testDao = new InMemInventoryDao();
            _toTest = new VendingMachineService(_testDao);
        }

        //********
        //GET
        //********

        [Test]
        public void GetVendingMachineItemByInvalidIdTest()
        {
            Assert.Throws<ArgumentException>(() => _toTest.GetVendingMachineItemById(0));
        }

        //********
        //UPDATE
        //********
        [Test]
        public void UpdateVendingMachineItemChangeTest()
        {
            Change change = _toTest.UpdateVendingMachineItem(1, 5.00m);

            Assert.AreEqual(3, change.dollars);
            Assert.AreEqual(0, change.quarters);
            Assert.AreEqual(0, change.dimes);
            Assert.AreEqual(0, change.nickels);
            Assert.AreEqual(0, change.pennies);


            Change change2 = _toTest.UpdateVendingMachineItem(2, 5.00m);

            Assert.AreEqual(2, change2.dollars);
            Assert.AreEqual(2, change2.quarters);
            Assert.AreEqual(0, change.dimes);
            Assert.AreEqual(0, change.nickels);
            Assert.AreEqual(0, change.pennies);
        }


        [Test]
        public void UpdateVendingMachineItemInvalidIdTest()
        {
            Assert.Throws<ArgumentException>(() => _toTest.UpdateVendingMachineItem(10000, 2.00m));
        }

        [Test]
        public void UpdateVendingMachineItemNotEnoughFundsTest()
        {
            //Hershey's bar is 2.00
            Assert.Throws<InsufficientFundsException>(() => _toTest.UpdateVendingMachineItem(1, 1.50m));
        }

        [Test]
        public void UpdateVendingMachineItemNotEnoughItemsTest()
        {
            //0 Almond Joys left, they are $1.75
            Assert.Throws<InsufficientStockException>(() => _toTest.UpdateVendingMachineItem(6, 2.00m));
        }

    }
}
