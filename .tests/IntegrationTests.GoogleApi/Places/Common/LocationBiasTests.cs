using GoogleApi.Entities.Common;
using GoogleApi.Entities.Places.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests.GoogleApi.Places.Common;

[TestClass]
public class LocationBiasTests : BaseTest
{
    [TestMethod]
    public void ToStringWhenIpBiasTest()
    {
        var bias = new LocationBias
        {
            IpBias = true
        };

        var toString = bias.ToString();
        Assert.IsNotNull(toString);
        Assert.AreEqual("ipbias", toString);
    }

    [TestMethod]
    public void ToStringWhenPointTest()
    {
        var bias = new LocationBias
        {
            Location = new Coordinate(1, 1)
        };

        var toString = bias.ToString();
        Assert.IsNotNull(toString);
        Assert.AreEqual($"point:{bias.Location}", toString);
    }

    [TestMethod]
    public void ToStringWhenCircleTest()
    {
        var bias = new LocationBias
        {
            Location = new Coordinate(1, 1),
            Radius = 1000
        };

        var toString = bias.ToString();
        Assert.IsNotNull(toString);
        Assert.AreEqual($"circle:{bias.Radius}@{bias.Location}", toString);
    }

    [TestMethod]
    public void ToStringTestWhenRectangularTest()
    {
        var bias = new LocationBias
        {
            Bounds = new ViewPort(new Coordinate(1, 1), new Coordinate(2, 2))
        };

        var toString = bias.ToString();
        Assert.IsNotNull(toString);
        Assert.AreEqual($"rectangle:{bias.Bounds.SouthWest}|{bias.Bounds.NorthEast}", toString);
    }
}