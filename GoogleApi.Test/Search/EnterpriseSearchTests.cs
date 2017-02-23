using System;
using GoogleApi.Entities.Search.Enterprise.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Search
{
    [TestFixture]
    public class EnterpriseSearchTests : BaseTest
    {
        protected virtual string SearchEngineUrl { get; set; }
        protected override string KeyFile { get; set; } = "keyfile_search.txt";

        [OneTimeSetUp]
        public override void Setup()
        {
            base.Setup();

            this.SearchEngineUrl = this.GetFileInfo("search_engine_url.txt").ToString();
        }

        [Test]
        public void EnterpriseSearchTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void EnterpriseSearchWhenKeyIsNullTest()
        {
            var request = new EnterpriseSearchRequest
            {
                Key = null,
                SearchEngineUrl = this.SearchEngineUrl,
                Query = "google"
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleSearch.EnterpriseSearch.Query(request));
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void EnterpriseSearchWhenSearchEngineIdIsNullTest()
        {
            var request = new EnterpriseSearchRequest
            {
                Key = this.ApiKey,
                SearchEngineUrl = null,
                Query = "google"
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleSearch.EnterpriseSearch.Query(request));
            Assert.AreEqual(exception.Message, "SearchEngineUrl is required.");
        }
        [Test]
        public void EnterpriseSearchWhenQueryIsNullTest()
        {
            var request = new EnterpriseSearchRequest
            {
                Key = this.ApiKey,
                SearchEngineUrl = this.SearchEngineUrl,
                Query = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleSearch.EnterpriseSearch.Query(request));
            Assert.AreEqual(exception.Message, "Query is required.");
        }
    }
}