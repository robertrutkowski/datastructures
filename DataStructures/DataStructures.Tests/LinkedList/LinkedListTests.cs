using DataStructures.LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Tests.LinkedList
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void AddFirstToEmptyList()
        {
            LinkedList<int> list = new LinkedList<int>();

            list.AddFirst(1);
            Assert.IsTrue(list.Count == 1);
            Assert.IsTrue(list[0] == 1);

            list.AddFirst(2);
            Assert.IsTrue(list.Count == 2);
            Assert.IsTrue(list[0] == 2);
        }

        [TestMethod]
        public void AddToEmptyList()
        {
            LinkedList<int> list = new LinkedList<int>();

            list.Add(1);
            Assert.IsTrue(list.Count == 1);
            Assert.IsTrue(list[0] == 1);

            list.Add(2);
            Assert.IsTrue(list.Count == 2);
            Assert.IsTrue(list[1] == 2);
        }

        [TestMethod]
        public void ClearList()
        {
            LinkedList<int> list = new LinkedList<int>() { 1, 2 };

            list.Clear();
            Assert.ThrowsException<IndexOutOfRangeException>(() => { int item = list[0]; });
        }

        [TestMethod]
        public void GetItemByIndexer()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(5);
            list.AddFirst(6);

            Assert.IsTrue(list[0] == 6);
            Assert.IsTrue(list[1] == 5);
        }

        [TestMethod]
        public void ContainsTest()
        {
            LinkedList<int> list = new LinkedList<int>() { 1, 2, 3 };

            Assert.IsTrue(list.Contains(1));
            Assert.IsTrue(list.Contains(2));
            Assert.IsTrue(list.Contains(3));
            Assert.IsTrue(!list.Contains(4));
        }
    }
}
