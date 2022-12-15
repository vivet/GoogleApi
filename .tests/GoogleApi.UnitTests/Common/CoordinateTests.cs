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

    [Test]
    public void ToStringWithVerySmallLatitudeAndLongtitudeTest()
    {
        var coordinate = new Coordinate(-0.000004, 34.5259883333333);

        var toString = coordinate.ToString();
        Assert.AreEqual($"{((decimal)coordinate.Latitude).ToString(CultureInfo.InvariantCulture)},{((decimal)coordinate.Longitude).ToString(CultureInfo.InvariantCulture)}", toString);
    }
}