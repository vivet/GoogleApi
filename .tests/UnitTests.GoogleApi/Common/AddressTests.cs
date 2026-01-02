using System;
using GoogleApi.Entities.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.GoogleApi.Common;

[TestClass]
public class AddressTests
{
    [TestMethod]
    public void ConstructorTest()
    {
        var address = new Address("address");

        Assert.AreEqual("address", address.String);
    }

    [TestMethod]
    public void ConstructorWhenNullTest()
    {
        Assert.Throws<ArgumentNullException>(() => new Address(null));
    }

    [TestMethod]
    public void ToStringTest()
    {
        var address = new Address("address");

        var toString = address.ToString();
        Assert.AreEqual(address.String, toString);
    }
}