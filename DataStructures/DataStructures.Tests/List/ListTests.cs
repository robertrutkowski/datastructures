using DataStructures.List;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tests.List
{
    [TestClass]
    public class ListTests
    {
        [TestMethod]
        public void IndexerTest()
        {
            List<int> list = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.ThrowsException<IndexOutOfRangeException>(() => list[10]);
            Assert.ThrowsException<IndexOutOfRangeException>(() => list[-1]);

            Assert.IsTrue(list[0] == 0);
            Assert.IsTrue(list[9] == 9);
        }

        [TestMethod]
        public void ForeachTest()
        {
            List<int> list = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int index = 0;
            foreach (int i in list)
            {
                Assert.IsTrue(i == index++);
            }
            Assert.IsTrue(index == 10);
        }

        [TestMethod]
        public void CountTest()
        {
            List<int> list = new List<int>();
            Assert.IsTrue(list.Count == 0);

            list = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Assert.IsTrue(list.Count == 10);
        }

        [TestMethod]
        public void CapacityTest()
        {
            List<int> list = new List<int>();
            Assert.IsTrue(list.Capacity == 0);

            list = new List<int>(10);
            Assert.IsTrue(list.Capacity == 10);

            list = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Assert.IsTrue(list.Capacity == 16);
        }

        [TestMethod]
        public void TrimExcessTest()
        {
            List<int> list = new List<int>();
            list.TrimExcess();
            Assert.IsTrue(list.Capacity == 0);

            list = new List<int>(10);
            list.TrimExcess();
            Assert.IsTrue(list.Capacity == 0);

            list = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            list.TrimExcess();
            Assert.IsTrue(list.Capacity == 10);
        }

        [TestMethod]
        public void ClearTest()
        {
            List<int> list = new List<int>();
            list.Clear();
            Assert.IsTrue(list.Count == 0);

            list = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            list.Clear();
            Assert.IsTrue(list.Count == 0);

            Assert.ThrowsException<IndexOutOfRangeException>(() => list[0]);
        }

        [TestMethod]
        public void InsertTests()
        {
            List<int> list = new List<int>() { 0, 2, 3, 4 };
            Assert.ThrowsException<IndexOutOfRangeException>(() => list.Insert(5, 5));
            Assert.ThrowsException<IndexOutOfRangeException>(() => list.Insert(-1, -1));

            list.Insert(1, 1);
            this.TestListElements(list);

            list = new List<int>() { 1, 2, 3 };
            list.Insert(0, 0);
            this.TestListElements(list);
        }

        [TestMethod]
        public void InsertRangeTests()
        {
            List<int> list = new List<int>() { 0, 2, 3, 4 };
            Assert.ThrowsException<IndexOutOfRangeException>(() => list.InsertRange(5, new int[] { 5 }));
            Assert.ThrowsException<IndexOutOfRangeException>(() => list.InsertRange(-1, new int[] { -1 }));

            list.InsertRange(1, new int[] { 1 });
            this.TestListElements(list);

            list = new List<int>() { 0, 10, 11, 12, 13 };
            list.InsertRange(1, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            this.TestListElements(list);
        }

        [TestMethod]
        public void AddRangeTests()
        {
            List<int> list = new List<int>() { 0, 1 };
            list.AddRange(new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            this.TestListElements(list);
        }

        [TestMethod]
        public void GetRangeTests()
        {
            List<int> list = new List<int>() { 0, 1 };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.GetRange(5, 1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.GetRange(-1, 1));
            Assert.ThrowsException<ArgumentException>(() => list.GetRange(1, -1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.GetRange(1, 6));

            list = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            this.TestListElements(list.GetRange(0, 0));
            this.TestListElements(list.GetRange(0, 10));
            list = new List<int>() { 1, 1, 1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            this.TestListElements(list.GetRange(3, 8));
        }

        [TestMethod]
        public void RemoveAtTests()
        {
            List<int> list = new List<int>() { 0, 1 };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.RemoveAt(5));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.RemoveAt(-1));

            list = new List<int>() { 0, 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            list.RemoveAt(1);
            Assert.IsTrue(list.Count == 11);
            this.TestListElements(list);

            list = new List<int>() { 0 };
            list.RemoveAt(0);
            Assert.IsTrue(list.Count == 0);
        }

        [TestMethod]
        public void RemoveRangeTests()
        {
            List<int> list = new List<int>() { 0, 1 };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.GetRange(5, 1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.GetRange(-1, 1));
            Assert.ThrowsException<ArgumentException>(() => list.GetRange(1, -1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.GetRange(1, 6));

            list = new List<int>() { 0, 1, 1, 1, 1, 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            list.RemoveRange(1, 5);
            Assert.IsTrue(list.Count == 11);
            this.TestListElements(list);

            list = new List<int>() { 1 };
            list.RemoveRange(0, 1);
            Assert.IsTrue(list.Count == 0);
        }

        [TestMethod]
        public void RemoveTests()
        {
            List<int> list = list = new List<int>() { 0, 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Assert.IsTrue(list.Remove(1));
            this.TestListElements(list);
            Assert.IsFalse(list.Remove(100));
        }

        [TestMethod]
        public void RemoveAllTests()
        {
            List<int> list = list = new List<int>() { 43, 564, 65, 87, 0, 1, 2, 3, 4, 5, 45, 54, 54, 65, 6, 7, 8, 9, 10 };
            list.RemoveAll(x => x > 30);
            this.TestListElements(list);
        }

        private void TestListElements(List<int> list)
        {
            int index = 0;
            foreach (int i in list)
            {
                Assert.IsTrue(list[index] == index);
                index++;
            }
        }
    }
}
