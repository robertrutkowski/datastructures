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

        [TestMethod]
        public void ContainsTests()
        {
            List<int> list = list = new List<int>() { 43, 564, 65, 87, 0, 1, 2, 3, 4, 5, 45, 54, 54, 65, 6, 7, 8, 9, 10 };
            Assert.IsTrue(list.Contains(65));
            Assert.IsFalse(list.Contains(99));
        }

        [TestMethod]
        public void ExistsTests()
        {
            List<int> list = list = new List<int>() { 43, 564, 65, 87, 0, 1, 2, 3, 4, 5, 45, 54, 54, 65, 6, 7, 8, 9, 10 };
            Assert.IsTrue(list.Exists(x => x < 100));
            Assert.IsFalse(list.Exists(x => x > 1000));
        }

        [TestMethod]
        public void FindTests()
        {
            List<int> list = list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Assert.IsTrue(list.Find(x => x < 100) == 1);
            Assert.IsTrue(list.Find(x => x > 1) == 2);
            Assert.IsTrue(list.Find(x => x == 3) == 3);
            Assert.IsTrue(list.Find(x => x == 11) == 0);
        }

        [TestMethod]
        public void FindIndexTests()
        {
            List<int> list = list = new List<int>() { 1, 2, 3, 4, 5, 3, 6, 7, 8, 9, 10 };
            Assert.IsTrue(list.FindIndex(x => x < 100) == 0);
            Assert.IsTrue(list.FindIndex(x => x > 1) == 1);
            Assert.IsTrue(list.FindIndex(x => x == 3) == 2);
            Assert.IsTrue(list.FindIndex(x => x == 11) == -1);
        }

        [TestMethod]
        public void FindLastTests()
        {
            List<int> list = list = new List<int>() { 1, 2, 3, 4, 5, 3, 6, 7, 8, 9, 10 };
            Assert.IsTrue(list.FindLast(x => x < 100) == 10);
            Assert.IsTrue(list.FindLast(x => x > 1) == 10);
            Assert.IsTrue(list.FindLast(x => x == 3) == 3);
            Assert.IsTrue(list.FindLast(x => x == 1) == 1);
            Assert.IsTrue(list.FindLast(x => x == 11) == 0);
        }

        [TestMethod]
        public void FindLastIndexTests()
        {
            List<int> list = list = new List<int>() { 1, 2, 3, 4, 5, 3, 6, 7, 8, 9, 10 };
            Assert.IsTrue(list.FindLastIndex(x => x < 100) == 10);
            Assert.IsTrue(list.FindLastIndex(x => x > 1) == 10);
            Assert.IsTrue(list.FindLastIndex(x => x == 3) == 5);
            Assert.IsTrue(list.FindLastIndex(x => x == 1) == 0);
            Assert.IsTrue(list.FindLastIndex(x => x == 11) == -1);
        }

        [TestMethod]
        public void FindAllTests()
        {
            List<int> list = list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Assert.IsTrue(list.FindAll(x => x < 100).Count == 10);
            Assert.IsTrue(list.FindAll(x => x > 100).Count == 0);
            Assert.IsTrue(list.FindAll(x => x < 100).Contains(5));
        }

        [TestMethod]
        public void IndexOfTests()
        {
            List<int> list = list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 5, 9, 10 };
            Assert.IsTrue(list.IndexOf(1) == 0);
            Assert.IsTrue(list.IndexOf(5) == 4);
            Assert.IsTrue(list.IndexOf(50) == -1);
            Assert.IsTrue(list.LastIndexOf(5) == 8);
            Assert.IsTrue(list.LastIndexOf(50) == -1);
        }

        [TestMethod]
        public void TrueForAllTests()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 5, 9, 10 };
            Assert.IsTrue(list.TrueForAll(x => x > 0));
            Assert.IsFalse(list.TrueForAll(x => x < 10));
        }

        [TestMethod]
        public void ForEachTests()
        {
            int index = 0;
            List<int> list = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            list.ForEach(x => { Assert.IsTrue(x == index++); });
            Assert.IsTrue(index == 11);
        }

        [TestMethod]
        public void ConvertAllTests()
        {
            List<string> list = new List<string> { "0s", "1s", "2s", "3s", "4s", "5s", "6s", "7s", "8s", "9s" };
            this.TestListElements(list.ConvertAll(x => (int)Char.GetNumericValue(x[0])));
        }

        [TestMethod]
        public void ToArrayTests()
        {
            List<int> list = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] array = list.ToArray();
            Assert.IsTrue(array.Length == 11);

            for (int i = 0; i < array.Length; i++)
            {
                Assert.IsTrue(array[i] == i);
            } 
        }

        [TestMethod]
        public void CopyToTests()
        {
            List<int> list = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] array = new int[11];
            list.CopyTo(array);
            Assert.IsTrue(array.Length == 11);

            for (int i = 0; i < array.Length; i++)
            {
                Assert.IsTrue(array[i] == i);
            }
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
