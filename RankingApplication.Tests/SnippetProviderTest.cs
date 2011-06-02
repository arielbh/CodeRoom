using RankerApplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;

namespace RankingApplication.Tests
{
    
    
    /// <summary>
    ///This is a test class for SnippetProviderTest and is intended
    ///to contain all SnippetProviderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SnippetProviderTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        ///// <summary>
        /////A test for SnippetProvider Constructor
        /////</summary>
        //[TestMethod()]
        //public void SnippetProviderConstructorTest()
        //{
        //    SnippetProvider target = new SnippetProvider();
        //    Assert.Inconclusive("TODO: Implement code to verify target");
        //}

        /// <summary>
        ///A test for GetNext
        ///</summary>
        [TestMethod()]
        public void GetNext_ExistingSnippet_WeGetSnippet()
        {
            var snippet = new Snippet();
            var mock = new Mock<IRepository>();

            mock.Setup(m => m.GetNext()).Returns(() => snippet);

            ISnippetProvider target = new SnippetProvider(mock.Object); 
            
            var actual = target.GetNext();

            Assert.AreEqual(snippet, actual);
        }
    }
}
