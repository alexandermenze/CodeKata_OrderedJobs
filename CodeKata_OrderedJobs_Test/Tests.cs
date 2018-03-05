using CodeKata_OrderedJobs.BL;
using CodeKata_OrderedJobs.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKata_OrderedJobs_Test
{
    [TestClass]
    public class Tests
    {
        private IOrderedJobs testInstance;

        [TestInitialize]
        public void InitializeTests()
        {
            testInstance = new OrderedJobsImpl();
        }

        [TestMethod]
        public void RegisterSingleJob_Sort()
        {
            testInstance.Register('a');
            Assert.AreEqual("a", testInstance.Sort());
        }

        [TestMethod]
        public void RegisterTwoJobs_Sort()
        {
            testInstance.Register('a');
            testInstance.Register('b');
            Assert.AreEqual("ab", testInstance.Sort());
        }

        [TestMethod]
        public void RegisterSingleJobDouble_Sort()
        {
            testInstance.Register('a');
            testInstance.Register('a');
            Assert.AreEqual("a", testInstance.Sort());
        }

        [TestMethod]
        public void RegisterMultiplejobs_MultipleDouble_Sort()
        {
            testInstance.Register('a');
            testInstance.Register('a');
            testInstance.Register('b');
            testInstance.Register('c');
            testInstance.Register('b');
            testInstance.Register('d');
            testInstance.Register('a');
            Assert.AreEqual("abcd", testInstance.Sort());
        }

        [TestMethod]
        public void RegisterTwo_AlphabetGap_InsertionOrder_Sort()
        {
            testInstance.Register('a');
            testInstance.Register('c');
            testInstance.Register('b');
            Assert.AreEqual("acb", testInstance.Sort());
        }

        [TestMethod]
        public void RegisterTwoDependant_InOrder_Sort()
        {
            testInstance.Register('a');
            testInstance.Register('a', 'b');
            testInstance.Register('b', 'c');
            Assert.AreEqual("cba", testInstance.Sort());
        }

        [TestMethod]
        public void RegisterTwoDependant_Unordered_Sort()
        {
            testInstance.Register('c');
            testInstance.Register('a', 'b');
            testInstance.Register('b', 'c');
            Assert.AreEqual("abc", testInstance.Sort());
        }
    }
}
