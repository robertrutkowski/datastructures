using DataStructures.LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Tests.LinkedList
{
    [TestClass]
    public class AddItemTests
    {
        [TestMethod]
        public void AddFirstToEmptyList()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(5);

            Assert.IsTrue(list.Count == 1);
            Assert.IsTrue(list[0] == 5);
        }
    }
}
