using CodeKata_OrderedJobs.BL;
using CodeKata_OrderedJobs.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            testInstance.Register('c');
            Assert.AreEqual("abc", testInstance.Sort());
        }

        [TestMethod]
        public void RegisterSingleDependency_Sort()
        {
            testInstance.Register('a');
            testInstance.Register('b', 'c');
            testInstance.Register('c');
            Assert.AreEqual("acb", testInstance.Sort());
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
            testInstance.Register('b', 'a');
            testInstance.Register('c', 'b');
            Assert.AreEqual("abc", testInstance.Sort());
        }

        [TestMethod]
        public void RegisterMultipleJobs_MultipleDependencies_Sort()
        {
            testInstance.Register('a');
            testInstance.Register('b', 'c');
            testInstance.Register('c', 'f');
            testInstance.Register('d', 'a');
            testInstance.Register('e', 'b');
            testInstance.Register('f');
            Assert.AreEqual("afcbde", testInstance.Sort());
        }

        [TestMethod]
        public void RegisterMultipleJobs_SelfReference_Sort()
        {
            testInstance.Register('a');
            testInstance.Register('b');
            testInstance.Register('c', 'c');
            Assert.ThrowsException<InvalidOperationException>(() => testInstance.Sort());
        }

        [TestMethod]
        public void RegisterMultipleJobs_CircularReference_Sort()
        {
            testInstance.Register('a', 'c');
            testInstance.Register('b');
            testInstance.Register('c', 'a');
            Assert.ThrowsException<InvalidOperationException>(() => testInstance.Sort());
        }

        [TestMethod]
        public void RegisterSingleJob_RegisterOnlyAsDependency_Sort()
        {
            testInstance.Register('f', 'e');
            Assert.AreEqual("ef", testInstance.Sort());
        }
    }
}
