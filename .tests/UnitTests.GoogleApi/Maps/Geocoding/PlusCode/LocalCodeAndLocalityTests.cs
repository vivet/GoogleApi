using GoogleApi.Entities.Maps.Geocoding.PlusCode.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.GoogleApi.Maps.Geocoding.PlusCode;

[TestClass]
public class LocalCodeAndLocalityTests
{
    [TestMethod]
    public void ConstructorDefaultTest()
    {
        var localCodeAndLocality = new LocalCodeAndLocality("code", "locality");
        Assert.AreEqual("code", localCodeAndLocality.Code);
        Assert.AreEqual("locality", localCodeAndLocality.Locality);
    }

    [TestMethod]
    public void ToStringTest()
    {
        var localCodeAndLocality = new LocalCodeAndLocality("code", "locality");

        var toString = localCodeAndLocality.ToString();
        Assert.AreEqual($"{localCodeAndLocality.Code} {localCodeAndLocality.Locality}", toString);
    }
}