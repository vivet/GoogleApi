using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Geocoding.PlusCode.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.GoogleApi.Maps.Geocoding.PlusCode;

[TestClass]
public class LocationTests
{
    [TestMethod]
    public void ConstructorWhenCoordinateTest()
    {
        var coordinate = new Coordinate(1, 1);
        var location = new global::GoogleApi.Entities.Maps.Geocoding.PlusCode.Request.Location(coordinate);
        Assert.AreEqual(coordinate.ToString(), location.String);
    }

    [TestMethod]
    public void ConstructorWhenAddressTest()
    {
        var address = new global::GoogleApi.Entities.Common.Address("address");
        var location = new global::GoogleApi.Entities.Maps.Geocoding.PlusCode.Request.Location(address);
        Assert.AreEqual(address.ToString(), location.String);
    }

    [TestMethod]
    public void ConstructorWhenGlobalCodeTest()
    {
        var globalCode = new GlobalCode("code");
        var location = new global::GoogleApi.Entities.Maps.Geocoding.PlusCode.Request.Location(globalCode);
        Assert.AreEqual(globalCode.ToString(), location.String);
    }

    [TestMethod]
    public void ConstructorWhenLocalCodeAndLocalityTest()
    {
        var localCodeAndLocality = new LocalCodeAndLocality("code", "locality");
        var location = new global::GoogleApi.Entities.Maps.Geocoding.PlusCode.Request.Location(localCodeAndLocality);
        Assert.AreEqual(localCodeAndLocality.ToString(), location.String);
    }
}