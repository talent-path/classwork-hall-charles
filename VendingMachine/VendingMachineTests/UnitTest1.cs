using System;
using NUnit.Framework;
using VendingMachine;

namespace VendingMachineTests
{
    public class Tests
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
                Quantity = 10
            };

            //Act
            int toAddId = _toTest.Add(toAdd);

            VendingMachineItem addedItem = _toTest.GetById(toAddId);

            //Assert
            Assert.AreEqual(1, toAddId);
            Assert.AreEqual(1, addedItem.Id);
            Assert.AreEqual("test", addedItem.Name);
            Assert.AreEqual(10, addedItem.Quantity);
        }

        [Test]
        public void UpdateAttemptOnAddedItemTest()
        {
            //Arrange
            VendingMachineItem toAdd = new VendingMachineItem
            {
                Name = "test",
                Quantity = 10
            };

            //Act
            int toAddId = _toTest.Add(toAdd);
            toAdd.Id = 9999;
            toAdd.Name = "bad name";
            toAdd.Quantity = 9999;

            VendingMachineItem addedItem = _toTest.GetById(toAddId);

            //Assert
            Assert.AreEqual(1, addedItem.Id);
            Assert.AreEqual("test", addedItem.Name);
            Assert.AreEqual(10, addedItem.Quantity);

        }

        [Test]
        public void AddNullItemTest()
        {
            Assert.Throws<ArgumentNullException>(() => _toTest.Add(null));
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
                Quantity = 10
            };

            //Act
            int toAddId = _toTest.Add(toAdd);

            VendingMachineItem retrievedItem = _toTest.GetById(toAddId);

            //Assert
            Assert.AreEqual(1, retrievedItem.Id);
            Assert.AreEqual("test", retrievedItem.Name);
            Assert.AreEqual(10, retrievedItem.Quantity);
        }

        [Test]
        public void GetByInvalidIdTest()
        {
            Assert.Throws<ArgumentException>(() => _toTest.GetById(10000));
        }


        //********
        //UPDATE
        //********

        //********
        //DELETE
        //********

    }
}