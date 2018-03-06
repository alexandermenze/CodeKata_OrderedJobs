using CodeKata_OrderedJobs.Source;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKata_OrderedJobs_Test
{
    [TestClass]
    public class SortRegistrationsTests
    {
        private IOrderedJobs _testInstance;

        [TestInitialize]
        public void InitializeTests()
        {
            _testInstance = new OrderedJobsImpl();
        }

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
    }
}
