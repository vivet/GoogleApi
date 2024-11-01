using System.Globalization;
using GoogleApi.Entities.Maps.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests.Maps.Common;

[TestClass]
public class CoordinateExTests
{
    [TestMethod]
    public void ConstructorTest()
    {
        var coordinate = new CoordinateEx(1, 1);

        Assert.AreEqual(1, coordinate.Latitude);
        Assert.AreEqual(1, coordinate.Longitude);
        Assert.IsNull(coordinate.Heading);
        Assert.IsFalse(coordinate.UseSideOfRoad);
    }

    [TestMethod]
    public void ToStringTest()
    {
        var coordinate = new CoordinateEx(1, 1);

        var toString = coordinate.ToString();
        Assert.AreEqual($"{coordinate.Latitude.ToString(CultureInfo.InvariantCulture)},{coordinate.Longitude.ToString(CultureInfo.InvariantCulture)}", toString);
    }

    [TestMethod]
    public void ToStringWhenHeadingTest()
    {
        var coordinate = new CoordinateEx(1, 1)
        {
            Heading = 90
        };

        var toString = coordinate.ToString();
        Assert.AreEqual($"heading={coordinate.Heading}:{coordinate.Latitude.ToString(CultureInfo.InvariantCulture)},{coordinate.Longitude.ToString(CultureInfo.InvariantCulture)}", toString);
    }

    [TestMethod]
    public void ToStringWhenHeadingAndSideOfRoadTest()
    {
        var coordinate = new CoordinateEx(1, 1)
        {
            Heading = 90,
            UseSideOfRoad = true
        };

        var toString = coordinate.ToString();
        Assert.AreEqual($"side_of_road:{coordinate.Latitude.ToString(CultureInfo.InvariantCulture)},{coordinate.Longitude.ToString(CultureInfo.InvariantCulture)}", toString);
    }

    [TestMethod]
    public void ToStringWhenSideOfRoadTest()
    {
        var coordinate = new CoordinateEx(1, 1)
        {
            UseSideOfRoad = true
        };

        var toString = coordinate.ToString();
        Assert.AreEqual($"side_of_road:{coordinate.Latitude.ToString(CultureInfo.InvariantCulture)},{coordinate.Longitude.ToString(CultureInfo.InvariantCulture)}", toString);
    }
}