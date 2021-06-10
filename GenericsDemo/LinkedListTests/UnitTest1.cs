using System;
using System.Linq;
using LinkedList;
using NUnit.Framework;

namespace LinkedListTests
{
    public class Tests
    {

        DavidLinkedList<string> list;

        [OneTimeSetUp]
        public void SetUpAllTests()
        {
        }

        [OneTimeSetUp]
        public void SecondSetUp()
        {

        }

        [SetUp]
        public void Setup()
        {
            list = new DavidLinkedList<string>();
        }

        [Test]
        public void LinkedListAdd([Values("one", "")] string first, [Values("two", "")] string second)
        {
            list.Add(first);
            Assert.AreEqual(first, list.First());
            Assert.AreEqual(1, list.Count());

            list.Add(second);
            Assert.AreEqual(first, list.First());
            Assert.AreEqual(second, list.Skip(1).First());
            Assert.AreEqual(2, list.Count());
        }

        [Test]
        public void LinkedListAddNull()
        {
            Assert.Throws<ArgumentNullException>(() => list.Add(null));
        }

        [TestCase("one", "two")]
        [TestCase("", "")]
        public void LinkedListRemove(string first, string second)
        {
            list.Add(first);
            Assert.AreEqual(first, list.First());
            Assert.AreEqual(1, list.Count());

            list.Add(second);

            list.Remove(first);
            Assert.AreEqual(second, list.First());
            Assert.AreEqual(1, list.Count());
        }

        [Test]
        public void LinkedListRemoveNotFound()
        {
            list.Add("one");
            Assert.AreEqual("one", list.First());
            Assert.AreEqual(1, list.Count());

            list.Add("two");

            Assert.Throws<ItemNotFoundException>(() => list.Remove("three"));
        }

    }
}