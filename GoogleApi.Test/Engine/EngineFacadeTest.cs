using System;
using System.Threading;
using GoogleApi.Entities.Places.QueryAutoComplete.Request;
using GoogleApi.Entities.Places.QueryAutoComplete.Response;
using NUnit.Framework;

namespace GoogleApi.Test.Engine
{
    [TestFixture]
    public class EngineFacadeTest : BaseTest
    {
        [Test]
        public void QueryTest()
        {
            var engine = new FacadeEngine<TestRequest, TestResponse>();
            Assert.DoesNotThrow(() => engine.Query(new TestRequest()));
        }
        [Test]
        public void QueryWhenRequestIsNullTest()
        {
            var engine = new FacadeEngine<TestRequest, TestResponse>();
            Assert.Throws<ArgumentNullException>(() => engine.Query(null));
        }
        [Test]
        public void QueryWhenTimeoutAndRequestIsNullTest()
        {
            var engine = new FacadeEngine<PlacesQueryAutoCompleteRequest, PlacesQueryAutoCompleteResponse>();
            Assert.Throws<ArgumentNullException>(() => engine.Query(null, new TimeSpan()));
        }

        [Test]
        public void QueryAsyncTest()
        {
            var engine = new FacadeEngine<TestRequest, TestResponse>();
            Assert.DoesNotThrow(() =>
            {
                var result = engine.QueryAsync(new TestRequest()).Result;
                Assert.IsNull(result);
            });
        }
        [Test]
        public void QueryAsyncWhenRequestIsNullTest()
        {
            var engine = new FacadeEngine<TestRequest, TestResponse>();
            Assert.Throws<ArgumentNullException>(() => engine.QueryAsync(null));
        }
        [Test]
        public void QueryAsyncWhenRequestIsNullAndTimeoutTest()
        {
            var engine = new FacadeEngine<TestRequest, TestResponse>();
            Assert.Throws<ArgumentNullException>(() => engine.QueryAsync(null, new TimeSpan()));
        }
        [Test]
        public void QueryAsyncWhenRequestIsNullAndCancellationTokenTest()
        {
            var engine = new FacadeEngine<TestRequest, TestResponse>();
            Assert.Throws<ArgumentNullException>(() => engine.QueryAsync(null, new CancellationToken()));
        }
        [Test]
        public void QueryAsyncWhenRequestIsNullAndTimeoutAndCancellationTokenTest()
        {
            var engine = new FacadeEngine<TestRequest, TestResponse>();
            Assert.Throws<ArgumentNullException>(() => engine.QueryAsync(null, new TimeSpan(), new CancellationToken()));
        }
    }
}