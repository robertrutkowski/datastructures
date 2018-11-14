using DataStructures.LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataStructures.Tests.LinkedList
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void AddFirstTests()
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
        public void AddLastTests()
        {
            LinkedList<int> list = new LinkedList<int>();

            list.AddLast(1);
            Assert.IsTrue(list.Count == 1);
            Assert.IsTrue(list[0] == 1);

            list.AddLast(2);
            Assert.IsTrue(list.Count == 2);
            Assert.IsTrue(list[0] == 1);
            Assert.IsTrue(list[1] == 2);
        }

        [TestMethod]
        public void RemoveFirstTests()
        {
            LinkedList<int> list = new LinkedList<int>() { 0, 1, 2, 3, 4, 5 };

            list.RemoveFirst();
            Assert.IsTrue(list.Count == 5);
            Assert.IsTrue(list[0] == 1);
            Assert.IsTrue(list[1] == 2);

            list = new LinkedList<int>();
            Assert.ThrowsException<InvalidOperationException>(() => list.RemoveFirst());

            list = new LinkedList<int>() { 0 };
            list.RemoveFirst();
            Assert.IsTrue(list.Count == 0);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }

        [TestMethod]
        public void RemoveLastTests()
        {
            LinkedList<int> list = new LinkedList<int>() { 0, 1, 2, 3, 4, 5 };

            list.RemoveLast();
            Assert.IsTrue(list.Count == 5);
            Assert.IsTrue(list[4] == 4);

            list = new LinkedList<int>();
            Assert.ThrowsException<InvalidOperationException>(() => list.RemoveLast());

            list = new LinkedList<int>() { 0 };
            list.RemoveLast();
            Assert.IsTrue(list.Count == 0);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }

        [TestMethod]
        public void CopyToTests()
        {
            LinkedList<int> list = new LinkedList<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] array = new int[11];
            list.CopyTo(array, 0);
            Assert.IsTrue(array.Length == 11);

            for (int i = 0; i < array.Length; i++)
            {
                Assert.IsTrue(array[i] == i);
            }
        }

        [TestMethod]
        public void RemoveTests()
        {
            LinkedList<int> list = new LinkedList<int>() { 0, 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            list.Remove(1);
            Assert.IsTrue(list.Count == 11);
            int index = 0;
            foreach (var item in list)
            {
                Assert.IsTrue(item == index++);
            }

            list = new LinkedList<int>() { 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            list.Remove(0);
            Assert.IsTrue(list.Count == 11);
            index = 0;
            foreach (var item in list)
            {
                Assert.IsTrue(item == index++);
            }

            list = new LinkedList<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            list.Remove(10);
            Assert.IsTrue(list.Count == 10);
            index = 0;
            foreach (var item in list)
            {
                Assert.IsTrue(item == index++);
            }

            list = new LinkedList<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10 };
            list.Remove(10);
            Assert.IsTrue(list.Count == 11);
            Assert.IsTrue(list.Tail.Item == 10);
            Assert.IsNull(list.Tail.Next);
            index = 0;
            foreach (var item in list)
            {
                Assert.IsTrue(item == index++);
            }
        }

        [TestMethod]
        public void AddTests()
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
