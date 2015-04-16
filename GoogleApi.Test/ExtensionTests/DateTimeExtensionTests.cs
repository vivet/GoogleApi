using System;
using GoogleApi.Extensions;
using NUnit.Framework;

namespace GoogleApi.Test.ExtensionTests
{
    [TestFixture]
    public class DateTimeExtensionTests
    {
        [Test]
        public void DateToUnix_Success()
        {
            var date = new DateTime(1980, 5, 14);

            var result = date.ToUnixTimestamp();

            Assert.AreEqual(327110400, result);
        }
    }
}
