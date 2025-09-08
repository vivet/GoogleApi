using GoogleApi.Entities.Maps.Geocoding.PlusCode.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests.Maps.Geocoding.PlusCode;

[TestClass]
public class GlobalCodeTests
{
    [TestMethod]
    public void ConstructorDefaultTest()
    {
        var globalCode = new GlobalCode("code");
        Assert.AreEqual("code", globalCode.Code);
    }

    [TestMethod]
    public void ToStringTest()
    {
        var globalCode = new GlobalCode("code");

        var toString = globalCode.ToString();
        Assert.AreEqual(globalCode.Code, toString);
    }
}