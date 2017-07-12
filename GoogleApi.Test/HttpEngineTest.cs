using System;
using System.Threading;
using GoogleApi.Entities;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Places.QueryAutoComplete.Request;
using GoogleApi.Entities.Places.QueryAutoComplete.Response;
using NUnit.Framework;

namespace GoogleApi.Test
{
    [TestFixture]
    public class HttpEngineTest : BaseTest
    {
        [Test]
        public void QueryTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void QueryWhenRequestIsNullTest()
        {
            var engine = new HttpEngine<TestRequest, TestResponse>();
            Assert.Throws<ArgumentNullException>(() => engine.Query(null));
        }

        [Test]
        public void QueryWhenTimeoutAndRequestIsNullTest()
        {
            var engine = new HttpEngine<PlacesQueryAutoCompleteRequest, PlacesQueryAutoCompleteResponse>();
            Assert.Throws<ArgumentNullException>(() => engine.Query(null, new TimeSpan()));
        }

        [Test]
        public void QueryAsyncTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void QueryAsyncWhenRequestIsNullTest()
        {
            var engine = new HttpEngine<TestRequest, TestResponse>();
            Assert.Throws<ArgumentNullException>(() => engine.QueryAsync(null));
        }

        [Test]
        public void QueryAsyncWhenRequestIsNullAndTimeoutTest()
        {
            var engine = new HttpEngine<TestRequest, TestResponse>();
            Assert.Throws<ArgumentNullException>(() => engine.QueryAsync(null, new TimeSpan()));
        }

        [Test]
        public void QueryAsyncWhenRequestIsNullAndCancellationTokenTest()
        {
            var engine = new HttpEngine<TestRequest, TestResponse>();
            Assert.Throws<ArgumentNullException>(() => engine.QueryAsync(null, new CancellationToken()));
        }

        [Test]
        public void QueryAsyncWhenRequestIsNullAndTimeoutAndCancellationTokenTest()
        {
            var engine = new HttpEngine<TestRequest, TestResponse>();
            Assert.Throws<ArgumentNullException>(() => engine.QueryAsync(null, new TimeSpan(), new CancellationToken()));
        }

        public class TestResponse : IResponseFor
        {
            public virtual string RawJson { get; set; }
            public virtual string RawQueryString { get; set; }
        }

        public class TestRequest : BaseRequest, IQueryStringRequest
        {
            protected override string BaseUrl => "www.test.com";
        }
    }
}