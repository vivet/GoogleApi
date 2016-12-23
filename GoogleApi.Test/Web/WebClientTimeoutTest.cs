using System;
using GoogleApi.Web;
using NUnit.Framework;

namespace GoogleApi.Test.Web
{
    [TestFixture]
    public class WebClientTimeoutTest
    {
        [Test]
        public void ConstructorInitializesTimeoutTest()
        {
            var _timeout = new TimeSpan(0, 0, 0, 30);
            var _webClientTimeout = new WebClientTimeout(_timeout);

            Assert.AreEqual(_timeout, _webClientTimeout.Timeout);
        }
    }
}
