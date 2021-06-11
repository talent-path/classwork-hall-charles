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
        //ADD
        //********

        [Test]
        public void AddItemTest()
        {
            //Arrange
            VendingMachineItem toAdd = new VendingMachineItem
            {
                Name = "test",
                Price = 1.00m,
                Quantity = 10
            };

            //Act
            int toAddId = _toTest.AddVendingMachineItem(toAdd);

            VendingMachineItem addedItem = _toTest.GetVendingMachineItemById(toAddId);

            //Assert
            Assert.AreEqual(1, toAddId);
            Assert.AreEqual(1, addedItem.Id);
            Assert.AreEqual("test", addedItem.Name);
            Assert.AreEqual(1.00m, addedItem.Price);
            Assert.AreEqual(10, addedItem.Quantity);
        }

        [Test]
        public void UpdateAttemptOnAddedItemTest()
        {
            //Arrange
            VendingMachineItem toAdd = new VendingMachineItem
            {
                Name = "test",
                Price = 1.00m,
                Quantity = 10
            };

            //Act
            int toAddId = _toTest.AddVendingMachineItem(toAdd);
            toAdd.Id = 9999;
            toAdd.Name = "bad name";
            toAdd.Quantity = 9999;

            VendingMachineItem addedItem = _toTest.GetVendingMachineItemById(toAddId);

            //Assert
            Assert.AreEqual(1, addedItem.Id);
            Assert.AreEqual("test", addedItem.Name);
            Assert.AreEqual(1.00m, addedItem.Price);
            Assert.AreEqual(10, addedItem.Quantity);

        }

        [Test]
        public void AddNullItemTest()
        {
            Assert.Throws<ArgumentNullException>(() => _toTest.AddVendingMachineItem(null));
        }

        //********
        //GET
        //********

        [Test]
        public void GetByIdTest()
        {
            //Arrange
            VendingMachineItem toAdd = new VendingMachineItem
            {
                Name = "test",
                Price = 1.00m,
                Quantity = 10
            };

            //Act
            int toAddId = _toTest.AddVendingMachineItem(toAdd);

            VendingMachineItem retrievedItem = _toTest.GetVendingMachineItemById(toAddId);

            //Assert
            Assert.AreEqual(1, retrievedItem.Id);
            Assert.AreEqual("test", retrievedItem.Name);
            Assert.AreEqual(1.00m, retrievedItem.Price);
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
        public void UpdateVendingMachineItem()
        {
            //Arrange
            VendingMachineItem toAdd = new VendingMachineItem
            {
                Name = "test",
                Price = 1.00m,
                Quantity = 10
            };

            //Act
            int toAddId = _toTest.AddVendingMachineItem(toAdd);

            _toTest.UpdateVendingMachineItem(new VendingMachineItem { Id = 1, Name = "new name", Price = 99.00m, Quantity = 99 });

            VendingMachineItem retrievedItem = _toTest.GetVendingMachineItemById(toAddId);

            //Assert
            Assert.AreEqual(1, retrievedItem.Id);
            Assert.AreEqual("new name", retrievedItem.Name);
            Assert.AreEqual(99.00m, retrievedItem.Price);
            Assert.AreEqual(99, retrievedItem.Quantity);
        }

        [Test]
        public void UpdateInvalidVendingMachineItem()
        {
            //Arrange
            VendingMachineItem toAdd = new VendingMachineItem
            {
                Name = "test",
                Price = 1.00m,
                Quantity = 10
            };

            //Act
            int toAddId = _toTest.AddVendingMachineItem(toAdd);
            _toTest.UpdateVendingMachineItem(new VendingMachineItem { Id = 10000, Name = "new name", Price = 99.00m, Quantity = 99 });
            VendingMachineItem retrievedItem = _toTest.GetVendingMachineItemById(toAddId);

            //Assert
            Assert.AreEqual(1, retrievedItem.Id);
            Assert.AreEqual("test", retrievedItem.Name);
            Assert.AreEqual(1.00m, retrievedItem.Price);
            Assert.AreEqual(10, retrievedItem.Quantity);
        }

        [Test]
        public void UpdateNullVendingMachineItem()
        {
            Assert.Throws<ArgumentNullException>(() => _toTest.UpdateVendingMachineItem(null));
        }

        //********
        //DELETE
        //********

        [Test]
        public void PurchaseCandyById()
        {
            //Arrange
            VendingMachineItem toAdd = new VendingMachineItem
            {
                Name = "test",
                Price = 1.00m,
                Quantity = 10
            };

            //Act
            int toAddId = _toTest.AddVendingMachineItem(toAdd);
            _toTest.PurchaseCandyById(toAddId);
            var recievedItem = _toTest.GetVendingMachineItemById(toAddId);

            //Assert
            Assert.AreEqual(9, recievedItem.Quantity);
         }

        public void PurchaseInvalidCandy()
        {
            Assert.Throws<ArgumentNullException>(() => _toTest.PurchaseCandyById(10000));
        }


        [Test]
        public void RemoveVendingMachineItemById()
        {
            //Arrange
            VendingMachineItem toAdd = new VendingMachineItem
            {
                Name = "test",
                Price = 1.00m,
                Quantity = 10
            };

            //Act
            int toAddId = _toTest.AddVendingMachineItem(toAdd);

            _toTest.DeleteVendingMachineItemById(toAddId);

            //Assert
            Assert.Throws<ArgumentException>(() => _toTest.GetVendingMachineItemById(toAddId));
        }

        [Test]
        public void RemoveInvalidVendingMachineItemById()
        {
            //Arrange
            VendingMachineItem toAdd = new VendingMachineItem
            {
                Name = "test",
                Price = 1.00m,
                Quantity = 10
            };

            //Act
            int toAddId = _toTest.AddVendingMachineItem(toAdd);
            _toTest.DeleteVendingMachineItemById(10000);
            VendingMachineItem retrievedItem = _toTest.GetVendingMachineItemById(toAddId);

            //Assert
            Assert.AreEqual(1, retrievedItem.Id);
            Assert.AreEqual("test", retrievedItem.Name);
            Assert.AreEqual(1.00m, retrievedItem.Price);
            Assert.AreEqual(10, retrievedItem.Quantity);
        }

    }
}