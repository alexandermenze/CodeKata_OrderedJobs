using System;
using CodeKata_OrderedJobs.Source;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKata_OrderedJobs_Test
{
    [TestClass]
    public class DefaultRegistrationsTests
    {
        private IOrderedJobs _testInstance;

        [TestInitialize]
        public void InitializeTests()
        {
            _testInstance = new OrderedJobsImpl();
        }

        [TestMethod]
        public void RegisterNothing_OutNothing_Sort() 
            => Assert.AreEqual("", _testInstance.Sort(""));

        [TestMethod]
        public void RegisterSingleJob_Sort()
        {
            _testInstance.Register('a');
            Assert.AreEqual("a", _testInstance.Sort());
        }

        [TestMethod]
        public void RegisterTwoJobs_Sort()
        {
            _testInstance.Register('a');
            _testInstance.Register('b');
            _testInstance.Register('c');
            Assert.AreEqual("abc", _testInstance.Sort());
        }

        [TestMethod]
        public void RegisterSingleDependency_Sort()
        {
            _testInstance.Register('a');
            _testInstance.Register('b', 'c');
            _testInstance.Register('c');
            Assert.AreEqual("acb", _testInstance.Sort());
        }

        [TestMethod]
        public void RegisterSingleJobDouble_Sort()
        {
            _testInstance.Register('a');
            _testInstance.Register('a');
            Assert.AreEqual("a", _testInstance.Sort());
        }

        [TestMethod]
        public void RegisterMultiplejobs_MultipleDouble_Sort()
        {
            _testInstance.Register('a');
            _testInstance.Register('a');
            _testInstance.Register('b');
            _testInstance.Register('c');
            _testInstance.Register('b');
            _testInstance.Register('d');
            _testInstance.Register('a');
            Assert.AreEqual("abcd", _testInstance.Sort());
        }

        [TestMethod]
        public void RegisterTwo_AlphabetGap_InsertionOrder_Sort()
        {
            _testInstance.Register('a');
            _testInstance.Register('c');
            _testInstance.Register('b');
            Assert.AreEqual("acb", _testInstance.Sort());
        }

        [TestMethod]
        public void RegisterTwoDependant_InOrder_Sort()
        {
            _testInstance.Register('a');
            _testInstance.Register('a', 'b');
            _testInstance.Register('b', 'c');
            Assert.AreEqual("cba", _testInstance.Sort());
        }

        [TestMethod]
        public void RegisterTwoDependant_Unordered_Sort()
        {
            _testInstance.Register('c');
            _testInstance.Register('b', 'a');
            _testInstance.Register('c', 'b');
            Assert.AreEqual("abc", _testInstance.Sort());
        }

        [TestMethod]
        public void RegisterMultipleJobs_MultipleDependencies_Sort()
        {
            _testInstance.Register('a');
            _testInstance.Register('b', 'c');
            _testInstance.Register('c', 'f');
            _testInstance.Register('d', 'a');
            _testInstance.Register('e', 'b');
            _testInstance.Register('f');
            Assert.AreEqual("afcbde", _testInstance.Sort());
        }

        [TestMethod]
        public void RegisterMultipleJobs_SelfReference_Sort()
        {
            _testInstance.Register('a');
            _testInstance.Register('b');
            _testInstance.Register('c', 'c');
            Assert.ThrowsException<InvalidOperationException>(() => _testInstance.Sort());
        }

        [TestMethod]
        public void RegisterMultipleJobs_CircularReference_Sort()
        {
            _testInstance.Register('a', 'c');
            _testInstance.Register('b');
            _testInstance.Register('c', 'a');
            Assert.ThrowsException<InvalidOperationException>(() => _testInstance.Sort());
        }

        [TestMethod]
        public void RegisterSingleJob_RegisterOnlyAsDependency_Sort()
        {
            _testInstance.Register('f', 'e');
            Assert.AreEqual("ef", _testInstance.Sort());
        }
    }
}