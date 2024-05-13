using GoogleApi.Entities.Maps.Geocoding.PlusCode.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.Geocoding.PlusCode;

[TestFixture]
public class GlobalCodeTests
{
    [Test]
    public void ConstructorDefaultTest()
    {
        var globalCode = new GlobalCode("code");
        Assert.AreEqual("code", globalCode.Code);
    }

    [Test]
    public void ToStringTest()
    {
        var globalCode = new GlobalCode("code");

        var toString = globalCode.ToString();
        Assert.AreEqual(globalCode.Code, toString);
    }
}