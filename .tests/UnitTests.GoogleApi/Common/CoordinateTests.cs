using System.Globalization;
using GoogleApi.Entities.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.GoogleApi.Common;

[TestClass]
public class CoordinateTests
{
    [TestMethod]
    public void ConstructorTest()
    {
        var coordinate = new Coordinate(1, 1);

        Assert.AreEqual(1, coordinate.Latitude);
        Assert.AreEqual(1, coordinate.Longitude);
    }

    [TestMethod]
    public void ToStringTest()
    {
        var coordinate = new Coordinate(1, 1);

        var toString = coordinate.ToString();
        Assert.AreEqual($"{coordinate.Latitude.ToString(CultureInfo.InvariantCulture)},{coordinate.Longitude.ToString(CultureInfo.InvariantCulture)}", toString);
    }

    [TestMethod]
    public void ToStringWithVerySmallLatitudeAndLongtitudeTest()
    {
        var coordinate = new Coordinate(-0.000004, 34.5259883333333);

        var toString = coordinate.ToString();
        Assert.AreEqual($"{((decimal)coordinate.Latitude).ToString(CultureInfo.InvariantCulture)},{((decimal)coordinate.Longitude).ToString(CultureInfo.InvariantCulture)}", toString);
    }
}