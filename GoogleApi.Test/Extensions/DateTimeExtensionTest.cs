using System;
using GoogleApi.Extensions;
using NUnit.Framework;

namespace GoogleApi.Test.Extensions
{
    [TestFixture]
    public class DateTimeExtensionTest
    {
        [Test]
        public void DateTimeToUnixTimestampTest()
        {
            var dateTime = DateTime.UtcNow;
            var expected = (int)(dateTime - DateTimeExtension.epoch).TotalSeconds;
            var actual = dateTime.DateTimeToUnixTimestamp();

            Assert.AreEqual(expected, actual);
        }
    }
}