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