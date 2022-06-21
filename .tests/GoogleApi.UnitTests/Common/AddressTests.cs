using System;
using GoogleApi.Entities.Common;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Common;

[TestFixture]
public class AddressTests
{
    [Test]
    public void ConstructorTest()
    {
        var address = new Address("address");

        Assert.AreEqual("address", address.String);
    }

    [Test]
    public void ConstructorWhenNullTest()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            var address = new Address(null);
            Assert.IsNotNull(address);
        });
    }

    [Test]
    public void ToStringTest()
    {
        var address = new Address("address");

        var toString = address.ToString();
        Assert.AreEqual(address.String, toString);
    }
}