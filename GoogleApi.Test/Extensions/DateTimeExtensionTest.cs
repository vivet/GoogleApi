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
            var _dateTime = DateTime.UtcNow;
            var _expected = (int)(_dateTime - DateTimeExtension._epoch).TotalSeconds;
            var _actual = _dateTime.DateTimeToUnixTimestamp();

            Assert.AreEqual(_expected, _actual);
        }
    }
}