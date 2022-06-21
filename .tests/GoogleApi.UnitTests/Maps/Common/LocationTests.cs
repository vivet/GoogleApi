using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Common;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.Common;

[TestFixture]
public class LocationTests
{
    [Test]
    public void ConstructorWhenAddressTest()
    {
        var address = new Address("address");
        var location = new Location(address);

        Assert.AreEqual(address.ToString(), location.String);
    }

    [Test]
    public void ConstructorWhenCoordinateTest()
    {
        var coordinate = new Coordinate(1, 1);
        var location = new Location(coordinate);

        Assert.AreEqual(coordinate.ToString(), location.String);
    }

    [Test]
    public void ToStringTest()
    {
        var coordinate = new Coordinate(1, 1);
        var location = new Location(coordinate);

        var toString = location.ToString();

        Assert.AreEqual(location.String, toString);
    }

}