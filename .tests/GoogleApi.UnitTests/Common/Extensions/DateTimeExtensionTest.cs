using System;
using GoogleApi.Entities.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests.Common.Extensions;

[TestClass]
public class DateTimeExtensionTest
{
    [TestMethod]
    public void DateTimeToUnixTimestampTest()
    {
        var dateTime = DateTime.UtcNow;
        var expected = (int)(dateTime - DateTimeExtension.epoch).TotalSeconds;
        var actual = dateTime.DateTimeToUnixTimestamp();

        Assert.AreEqual(expected, actual);
    }
}