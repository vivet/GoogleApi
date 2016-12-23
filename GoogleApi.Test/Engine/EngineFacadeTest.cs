using System;
using System.Threading;
using GoogleApi.Engine;
using GoogleApi.Entities.Places.QueryAutoComplete.Request;
using GoogleApi.Entities.Places.QueryAutoComplete.Response;
using NUnit.Framework;

namespace GoogleApi.Test.Engine
{
    [TestFixture]
    public class EngineFacadeTest : BaseTest
    {
        [Test]
        public void QueryWhenRequestIsNullTest()
        {
            var _engine = new EngineFacade<TestRequest, TestResponse>();
            Assert.Throws<ArgumentNullException>(() => _engine.Query(null));
        }
        [Test]
        public void QueryWhenTimeoutAndRequestIsNullTest()
        {
            var _engine = new EngineFacade<PlacesQueryAutoCompleteRequest, PlacesQueryAutoCompleteResponse>();
            Assert.Throws<ArgumentNullException>(() => _engine.Query(null, new TimeSpan()));
        }

        [Test]
        public void QueryAsyncWhenRequestIsNullTest()
        {
            var _engine = new EngineFacade<TestRequest, TestResponse>();
            Assert.Throws<ArgumentNullException>(() => _engine.QueryAsync(null));
        }
        [Test]
        public void QueryAsyncWhenRequestIsNullAndTimeoutTest()
        {
            var _engine = new EngineFacade<TestRequest, TestResponse>();
            Assert.Throws<ArgumentNullException>(() => _engine.QueryAsync(null, new TimeSpan()));
        }    
        [Test]
        public void QueryAsyncWhenRequestIsNullAndCancellationTokenTest()
        {
            var _engine = new EngineFacade<TestRequest, TestResponse>();
            Assert.Throws<ArgumentNullException>(() => _engine.QueryAsync(null, new CancellationToken()));
        }
        [Test]
        public void QueryAsyncWhenRequestIsNullAndTimeoutAndCancellationTokenTest()
        {
            var _engine = new EngineFacade<TestRequest, TestResponse>();
            Assert.Throws<ArgumentNullException>(() => _engine.QueryAsync(null, new TimeSpan(), new CancellationToken()));
        }
    }
}