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
