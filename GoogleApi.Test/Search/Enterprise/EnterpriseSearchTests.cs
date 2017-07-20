using System;
using GoogleApi.Entities.Search.Enterprise.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Search.Enterprise
{
    [TestFixture]
    public class EnterpriseSearchTests : BaseTest
    {
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
                SearchEngineUrl = "abc",
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
                SearchEngineUrl = "abc",
                Query = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleSearch.EnterpriseSearch.Query(request));
            Assert.AreEqual(exception.Message, "Query is required.");
        }
    }
}