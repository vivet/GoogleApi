using GoogleApi.Entities.Common;
using GoogleApi.Entities.Places.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.Test.Places.Common;

[TestClass]
public class LocationRestrictionTests : BaseTest
{
    [TestMethod]
    public void ToStringWhenLocationRestrictionAndCircleTest()
    {
        var restriction = new LocationRestriction
        {
            Location = new Coordinate(1, 1),
            Radius = 1000
        };

        var toString = restriction.ToString();
        Assert.IsNotNull(toString);
        Assert.AreEqual($"circle:{restriction.Radius}@{restriction.Location}", toString);
    }

    [TestMethod]
    public void ToStringWhenLocationRestrictionAndRectangularTest()
    {
        var restriction = new LocationRestriction
        {
            Bounds = new ViewPort(new Coordinate(1, 1), new Coordinate(2, 2))
        };

        var toString = restriction.ToString();
        Assert.IsNotNull(toString);
        Assert.AreEqual($"rectangle:{restriction.Bounds.SouthWest}|{restriction.Bounds.NorthEast}", toString);
    }
}