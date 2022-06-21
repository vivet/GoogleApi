using System.Globalization;
using GoogleApi.Entities.Common;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Common;

[TestFixture]
public class CoordinateTests
{
    [Test]
    public void ConstructorTest()
    {
        var coordinate = new Coordinate(1, 1);

        Assert.AreEqual(1, coordinate.Latitude);
        Assert.AreEqual(1, coordinate.Longitude);
    }

    [Test]
    public void ToStringTest()
    {
        var coordinate = new Coordinate(1, 1);

        var toString = coordinate.ToString();
        Assert.AreEqual($"{coordinate.Latitude.ToString(CultureInfo.InvariantCulture)},{coordinate.Longitude.ToString(CultureInfo.InvariantCulture)}", toString);
    }
}