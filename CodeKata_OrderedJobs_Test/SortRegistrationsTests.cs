﻿using CodeKata_OrderedJobs.Source;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CodeKata_OrderedJobs_Test
{
    [TestClass]
    public class SortRegistrationsTests
    {
        private IOrderedJobs _testInstance;

        [TestInitialize]
        public void InitializeTests()
            => _testInstance = new OrderedJobsImpl();

        [TestMethod]
        public void SortRegisterEmptyIn_EmptyOut()
            => Assert.AreEqual("", _testInstance.Sort(""));

        [TestMethod]
        public void SortRegisterSingleJob()
            => Assert.AreEqual("a", _testInstance.Sort("a => "));

        [TestMethod]
        public void SortRegisterTwoJobs()
            => Assert.AreEqual("ab", _testInstance.Sort("a => \nb => "));

        [TestMethod]
        public void SortRegisterMultipleJobs()
            => Assert.AreEqual("abdefcg", _testInstance.Sort("a => \nb => \nd => \ne => \nf => \nc => \ng => "));

        [TestMethod]
        public void SortRegisterTwoJobs_Dependency()
            => Assert.AreEqual("ba", _testInstance.Sort("a => b\nb => "));

        [TestMethod]
        public void SortRegisterTwoJobs_Dependency_SpacesInText()
            => Assert.AreEqual("ba", _testInstance.Sort("a   =>  b\nb => "));

        [TestMethod]
        public void SortRegisterTwoJobs_CircularDependency()
            => Assert.ThrowsException<InvalidOperationException>(() => _testInstance.Sort("a => b\nb => a"));

        [TestMethod]
        public void SortRegisterTwoJobs_SelfDependency()
            => Assert.ThrowsException<InvalidOperationException>(() => _testInstance.Sort("b => b\na => b"));

        [TestMethod]
        public void SortRegisterTwoJobs_IncorrectSymbol()
            => Assert.ThrowsException<InvalidOperationException>(() => _testInstance.Sort("b -> a\na => "));

        [TestMethod]
        public void SortRegisterTwoJobs_IncorrectSpacing_Accept()
            => Assert.AreEqual("ab", _testInstance.Sort("b  =>   a\na => "));

        [TestMethod]
        public void SortRegisterTwoJobs_IncorrectSpacing_2_Accept()
            => Assert.AreEqual("ab", _testInstance.Sort("b  =>   a \n a => "));

        [TestMethod]
        public void SortRegisterTwoJobs_IncorrectSpacing_3_Reject()
            => Assert.ThrowsException<InvalidOperationException>(() => _testInstance.Sort("b  =>a \n a => "));

        [TestMethod]
        public void SortRegisterTwoJobs_IncorrectSpacing_4_Accept()
            => Assert.AreEqual("ab", _testInstance.Sort(" b  => a\n a => "));

        [TestMethod]
        public void SortRegisterTwoJobs_IncorrectSpacing_5_Reject()
            => Assert.ThrowsException<InvalidOperationException>(() => _testInstance.Sort("b  =>a \n a => "));

        [TestMethod]
        public void SortRegisterTwoJobs_DifferentNewLineCharRN()
            => Assert.AreEqual("ab", _testInstance.Sort("b  => a\r\n a => "));

        [TestMethod]
        public void SortRegisterTwoJobs_DifferentNewLineCharR()
            => Assert.AreEqual("ab", _testInstance.Sort("b  => a\r a => "));
    }
}