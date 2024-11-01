using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests.Maps.Common;

[TestClass]
public class LocationExTests
{
    [TestMethod]
    public void ConstructorWhenPlaceTest()
    {
        var place = new Place("id");
        var location = new LocationEx(place);

        Assert.AreEqual($"place_id:{place}", location.String);
    }

    [TestMethod]
    public void ConstructorWhenAddressTest()
    {
        var address = new Address("address");
        var location = new LocationEx(address);

        Assert.AreEqual(address.ToString(), location.String);
    }

    [TestMethod]
    public void ConstructorWhenPlusCodeTest()
    {
        var plusCode = new PlusCode("global", "local");
        var location = new LocationEx(plusCode);

        Assert.AreEqual(plusCode.ToString(), location.String);
    }

    [TestMethod]
    public void ConstructorWhenCoordinateTest()
    {
        var coordinate = new CoordinateEx(1, 1);
        var location = new LocationEx(coordinate);

        Assert.AreEqual(coordinate.ToString(), location.String);
    }

    [TestMethod]
    public void ToStringTest()
    {
        var coordinate = new CoordinateEx(1, 1);
        var location = new LocationEx(coordinate);

        var toString = location.ToString();

        Assert.AreEqual(location.String, toString);
    }
}