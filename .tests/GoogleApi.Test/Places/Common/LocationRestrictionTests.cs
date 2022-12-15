using GoogleApi.Entities.Common;
using GoogleApi.Entities.Places.Common;
using NUnit.Framework;

namespace GoogleApi.Test.Places.Common;

[TestFixture]
public class LocationRestrictionTests : BaseTest
{
    [Test]
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

    [Test]
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