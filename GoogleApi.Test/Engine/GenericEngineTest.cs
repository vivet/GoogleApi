using GoogleApi.Engine;
using NUnit.Framework;

namespace GoogleApi.Test.Engine
{
    [TestFixture]
    public class GenericEngineTest : BaseTest
    {
        [Test]
        public void StaticConstructorInitializesHttpServicePointTest()
        {
            Assert.IsNotNull(GenericEngine.HttpServicePoint);
        }
        [Test]
        public void StaticConstructorInitializesHttpsServicePointTest()
        {
            Assert.IsNotNull(GenericEngine.HttpsServicePoint);
        }
        
        [Test]
        public void GetHttpConnectionLimitTest()
        {
            var httpConnectionLimit = GenericEngine<TestRequest, TestResponse>.HttpConnectionLimit;
            var connectionLimit = GenericEngine.HttpServicePoint.ConnectionLimit;

            Assert.AreEqual(connectionLimit, httpConnectionLimit);
        }
        [Test]
        public void SetHttpConnectionLimitTest()
        {
            const int httpConnectionLimit = 10;
            GenericEngine<TestRequest, TestResponse>.HttpConnectionLimit = httpConnectionLimit;

            Assert.AreEqual(httpConnectionLimit, GenericEngine.HttpServicePoint.ConnectionLimit);
        }

        [Test]
        public void GetHttpsConnectionLimitTest()
        {
            var httpsConnectionLimit = GenericEngine<TestRequest, TestResponse>.HttpsConnectionLimit;
            var connectionLimit = GenericEngine.HttpsServicePoint.ConnectionLimit;

            Assert.AreEqual(connectionLimit, httpsConnectionLimit);
        }
        [Test]
        public void SetHttpsConnectionLimitTest()
        {
            const int httpsConnectionLimit = 10;
            GenericEngine<TestRequest, TestResponse>.HttpsConnectionLimit = httpsConnectionLimit;

            Assert.AreEqual(httpsConnectionLimit, GenericEngine.HttpsServicePoint.ConnectionLimit);
        }
    }
}
