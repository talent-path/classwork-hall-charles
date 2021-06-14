using System;
using NUnit.Framework;
using VendingMachine;

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
        //ADD
        //********

        [Test]
        public void AddVendingMachineItemNullNameTest()
        {
            VendingMachineItem toAdd = new VendingMachineItem
            {
                Name = null,
                Price = 1.00m,
                Quantity = 10
            };

            Assert.Throws<ArgumentException>(() => _toTest.AddVendingMachineItem(toAdd));
        }

        [Test]
        public void AddVendingMachineItemEmptyNameTest()
        {
            VendingMachineItem toAdd = new VendingMachineItem
            {
                Name = "",
                Price = 1.00m,
                Quantity = 10
            };

            Assert.Throws<ArgumentException>(() => _toTest.AddVendingMachineItem(toAdd));
        }

        [Test]
        public void AddVendingMachineItemNegativeQuantityTest()
        {
            VendingMachineItem toAdd = new VendingMachineItem
            {
                Name = "test",
                Price = 1.00m,
                Quantity = -10000
            };

            Assert.Throws<ArgumentException>(() => _toTest.AddVendingMachineItem(toAdd));
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
        public void UpdateVendingMachineItemNullNameTest()
        {
            VendingMachineItem toAdd = new VendingMachineItem
            {
                Name = null,
                Price = 1.00m,
                Quantity = 10
            };

            Assert.Throws<ArgumentException>(() => _toTest.AddVendingMachineItem(toAdd));
        }

        [Test]
        public void UpdateVendingMachineItemEmptyNameTest()
        {
            VendingMachineItem toAdd = new VendingMachineItem
            {
                Name = "",
                Price = 1.00m,
                Quantity = 10
            };

            Assert.Throws<ArgumentException>(() => _toTest.AddVendingMachineItem(toAdd));
        }

        [Test]
        public void UpdateVendingMachineItemNegativeQuantityTest()
        {
            VendingMachineItem toAdd = new VendingMachineItem
            {
                Name = "test",
                Price = 1.00m,
                Quantity = -10000
            };

            Assert.Throws<ArgumentException>(() => _toTest.AddVendingMachineItem(toAdd));
        }

        //********
        //DELETE
        //********
        //[Test]
        //public void PurchaseCandyByInvalidIdTest()
        //{
        //    Assert.Throws<ArgumentException>(() => _toTest.PurchaseCandyById(0));
        //}


        [Test]
        public void DeleteVendingMachineItemByInvalidIdTest()
        {
            Assert.Throws<ArgumentException>(() => _toTest.DeleteVendingMachineItemById(0));
        }
    }
}
