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
            var _httpConnectionLimit = GenericEngine<TestRequest, TestResponse>.HttpConnectionLimit;
            var _connectionLimit = GenericEngine.HttpServicePoint.ConnectionLimit;

            Assert.AreEqual(_connectionLimit, _httpConnectionLimit);
        }
        [Test]
        public void SetHttpConnectionLimitTest()
        {
            const int HTTP_CONNECTION_LIMIT = 10;
            GenericEngine<TestRequest, TestResponse>.HttpConnectionLimit = HTTP_CONNECTION_LIMIT;

            Assert.AreEqual(HTTP_CONNECTION_LIMIT, GenericEngine.HttpServicePoint.ConnectionLimit);
        }

        [Test]
        public void GetHttpsConnectionLimitTest()
        {
            var _httpsConnectionLimit = GenericEngine<TestRequest, TestResponse>.HttpsConnectionLimit;
            var _connectionLimit = GenericEngine.HttpsServicePoint.ConnectionLimit;

            Assert.AreEqual(_connectionLimit, _httpsConnectionLimit);
        }
        [Test]
        public void SetHttpsConnectionLimitTest()
        {
            const int HTTPS_CONNECTION_LIMIT = 10;
            GenericEngine<TestRequest, TestResponse>.HttpsConnectionLimit = HTTPS_CONNECTION_LIMIT;

            Assert.AreEqual(HTTPS_CONNECTION_LIMIT, GenericEngine.HttpsServicePoint.ConnectionLimit);
        }
    }
}
