using DataStructures.LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Tests.LinkedList
{
    [TestClass]
    public class RetrieveItemTests
    {
        [TestMethod]
        public void GetItemByIndexer()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(5);
            list.AddFirst(6);

            Assert.IsTrue(list[0] == 6);
            Assert.IsTrue(list[1] == 5);
        }
    }
}
