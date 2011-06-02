using System.Threading;
using Moq;
using RankerApplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RankingApplication.Tests
{
    
    
    /// <summary>
    ///This is a test class for RankerTest and is intended
    ///to contain all RankerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RankerTest
    {


        private TestContext testContextInstance;
        private Mock<IRuleEngine> ruleEngineMock;
        private Mock<ISnippetProvider> snippetProviderMock;
        private Mock<IRuleEngineProvider> ruleEngineProviderMock;
        private Mock<IRepository> repositoryMock;
        private Ranker ranker;
        private Snippet snippet;

        const int RankValue = 42;

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


        /// <summary>
        ///A test for Start
        ///</summary>
        [TestMethod()]
        [DeploymentItem("RankerApplication.exe")]
        public void Start_RepositryHasSnippetForRanking_SnippetIsSaved()
        {
            RunRanker();
            repositoryMock.Verify(AsyncCallback => AsyncCallback.Save(It.IsAny<Snippet>()));
        }

        [TestMethod()]
        [DeploymentItem("RankerApplication.exe")]
        public void Start_RepositryHasSnippetForRanking_SnippetGotSpecifiedRank()
        {
            RunRanker();
            Assert.AreEqual(RankValue, snippet.Rank);
        }



        private void RunRanker()
        {
            Setup();
            ranker.Start();
            Thread.Sleep(400);
            ranker.Stop();
        }

        private void Setup()
        {
            snippet = new Snippet();
            ruleEngineMock = new Mock<IRuleEngine>();
            ruleEngineMock.Setup(m => m.Rank(It.IsAny<Snippet>())).Returns(RankValue);
            snippetProviderMock = CreateSnippetProviderMock(snippet);
            ruleEngineProviderMock = CreateRuleEngineProviderMock(ruleEngineMock, snippet);
            repositoryMock = new Mock<IRepository>();
            ranker = new Ranker(snippetProviderMock.Object, ruleEngineProviderMock.Object, repositoryMock.Object);
        }

        private static Mock<IRuleEngineProvider> CreateRuleEngineProviderMock(Mock<IRuleEngine> ruleEngineMock, Snippet snippet)
        {
            var ruleEngineProviderMock = new Mock<IRuleEngineProvider>();
            ruleEngineProviderMock.Setup(m => m.GetRuleEngineByLanguage(snippet.Language)).Returns(ruleEngineMock.Object);
            return ruleEngineProviderMock;
        }

        private static Mock<ISnippetProvider> CreateSnippetProviderMock(Snippet snippet)
        {
            var snippetProviderMock = new Mock<ISnippetProvider>();
            snippetProviderMock.Setup(m => m.GetNext()).Returns(snippet);
            return snippetProviderMock;
        }

        /// <summary>
        ///A test for Stop
        ///</summary>
        [TestMethod()]
        [DeploymentItem("RankerApplication.exe")]
        public void StopTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Ranker_Accessor target = new Ranker_Accessor(param0); // TODO: Initialize to an appropriate value
            target.Stop();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
