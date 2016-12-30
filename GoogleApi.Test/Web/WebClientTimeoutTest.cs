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
            var timeout = new TimeSpan(0, 0, 0, 30);
            var webClientTimeout = new WebClientTimeout(timeout);

            Assert.AreEqual(timeout, webClientTimeout.Timeout);
        }
    }
}
